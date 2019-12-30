using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onebrb.Core.Entities;
using Onebrb.Core.Exceptions;
using Onebrb.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Onebrb.Core.Enumerations;

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileRepository _repository;
        private readonly ILogger<ProfilesController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfilesController(IProfileRepository repository, ILogger<ProfilesController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{profileId:int}")]
        public async Task<ActionResult<Profile>> Get(int profileId)
        {
            try
            {
                Profile profile = await _repository.GetProfileAsync(profileId);
                string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                if (profile == null)
                {
                    _logger.LogWarning($"{ipAddress}: Couldn't fetch profile with id {profileId}");
                    return StatusCode(StatusCodes.Status404NotFound, "Profile not found");
                }

                string currUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _logger.LogInformation($"Currently logged in user id {currUserId}");

                if (currUserId != null && int.TryParse(currUserId, out int userIdNumeric) && userIdNumeric == profileId)
                {
                    profile.ProfileType = ProfileTypeEnum.OwnProfile;
                }
                else
                {
                    profile.ProfileType = ProfileTypeEnum.NotOwnProfile;
                }

                return profile;
            }
            catch (CouldNotGetProfileException ex)
            {
                _logger.LogWarning($"Couldn't get profile with id {profileId}", ex.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}

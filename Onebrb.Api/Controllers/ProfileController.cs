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

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _repository;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IProfileRepository repository, ILogger<ProfileController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{profileId:int}")]
        public async Task<ActionResult<Profile>> Get(int profileId)
        {
            try
            {
                var profile = await _repository.GetProfileAsync(profileId);
                var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                if (profile == null)
                {
                    _logger.LogWarning($"{ipAddress}: Couldn't fetch profile with id {profileId}");
                    return StatusCode(StatusCodes.Status404NotFound, "Profile not found");
                }

                return profile;
            }
            catch (CouldNotGetProfileException ex)
            {
                _logger.LogWarning("CouldNotGetProfileException exception catched", ex.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}

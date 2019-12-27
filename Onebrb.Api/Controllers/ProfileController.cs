﻿using Microsoft.AspNetCore.Http;
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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _repository;
        private readonly ILogger<ProfileController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileController(IProfileRepository repository, ILogger<ProfileController> logger, IHttpContextAccessor httpContextAccessor)
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
                var profile = await _repository.GetProfileAsync(profileId);
                var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                if (profile == null)
                {
                    _logger.LogWarning($"{ipAddress}: Couldn't fetch profile with id {profileId}");
                    return StatusCode(StatusCodes.Status404NotFound, "Profile not found");
                }

                var currUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _logger.LogWarning($"Currently logged in user id {currUserId}");

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
                _logger.LogWarning("CouldNotGetProfileException exception catched", ex.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}

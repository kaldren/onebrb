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

        [HttpGet("{email}")]
        public async Task<ActionResult<Profile>> Get(string email)
        {
            try
            {
                _logger.LogWarning($"{HttpContext.Connection.RemoteIpAddress.ToString()}: Couldn't fetch profile with email {email}");
                var profile = await _repository.GetProfileAsync(email);

                if (profile == null)
                {
                    HttpContext.Connection.RemoteIpAddress.ToString();
                    _logger.LogWarning($"Couldn't fetch profile with email {email}");
                    return StatusCode(StatusCodes.Status404NotFound, "Email address not found");
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

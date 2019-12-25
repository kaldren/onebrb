using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ProfileController(IProfileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Profile>> Get(string email)
        {
            try
            {
                var profile = await _repository.GetProfileAsync(email);

                if (profile == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Email address not found");
                }

                return profile;
            }
            catch (EmailAddressNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}

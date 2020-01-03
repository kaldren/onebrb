using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Onebrb.Api.Entities;
using Onebrb.Api.Helpers;
using Onebrb.Api.Interfaces;
using Onebrb.Core.Entities;
using Onebrb.Core.Models;
using Onebrb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Profile>> Authenticate(Profile profile)
        {
            Profile userAuth = await _authService.Authenticate(profile);

            if (userAuth != null) { return Ok(userAuth); }

            return null;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Onebrb.Api.Entities;
using Onebrb.Api.Configurations;
using Onebrb.Api.Interfaces;
using Onebrb.Core.Entities;
using Onebrb.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ApiConfiguration _apiConfig;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(ApplicationDbContext dbContext, IOptions<ApiConfiguration> apiConfig, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _apiConfig = apiConfig.Value;
            _userManager = userManager;
        }

        public async Task<Profile> Authenticate(Profile profile)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == profile.Username);
            if (user == null) { return null; }

            profile.Firstname = user.FirstName;
            profile.Lastname = user.LastName;

            PasswordVerificationResult checkPass = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, profile.Password);

            if (checkPass != PasswordVerificationResult.Success) { return null; }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_apiConfig.AuthSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            profile.Token = tokenHandler.WriteToken(token);

            return profile;
        }
    }
}

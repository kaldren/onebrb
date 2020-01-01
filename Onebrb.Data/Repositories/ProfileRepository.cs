using Microsoft.EntityFrameworkCore;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
using Onebrb.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ApplicationUser> GetProfileAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetProfileAsync(int profileId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == profileId);
        }

        public async Task<ApplicationUser> GetProfileAsync(string nickname)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }
    }
}

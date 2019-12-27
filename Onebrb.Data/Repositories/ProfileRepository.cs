using Microsoft.EntityFrameworkCore;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
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

        public Task<Profile> GetProfileAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> GetProfileAsync(int profileId)
        {
            ApplicationUser user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == profileId);

            return (user == null) ? null : Mapping.Mapper.Map<Profile>(user);
        }
    }
}

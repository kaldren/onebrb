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
            ApplicationUser profile = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == profileId);

            return (profile == null) ? null : Mapping.Mapper.Map<Profile>(profile);
        }

        public async Task<Profile> GetProfileAsync(string nickname)
        {
            ApplicationUser profile = await _dbContext.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);

            return (profile == null) ? null : Mapping.Mapper.Map<Profile>(profile);
        }
    }
}

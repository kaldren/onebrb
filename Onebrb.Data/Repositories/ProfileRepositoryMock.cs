using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Data
{
    public class ProfileRepositoryMock : IProfileRepository
    {
        public async Task<Profile> GetProfileAsync(Guid id)
        {
            return new Profile
            {
                FirstName = "John",
                LastName = "Doe"
            };
        }

        public async Task<Profile> GetProfileAsync(string email)
        {
            return new Profile
            {
                FirstName = "John",
                LastName = "Doe"
            };
        }
    }
}

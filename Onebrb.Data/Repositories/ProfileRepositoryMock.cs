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
        private List<Profile> mockData = new List<Profile>
        {
            new Profile { FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" },
            new Profile { FirstName = "Bob", LastName = "Segar", Email = "bob@example.com" },
            new Profile { FirstName = "Steve", LastName = "Ballmer", Email = "steveb@microsoft.com" },
        };
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
            return mockData.FirstOrDefault(x => x.Email == email);
        }
    }
}

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
            new Profile { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" },
            new Profile { Id = 2, FirstName = "Bob", LastName = "Segar", Email = "bob@example.com" },
            new Profile { Id = 3, FirstName = "Steve", LastName = "Ballmer", Email = "steveb@microsoft.com" },
        };

        public async Task<Profile> GetProfileAsync(int profileId)
        {
            return mockData.FirstOrDefault(x => x.Id == profileId);
        }
    }
}

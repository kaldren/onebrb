using Onebrb.Core.Entities;
using Onebrb.Core.Enumerations;
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
            new Profile { Id = 1, FirstName = "Bob", LastName = "Segar", Email = "bob@example.com", ProfileType = ProfileTypeEnum.NotDetermined },
            new Profile { Id = 2, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", ProfileType = ProfileTypeEnum.NotDetermined },
            new Profile { Id = 3, FirstName = "Steve", LastName = "Ballmer", Email = "steveb@microsoft.com", ProfileType = ProfileTypeEnum.NotDetermined },
        };

        public async Task<Profile> GetProfileAsync(int profileId)
        {
            return mockData.FirstOrDefault(x => x.Id == profileId);
        }

        public Task<Profile> GetProfileAsync()
        {
            throw new NotImplementedException();
        }
    }
}

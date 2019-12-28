using Moq;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Onebrb.UnitTests
{
    public class ProfileRepositoryShould
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileRepositoryShould()
        {

        }

        [Fact]
        public void ReturnProfileById()
        {
            var mock = new Mock<IProfileRepository>();
            int profileId = 1;

            mock.Setup(x => x.GetProfileAsync(profileId)).ReturnsAsync(new Profile
            {
                ProfileId = 1,
                FirstName = "Kaloyan",
                LastName = "Drenski",
                Email = "drenski666@gmail.com"
            });

        }
    }
}

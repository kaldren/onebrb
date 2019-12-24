using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Spa.Data
{
    public class ProfileRepositoryMock : IProfileRepository
    {
        public Profile GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public Profile GetProfile(string email)
        {
            throw new NotImplementedException();
        }
    }
}

using Onebrb.Api.Entities;
using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Services
{
    public interface IAuthService
    {
        Task<Profile> Authenticate(string username, string password);
    }
}

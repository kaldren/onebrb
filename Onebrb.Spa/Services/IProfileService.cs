using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public interface IProfileService
    {
        Task<Profile> GetProfileAsync(string profileId);
    }
}

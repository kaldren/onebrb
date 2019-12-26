using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Interfaces
{
    public interface IProfileRepository
    {
        /// <summary>
        /// Get profile by email asynchronously
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns></returns>
        Task<Profile> GetProfileAsync(int profileId);
    }
}

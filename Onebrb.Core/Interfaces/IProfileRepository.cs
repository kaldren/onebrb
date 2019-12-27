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
        /// Get own profile asynchronously
        /// </summary>
        /// <returns></returns>
        Task<Profile> GetProfileAsync();

        /// <summary>
        /// Get profile by id asynchronously
        /// </summary>
        /// <param name="profileId">profile id</param>
        /// <returns></returns>
        Task<Profile> GetProfileAsync(int profileId);
    }
}

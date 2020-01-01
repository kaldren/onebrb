using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Interfaces.Repos
{
    public interface IProfileRepository
    {
        /// <summary>
        /// Get own profile
        /// </summary>
        /// <returns>The profile</returns>
        Task<ApplicationUser> GetProfileAsync();

        /// <summary>
        /// Get profile by id
        /// </summary>
        /// <param name="profileId">profile id</param>
        /// <returns>The profile</returns>
        Task<ApplicationUser> GetProfileAsync(int profileId);


        /// <summary>
        /// Get profile by nickname
        /// </summary>
        /// <param name="nickname">nickname</param>
        /// <returns>The profile</returns>
        Task<ApplicationUser> GetProfileAsync(string nickname);
    }
}

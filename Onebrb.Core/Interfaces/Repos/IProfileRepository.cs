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
        /// Gets user's own profile.
        /// </summary>
        /// <returns>The profile</returns>
        Task<ApplicationUser> GetProfileAsync();

        /// <summary>
        /// Gets profile by id.
        /// </summary>
        /// <param name="profileId">The profile id</param>
        /// <returns>The profile</returns>
        Task<ApplicationUser> GetProfileAsync(int profileId);


        /// <summary>
        /// Gets profile by a nickname
        /// </summary>
        /// <param name="nickname">The nickname</param>
        /// <returns>The profile</returns>
        Task<ApplicationUser> GetProfileAsync(string nickname);
    }
}

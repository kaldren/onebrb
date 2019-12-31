using Onebrb.Core.Entities;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public interface IProfileService
    {
        /// <summary>
        /// Get own profile
        /// </summary>
        /// <returns></returns>
        Task<Profile> GetProfileAsync();

        /// <summary>
        /// Get profile by id
        /// </summary>
        /// <param name="profileId">Profile id</param>
        /// <returns></returns>
        Task<ProfileModel> GetProfileAsync(int profileId);

        /// <summary>
        /// Get logged in user Id
        /// </summary>
        /// <returns></returns>
        public int GetLoggedInUserId();
    }
}

using Onebrb.Core.Entities;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Interfaces.Services
{
    public interface IProfileService
    {
        
        /// <summary>
        /// Gets profile by nickname.
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        Task<ProfileModel> GetProfileAsync(string nickname);

        /// <summary>
        /// Gets profile by id.
        /// </summary>
        /// <param name="profileId">Profile id</param>
        /// <returns></returns>
        Task<ProfileModel> GetProfileAsync(int profileId);
        
        /// <summary>
        /// Gets the profile of the currently logged in user.
        /// </summary>
        /// <returns>The profile</returns>
        Task<ProfileModel> GetLoggedInUserProfile();

        /// <summary>
        /// Gets the id of the currently logged in user.
        /// </summary>
        /// <returns>The id</returns>
        public int GetLoggedInUserId();
    }
}

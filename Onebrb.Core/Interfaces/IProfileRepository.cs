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
        /// Get profile by Id asynchronously
        /// </summary>
        /// <param name="id">Profile id</param>
        /// <returns></returns>
        Task<Profile> GetProfileAsync(Guid id);

        /// <summary>
        /// Get profile by email asynchronously
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns></returns>
        Task<Profile> GetProfileAsync(string email);
    }
}

using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onebrb.Core.Interfaces
{
    interface IProfileRepository
    {
        /// <summary>
        /// Get profile by Id
        /// </summary>
        /// <param name="id">Profile id</param>
        /// <returns></returns>
        public Profile GetProfile(Guid id);

        /// <summary>
        /// Get profile by email
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns></returns>
        public Profile GetProfile(string email);
    }
}

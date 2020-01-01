using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Interfaces.Repos
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Gets all categories asynchronously
        /// </summary>
        /// <returns>The categories</returns>
        Task<IList<Category>> GetAllCategoriesAsync();
    }
}

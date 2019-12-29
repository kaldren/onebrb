using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Gets all categories asynchronously
        /// </summary>
        /// <returns>The categories</returns>
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}

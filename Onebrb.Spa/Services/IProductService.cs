using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Creates product asynchronously
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>The product</returns>
        Task<Product> CreateProductAsync(Product product);

        /// <summary>
        /// Gets all products asynchronously
        /// </summary>
        /// <returns>The products</returns>
        Task<ICollection<Product>> GetAllProducts();
    }
}

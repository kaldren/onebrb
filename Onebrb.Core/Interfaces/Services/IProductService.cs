using Onebrb.Core.Entities;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Interfaces.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Creates product asynchronously
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>The product</returns>
        Task<ProductModel> CreateProductAsync(ProductModel product);

        /// <summary>
        /// Gets all products asynchronously
        /// </summary>
        /// <returns>The products</returns>
        Task<ICollection<Product>> GetAllProducts();
    }
}

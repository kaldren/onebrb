using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Interfaces.Repos
{
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product</param>
        /// <exception cref="Core.Exceptions.CouldNotCreateProductException">Thrown when there was an error creating the product.</exception>
        /// <returns>The product that was created.</returns>
        Task<Product> CreateProductAsync(Product product);

        /// <summary>
        /// Gets a product by Id.
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <returns>The product</returns>
        Task<Product> GetProductAsync(int productId);

        /// <summary>
        /// Gets all products by a given nickname.
        /// </summary>
        /// <param name="nickname">The nickname</param>
        /// <returns>The products</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync(string nickname);
    }
}

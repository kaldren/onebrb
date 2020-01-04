using Microsoft.EntityFrameworkCore;
using Onebrb.Core.Entities;
using Onebrb.Core.Exceptions;
using Onebrb.Core.Interfaces;
using Onebrb.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
            }
            catch (CouldNotCreateProductException ex)
            {
                throw new CouldNotCreateProductException($"Couldn't add product to database. {ex.InnerException}");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string nickname)
        {
            return await _dbContext.Products
                            .Include(u => u.Owner)
                            .Include(c => c.Category)
                            .Where(p => p.Owner.Nickname == nickname)
                            .ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _dbContext.Products
                .Include(category => category.Category)
                .Include(owner => owner.Owner)
                .FirstOrDefaultAsync(x => x.Id == productId);
        }
    }
}

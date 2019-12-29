using Microsoft.EntityFrameworkCore;
using Onebrb.Core.Entities;
using Onebrb.Data;
using Onebrb.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Onebrb.UnitTests
{
    public class ProductRepositoryShould
    {
        [Fact]
        public async void ReturnProductById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ReturnProductById")
                .Options;

            int idToLookFor = 1;

            // Add mock data
            using (var context = new ApplicationDbContext(options))
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product() { Id = 1, Title = "Title 1", Description = "Description 1", Price = 10},
                    new Product() { Id = 2, Title = "Title 2", Description = "Description 2", Price = 20},
                    new Product() { Id = 3, Title = "Title 3", Description = "Description 3", Price = 30},
                });
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var productRepository = new ProductRepository(context);
                var product = await productRepository.GetProductAsync(1);

                Assert.IsType<Product>(product);
                Assert.Equal(product.Id, idToLookFor);
            }

        }
    }
}

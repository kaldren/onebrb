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
        public async void CreateNewProductAndReturnOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateNewProduct")
                .Options;

            Product productToAdd = new Product
            {
                Id = 1,
                Title = "Test title",
                Description = "Test description",
                Price = 12
            };

            using (var context = new ApplicationDbContext(options))
            {
                var productRepo = new ProductRepository(context);

                int numProductsCreated = await productRepo.CreateProductAsync(productToAdd);

                Assert.Equal(1, numProductsCreated);
                Assert.Equal(1, context.Products.Count());
            }
        }

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

        [Fact]
        public async void ReturnAllProductsOfGivenNickname()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ReturnAllProductsOfGivenNickname")
                .Options;

            ApplicationUser user = new ApplicationUser { Nickname = "johndoe" };

            List<Category> categories = new List<Category>()
            {
                new Category {Id = 1, Name = "Toys"},
                new Category {Id = 2, Name = "Electronics"},
            };

            List<Product> products = new List<Product>()
            {
                new Product {Id = 1, Category = categories.First(), Owner = user, Title = "Some title", Description = "Some descr", Price = 25},
                new Product {Id = 2, Category = categories.Last(), Owner = user, Title = "Some title 2", Description = "Some descr 2", Price = 125},
            };

            using (var context = new ApplicationDbContext(options))
            {
                await context.Users.AddAsync(user);
                await context.Categories.AddRangeAsync(categories);
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var productRepo = new ProductRepository(context);
                IEnumerable<Product> allProducts = await productRepo.GetAllProductsAsync(user.Nickname);

                Assert.True(allProducts.Count() == 2);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onebrb.Spa.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ?? "-1";

            product.Owner = new ApplicationUser();

            product.Owner.Id = int.Parse(userId);

            // Set token header
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.User.FindFirst("ApiToken")?.Value);

            var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/products", productJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Product>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            }

            return null;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            ICollection<Product> products = await JsonSerializer.DeserializeAsync<ICollection<Product>>
                (await _httpClient.GetStreamAsync($"api/product"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return products;
        }
    }
}

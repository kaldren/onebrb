using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onebrb.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            ICollection<Category> categories = await JsonSerializer.DeserializeAsync<ICollection<Category>>
                (await _httpClient.GetStreamAsync($"api/categories"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return categories;
        }
    }
}

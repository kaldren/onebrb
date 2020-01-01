using Microsoft.AspNetCore.Components;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Pages.Product
{
    public class CreateProductBase : ComponentBase
    {
        protected Core.Entities.Product Product { get; set; } = new Core.Entities.Product();

        protected ICollection<Category> Categories { get; set; } = new List<Category>();

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        public string SelectedCategoryId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ICollection<Category> categoriesFromDb = (await CategoryService.GetAllCategoriesAsync());
            SelectedCategoryId = categoriesFromDb.First().Id.ToString();

            foreach (var category in categoriesFromDb)
            {
                Categories.Add(category);
            }
        }

        protected void OnCategoryChange()
        {

        }

        protected async Task HandleValidFormSubmit()
        {
            Category selectedCategory = Categories.FirstOrDefault(p => p.Id.ToString() == SelectedCategoryId);
            Product.Category = new Category();
            Product.Category.Id = selectedCategory.Id;

            await ProductService.CreateProductAsync(Product);
            StateHasChanged();
        }
    }
}

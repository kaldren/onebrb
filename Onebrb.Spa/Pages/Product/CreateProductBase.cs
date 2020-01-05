using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Pages.Product
{
    public class CreateProductBase : ComponentBase
    {
        #region Bindings
        protected ProductModel Product { get; set; }
        protected ICollection<Category> Categories { get; set; }
        public string SelectedCategoryId { get; set; }
        public bool DataLoaded { get; set; }
        #endregion Bindings

        #region Services
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }
        #endregion Services

        #region UI Properties
        public bool ProductCreated { get; set; } = false;
        public string Message { get; private set; } = string.Empty;
        public string MessageCss { get; private set; }

        public ClaimsPrincipal User { get; set; }
        #endregion UI Properties

        public CreateProductBase()
        {
            Product = new ProductModel();
            Categories = new List<Category>();
        }

        protected override async Task OnInitializedAsync()
        {
            ICollection<Category> categoriesFromDb = (await CategoryService.GetAllCategoriesAsync());

            SelectedCategoryId = categoriesFromDb.First().Id.ToString();

            foreach (var category in categoriesFromDb)
            {
                Categories.Add(category);
            }

            DataLoaded = true;
        }

        protected async Task HandleValidFormSubmit()
        {
            Product.CategoryId = int.Parse(SelectedCategoryId);

            ProductModel productCreated = await ProductService.CreateProductAsync(Product);

            if (productCreated == null)
            {
                Message = $"Something unexpected happened. Please try again later.";
                MessageCss = "alert alert-danger";
                ProductCreated = false;
            }
            else
            {
                ProductCreated = true;
                Message = $"{Product.Title} has been uploaded To Onebrb.";
                MessageCss = "alert alert-success";
            }

            StateHasChanged();
        }
    }
}

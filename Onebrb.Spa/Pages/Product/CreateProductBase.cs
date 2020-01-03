using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces.Services;
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
        protected Core.Entities.Product Product { get; set; } = new Core.Entities.Product();

        protected ICollection<Category> Categories { get; set; } = new List<Category>();
        public string SelectedCategoryId { get; set; }
        #endregion Bindings

        #region Services
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        #endregion Services

        #region UI Properties
        public bool ProductCreated { get; set; } = false;
        public string Message { get; private set; } = string.Empty;
        public string MessageCss { get; private set; }
        public bool IsAuthenticatedUser { get; set; } = false;

        public ClaimsPrincipal User { get; set; }
        #endregion UI Properties

        protected override async Task OnInitializedAsync()
        {

            // Check if it is a logged in user
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            User = authState.User;

            if (User.Identity.IsAuthenticated)
            {
                ICollection<Category> categoriesFromDb = (await CategoryService.GetAllCategoriesAsync());
                SelectedCategoryId = categoriesFromDb.First().Id.ToString();

                foreach (var category in categoriesFromDb)
                {
                    Categories.Add(category);
                }

                IsAuthenticatedUser = true;
            }
            else
            {
                // Not logged in
                IsAuthenticatedUser = false;
            }
        }

        protected async Task HandleValidFormSubmit()
        {
            Product.Category = new Category();
            Product.Category.Id = int.Parse(SelectedCategoryId);

            Core.Entities.Product productCreated = await ProductService.CreateProductAsync(Product);

            if (productCreated != null)
            {
                ProductCreated = true;
                Message = $"{Product.Title} has been uploaded To Onebrb.";
                MessageCss = "alert alert-success";
            }
            else
            {
                Message = $"Something unexpected happened. Please try again later.";
                MessageCss = "alert alert-danger";
                ProductCreated = false;
            }

            StateHasChanged();
        }
    }
}

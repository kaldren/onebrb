using Microsoft.AspNetCore.Components;
using Onebrb.Core.Entities;
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
        protected List<Category> Categories { get; set; } = new List<Category>();

        protected override async Task OnInitializedAsync()
        {
            
        }
    }
}

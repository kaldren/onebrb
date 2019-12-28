using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Pages.Product
{
    public class ProductBase : ComponentBase
    {
        [Parameter]
        public int ProductId { get; set; }
    }
}

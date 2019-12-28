using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Pages.Product
{
    public class CreateProductBase : ComponentBase
    {
        protected Product Product { get; set; }

        public int MyProperty { get; set; }
    }
}

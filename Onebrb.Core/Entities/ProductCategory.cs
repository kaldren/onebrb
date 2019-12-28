using Onebrb.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public ProductCategoryEnum Category { get; set; }
    }
}

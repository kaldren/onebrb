using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Models
{
    public class ProductModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
    }
}

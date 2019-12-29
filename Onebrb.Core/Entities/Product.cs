using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Onebrb.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsFree { get; set; }
        public bool IsNegotiable { get; set; }
        public Category Category { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}

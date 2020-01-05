using Onebrb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsFree { get; set; }
        public bool IsNegotiable { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}

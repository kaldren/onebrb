using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Onebrb.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [MinLength(1), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3), MaxLength(14)]
        public string Nickname { get; set; }

        [Required]
        public string ProductsUrl { get; set; }
    }
}

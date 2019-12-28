using Onebrb.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onebrb.Core.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ProfileTypeEnum ProfileType { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

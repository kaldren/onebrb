using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Attributes
{
    public class RequiredCategoryAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "Please choose a category";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value.ToString() == "-1" ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }
    }
}

using Onebrb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Spa.Attributes
{
    public class UniqueNicknameAttribute : ValidationAttribute
    {
        public string GetErrorMessage(string nickname) =>
            $"Nickname {nickname} is already taken!";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ApplicationDbContext dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var entity = dbContext.Users.FirstOrDefault(u => u.Nickname == value.ToString());

            if (entity == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage(value.ToString()));
        }
    }
}

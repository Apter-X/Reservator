using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reservator
{


    public class EmailAttribute : ValidationAttribute
    {

        

      

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var sValue = value as string;
            string[] splitValue = sValue.Split("@");

            if (!string.IsNullOrEmpty(sValue) && splitValue[1] == "student.youcode.ma")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(string.Format(ErrorMessageString, validationContext.MemberName));
        }
    }
    
}
  


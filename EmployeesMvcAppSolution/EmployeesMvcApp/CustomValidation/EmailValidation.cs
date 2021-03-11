using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.CustomValidation
{
    public class EmailValidation : ValidationAttribute
    {
        string correctValue;

        public EmailValidation(string correctValue)
        {
            this.correctValue = correctValue;
        }
    }
}

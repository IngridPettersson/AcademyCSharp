using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models.ViewModels
{
    public class EmployeeCreateVM
    {
        [Required(ErrorMessage = "Add valid name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Add valid email")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
        [Display(Name ="Company ID")]
        public SelectListItem[] CompanyId { get; set; }

        [Required(ErrorMessage = "EEEERRRROOOORRRR")]
        [Display(Name = "What is 2 x 2?")]
        [Range(4, 4)]
        public int BotCheck { get; set; }
    }
}

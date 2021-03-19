using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatesPontusProject.Models.ViewModels
{
    public class SettingsCreateVM
    {
        [Display(Name="Enter company's support email address")]
        [Required(ErrorMessage ="Required field")]
        [EmailAddress(ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }
        [Display(Name ="Enter company name")]
        [Required(ErrorMessage ="You must enter a valid Company name")]
        public string CompanyName { get; set; }
    }
}

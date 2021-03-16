using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models.ViewModels
{
    public class EmployeeIndexVM
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
       
        public string Email { get; set; }
        [Display(Name = "Email")]
        public bool ShowAsHighlighted { get; set; }
        public string CompanyName { get; set; }

    }
}

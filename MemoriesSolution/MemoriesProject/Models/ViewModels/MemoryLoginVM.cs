using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class MemoryLoginVM
    {
        [Required(ErrorMessage ="Du måste fylla i ett användarnamn för att logga in")]
        [Display(Name ="Användarnamn")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Du måste fylla i ett lösenord för att logga in")]
        [Display(Name ="Lösenord")]
        public string Password { get; set; }

    }
}

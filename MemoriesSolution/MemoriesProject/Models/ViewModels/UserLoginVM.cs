using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class UserLoginVM
    {
        [Display(Name = "Användarnamn")]
        [Required(ErrorMessage = "Du måste fylla i ett användarnamn för att logga in")]
        
        public string Username { get; set; }
        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste fylla i ett lösenord för att logga in")]
        public string Password { get; set; }
    }
}

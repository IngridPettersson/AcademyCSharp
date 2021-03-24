using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class UserLoginVM
    {
        [Display(Name ="Användarnamn")]
        [Required(ErrorMessage ="Du måste fylla i ett användarnamn för att logga in")]
        public string Username { get; set; }
        [Display(Name ="Lösenord")]
        [Required(ErrorMessage ="Du måste fylla i ett lösenord för att logga in")]
        public string Password { get; set; }
        [Display(Name = "Välj ett användarnamn")]
        [Required(ErrorMessage = "Du måste ange ett användarnamn för att skapa ett konto")]
        public string UsernameChoice { get; set; }
        [Display(Name = "Välj ett lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord för att skapa ett konto")]
        public string PasswordChoice { get; set; }

        [Display(Name = "Upprepa lösenord")]
        [Required(ErrorMessage = "Du måste upprepa lösenordet för att skapa ett konto")]
        public string PasswordChoiceRepeat { get; set; }

    }
}

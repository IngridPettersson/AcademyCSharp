using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class UserCreateAccountVM
    {
        [Display(Name = "Välj ett användarnamn")]
        [Required(ErrorMessage = "Du måste ange ett användarnamn för att skapa ett konto")]
        public string UsernameChoice { get; set; }

        [Display(Name = "Välj ett lösenord")]
        [Required(ErrorMessage = "Du måste ange ett lösenord för att skapa ett konto")]
        [DataType(DataType.Password)]

        public string PasswordChoice { get; set; }

        [Display(Name = "Upprepa lösenord")]
        [Required(ErrorMessage = "Du måste upprepa lösenordet för att skapa ett konto")]
        [Compare(nameof(UserCreateAccountVM.PasswordChoice))]
        [DataType(DataType.Password)]

        public string PasswordChoiceRepeat { get; set; }
    }
}

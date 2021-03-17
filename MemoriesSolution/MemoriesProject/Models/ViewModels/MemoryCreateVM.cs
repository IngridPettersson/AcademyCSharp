using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class MemoryCreateVM
    {

        //Ennia vänder sig för första gången från mage till ryggen! Ingen är mer förvånad än hon själv! Inser dock snart att hon inte kan vända sig tillbaka till rygg och förvåningen utbyts mot en djup förtvivlan som inte lämnar någon(granne) oberörd :)
        [Display(Name = "Vem tillhör minnet")]
        [Required(ErrorMessage = "Du måste ange vem minnet tillhör")]
        public string MemoryHolder { get; set; }

        [Display(Name = "Vilka var med")]
        public string PeopleInMemory { get; set; }
        [Display(Name = "Ge ditt minne en titel")]
        [Required(ErrorMessage = "Du måste ge minnet en titel")]
        public string MemoryTitle { get; set; }
        //[Display(Name = "Ange datum för minnet...")]
        //public DateTime When { get; set; }
        [Display(Name = "...eller skriv med egna ord något kring tiden för minnet")]
        public string WhenInWords { get; set; }
        [Display(Name = "Berätta om ditt minne här")]
        public string Description { get; set; }
        [Display(Name = "Här kan du lägga till en bild till minnet")]
        public string ImageUrl { get; set; }
        //public DateTime AddedWhen { get; set; }
    }
}

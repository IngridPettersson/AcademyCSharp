using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class MemoryIndexVM
    {
        //public Person MemoryHolder { get; set; }
        public static string MemoryHolder { get; set; }
        [Required(ErrorMessage = "Du måste ge minnet en titel")]
        [Display(Name = "Lägg till en titel för ditt minne")]
        public string MemoryTitle { get; set; }
        [Display(Name = "Ange tid för minnet")]
        public DateTime When { get; set; }
        public string WhenInWords { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

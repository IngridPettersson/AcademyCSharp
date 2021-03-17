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
        public string MemoryHolder { get; set; }
        public string PeopleInMemory { get; set; }

        public string MemoryTitle { get; set; }

        //Hur skriva in datetime
        public DateTime When { get; set; }
        public string WhenInWords { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime AddedWhen { get; set; }
    }
}

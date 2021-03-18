using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.ViewModels
{
    public class MemoryDetailsVM
    {
        public string MemoryHolder { get; set; }
        public string PeopleInMemory { get; set; }
        public string MemoryTitle { get; set; }
        public string WhenInWords { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}

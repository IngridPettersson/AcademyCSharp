using System;
using System.Collections.Generic;

#nullable disable

namespace MemoriesProject.Models.Entities
{
    public partial class Memory
    {
        public int Id { get; set; }
        public string MemoryHolder { get; set; }
        public string PeopleInMemory { get; set; }
        public string MemoryTitle { get; set; }
        public string WhenInWords { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

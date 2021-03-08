using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETPractice.Models
{
    public record Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Description { get; set; }
    }
}

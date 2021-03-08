using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETPractice.Models
{
    public class ToyService
    {
        static List<Toy> toys = new List<Toy>
        {
            new Toy {Id=1, Name="Shoes", Popularity=7},
            new Toy {Id=2, Name="Gam Gam", Popularity=10, Description="A brown soft teddybear from Iran and given to " +
                "Ennia at the very first visit from the kind and loving Amo Reza."},
            new Toy {Id=3, Name="Ear phones", Popularity=8},
            new Toy {Id=4, Name="Scissor", Popularity=5}
        };
        internal Toy[] GetToys()
        {
            return toys
                .OrderByDescending(o => o.Popularity)
                .ToArray();
        }

        internal Toy GetDetails(int id)
        {
            return toys
                .Where(o => o.Id == id)
                .First();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETPractice.Models
{
    public class ToyService
    {
        static int idCounter = 1;
        static List<Toy> toys = new List<Toy>();
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

        internal void AddToy(Toy toy)
        {
            toy.Id = idCounter++;
            toys.Add(toy);
        }
    }
}

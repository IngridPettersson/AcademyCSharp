using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavouriteBand.Models
{
    public class BandService
    {

        static List<Band> bands = new List<Band>
        {
            new Band {Id=1, Name="Uncle Kracker", Description="Best song: Follow me", ImageUrl="/Images/uncle.jpg"},
            new Band {Id=2, Name="Mötley Crüe", Description="Best song: Kickstart my heart", ImageUrl="/Images/motley.jpg"},
            new Band {Id=3, Name="Ástor Piazzolla", Description="Best song: Ave Maria (Instrumental)", ImageUrl="/Images/astor.jpg"}
        };

        public Band GetBandById(int id)
        {
            return bands
                .Where(o => o.Id == id)
                .Single();
        }

        public Band[] GetAllBands()
        {
            return bands
                .OrderBy(o => o.Name)
                .ToArray();
        }
    }
}

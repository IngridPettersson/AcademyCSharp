using MVCMoviesPontus.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMoviesPontus.Models
{
    public class MoviesService
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie {Id=1, Title="Inside out", Description="Sweet cartoon movie"},
            new Movie {Id=2, Title="Spirited away", Description="A Hayao Miyazaki classic"},
            new Movie {Id=3, Title="Edge of tomorrow", Description="Måndag hela veckan"},
            new Movie {Id=4, Title="Arrival", Description="Weird objects coming up"}
        };

        internal IndexVM GetMovieViewModel(int id)
        {
            var movie = movies
               .Where(o => o.Id == id)
               .Single();

            return new IndexVM
            {
                Title = movie.Title,
                Description = movie.Description
            };
        }
    }
}

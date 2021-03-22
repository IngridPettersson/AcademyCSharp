using Microsoft.AspNetCore.Mvc;
using MVCMoviesPontus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMoviesPontus.Controllers
{
    public class MoviesController : Controller
    {
        MoviesService service;
        public MoviesController(MoviesService service)
        {
            this.service = service;
        }
        [Route("")]
        [Route("Index/{id}")]
        public IActionResult Index(int id)
        {
            var viewModel = service.GetMovieViewModel(id);
            return PartialView("_MovieBox", viewModel);
        }
    }
}

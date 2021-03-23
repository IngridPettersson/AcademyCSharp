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
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Index/{id}")]
        public IActionResult IndexHtml(int id)
        {
            var viewModel = service.GetMovieViewModel(id);
            return PartialView("_MovieBox", viewModel);
        }

        [Route("/IndexJson/{id}")]
        public IActionResult IndexJSON(int id)
        {
            var viewModel = service.GetMovieViewModel(id);
            return Json(viewModel); //Serialization from object to string. Tror att vi låtsas att vi hämtar vår data
                                    // från någon annanstans än från filmlistan i MovieService. Eller måste vi skicka datan
                                    // som JSON eller HTML mellan frontend och backend? Kan vi inte bara skicka objekten
                                    // som de är?
        }
    }
}

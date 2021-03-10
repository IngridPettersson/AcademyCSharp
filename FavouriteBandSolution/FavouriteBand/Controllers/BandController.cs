using FavouriteBand.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavouriteBand.Controllers
{
    public class BandController : Controller
    {
        BandService service = new BandService();

        [Route("")]
        [Route("bands")]
        public IActionResult Index()
        {
            var bands = service.GetAllBands();
            return View(bands);
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var band = service.GetBandById(id);
            return View(band);
        }
    }
}

using ASPNETPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETPractice.Controllers
{
    public class ToyController : Controller
    {
        ToyService service = new ToyService();

        [Route("")]
        public IActionResult Index()
        {
            var toys = service.GetToys();
            return View(toys);
        }

        [Route("Details/{Id}")]
        public IActionResult Details(int id)
        {
            var toy = service.GetDetails(id);
            return View(toy);        
        }
    }
}

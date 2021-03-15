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

        [Route("/Toy/Details/{Id}")]
        public IActionResult Details(int id)
        {
            var toy = service.GetDetails(id);
            return View(toy);        
        }

        [Route("/Toy/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/Toy/Create")]
        [HttpPost]
        public IActionResult Create(Toy toy)
        {
            service.AddToy(toy);
            return RedirectToAction(nameof(Index));
        }
    }
}

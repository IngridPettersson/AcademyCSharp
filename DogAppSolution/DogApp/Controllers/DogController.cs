using DogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Controllers
{
    public class DogController : Controller
    {
        DogService service = new DogService();

        [Route("")]
        //[Route("Index")]
        //[Route("Dog/Index")]
        public IActionResult Index()
        {
            var dogs = service.GetAllDogs();
            return View(dogs);
        }

        [Route("Dog/Create")]
        //[Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Dog/Create")]
        //[Route("Create")]
        [HttpPost]
        public IActionResult Create(Dog dog)
        {
            service.AddDog(dog);
            return RedirectToAction(nameof(Index));
        }

        [Route("Dog/Edit/{Id}")]
        //[Route("Edit/{Id}")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dog = service.GetDogById(id);
            return View(dog);
        }

        [Route("Dog/Edit/{Id}")]
        //[Route("Edit/{Id}")]
        [HttpPost]
        public IActionResult Edit(Dog dog)
        {
            service.UpdateDog(dog);
            return RedirectToAction(nameof(Index));
        }
    }
}

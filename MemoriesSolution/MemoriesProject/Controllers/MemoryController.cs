using MemoriesProject.Models.Services;
using MemoriesProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Controllers
{
    public class MemoryController : Controller
    {
        MemoryService service;

        public MemoryController(MemoryService service)
        {
            this.service = service;
        }
        
        [Route("")]
        public IActionResult Index()
        {
            var memories = service.GetAllMemories();
            return View(memories);
        }

        [Route("/Memory/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        //[Route("/Memory/Create")]
        //[HttpPost]
        //public IActionResult Create()
        //{
        //    service.AddMemory();

        //}
    }
}

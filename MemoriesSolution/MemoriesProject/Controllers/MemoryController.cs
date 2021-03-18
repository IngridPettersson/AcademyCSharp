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

        [Route("/Memory/Create")]
        [HttpPost]
        public IActionResult Create(MemoryCreateVM memoryVM)
        {
            if (!ModelState.IsValid)
                return View();

            service.AddMemory(memoryVM);
            return RedirectToAction(nameof(Index));
        }

        [Route("/Memory/Details/{Id}")]
        public IActionResult Details(int id)
        {
            var memory = service.GetMemoryById(id);
            var memoryViewModel = service.GetMemoryDetailsVM(memory);
            return View(memoryViewModel);
        }

        [Route("/Memory/Edit/{Id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var memory = service.GetMemoryById(id);
            var memoryViewModel = service.GetMemoryEditVM(memory);
            return View(memoryViewModel);
        }

        [Route("/Memory/Edit/{Id}")]
        [HttpPost]
        public IActionResult Edit(MemoryEditVM memoryVM, int id)
        {
            if (!ModelState.IsValid)
                return View();

            service.EditMemory(memoryVM, id);
            return RedirectToAction(nameof(Index));
        }

    }
}

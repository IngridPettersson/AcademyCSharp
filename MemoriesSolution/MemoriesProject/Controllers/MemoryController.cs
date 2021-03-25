using MemoriesProject.Models.Services;
using MemoriesProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [Route("")]
        public IActionResult Index()
        {
            var viewModel = service.GetAllMemories();

            //var createdAccountSuccess = (string)TempData["Message"];

            return View(viewModel);
        }

        [Route("/Memory/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [Route("/Memory/Create")]
        [HttpPost]
        //Den verkar hitta routern Create trots att den nu heter CreateAsync
        public async Task<IActionResult> CreateAsync(MemoryCreateVM memoryVM)
        {
            if (!ModelState.IsValid)
                return View();

            await service.AddMemoryAsync(memoryVM);
            return RedirectToAction(nameof(Index));
        }

        //[Route("/Memory/Create")]
        //[HttpPost]
        //public IActionResult Create(MemoryCreateVM memoryVM)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    service.AddMemory(memoryVM);
        //    return RedirectToAction(nameof(Index));
        //}

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
            MemoryEditVM memoryViewModel = service.GetMemoryEditVM(memory);
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

        [Route("/Memory/Delete/{Id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var memory = service.GetMemoryById(id);
            MemoryDeleteVM deleteVM = service.GetDeleteVM(memory);
            return View(deleteVM);
        }

        [Route("/Memory/Delete/{Id}")]
        [HttpPost]
        public IActionResult Delete(MemoryDeleteVM memoryDeleteVM, int id)
        {
            //if(submit-button clicked)
            {
                service.DeleteMemory(memoryDeleteVM, id);
            }
            return RedirectToAction(nameof(Index));
        }



    }
}

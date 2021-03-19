using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StatesPontusProject.Models;
using StatesPontusProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatesPontusProject.Controllers
{
    public class SettingsController : Controller
    {
        SettingsService service;
        IMemoryCache cache;

        public SettingsController(SettingsService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        [Route("")]
        [Route("/settings/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("")]
        [Route("/settings/create")]
        [HttpPost]
        public IActionResult Create(SettingsCreateVM createVM)
        {
            if (!ModelState.IsValid)
                return View();


            service.AddSettings(createVM);
            cache.Set("supportEmail", createVM.Email);
            HttpContext.Session.SetString("CompanyName", createVM.CompanyName);
            TempData["Message"] = "Saved!";
            return RedirectToAction(nameof(Display));
        }

        [Route("/settings/display")]
        public IActionResult Display()
        {
            var viewModel = new SettingsDisplayVM
            {
                Email = cache.Get<string>("supportEmail"),
                CompanyName = HttpContext.Session.GetString("CompanyName"),
                Message = (string)TempData["Message"]
            };
            return View(viewModel);
        }
    }
}


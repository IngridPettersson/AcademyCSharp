using MemoriesProject.Models.Services;
using MemoriesProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Controllers
{
    public class UserController : Controller
    {
        UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }

        [Route("/Memory/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/Memory/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View();


            await service.CreateUser(loginVM);
            return RedirectToAction("Index", "Memory");
        }
    }
}

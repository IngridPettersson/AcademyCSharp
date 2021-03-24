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

        [Route("/User/CreateAccount")]
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [Route("/User/CreateAccount")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(UserCreateAccountVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            await service.CreateUser(viewModel);
            return RedirectToAction("Index", "Memory");  
        }

        [Route("/User/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/User/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            await service.LoginSuccess(viewModel);
            return RedirectToAction("Index", "Memory");
            //TODO: redirect till en annan view som man får när man är inloggad, med fler features.
        }
    }
}

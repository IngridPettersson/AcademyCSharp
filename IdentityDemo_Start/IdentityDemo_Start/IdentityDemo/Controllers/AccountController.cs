using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityDemo.Models;
using IdentityDemo.Models.ViewModels;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityDemo.Controllers
{
    //TODO: Authorize-filter i MembersController - alltså skapa en ny controller. Ngt görs automatiskt med Identity(?). Kan 
    //lägga på den på Action i ursprungliga controllern om det handlar om enstaka inloggningsskyddad sida.
    //Slide 5 Identity
    public class AccountController : Controller
    {
        AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [Route("members")]
        [Authorize]
        public IActionResult Members()
        {
            return View(new AccountMembersVM { Username = User.Identity.Name });
        }

        [HttpGet]
        [Route("")]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(AccountRegisterVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Try to register user
            var success = await accountService.TryRegisterAsync(viewModel);
            if (!success)
            {
                // Show error
                ModelState.AddModelError(string.Empty, "Failed to create user");
                return View(viewModel);
            }

            // Redirect user
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            return View(new AccountLoginVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(AccountLoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Check if credentials is valid (and set auth cookie)
            var success = await accountService.TryLoginAsync(viewModel);
            if (!success)
            {
                // Show error
                ModelState.AddModelError(nameof(AccountLoginVM.Username), "Login failed");
                return View(viewModel);
            }

            // Redirect user
            if (string.IsNullOrWhiteSpace(viewModel.ReturnUrl))
                return RedirectToAction(nameof(Members));
            else
                return Redirect(viewModel.ReturnUrl);
        }


        [Route("logout")]
        public async Task<IActionResult> LogoutAsync()
        {

            await accountService.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

    }
}

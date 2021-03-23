using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackingProject.Controllers
{
    public class HackingSkillsController : Controller
    {
        [Route("")]
        [Route("home/index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("home/about")]
        public IActionResult About()
        {
            throw new Exception();
        }

        [Route("/home/form")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostForm()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}

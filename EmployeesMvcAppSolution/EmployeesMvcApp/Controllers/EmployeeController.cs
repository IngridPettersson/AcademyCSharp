using EmployeesMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService service;
        IContentService contentService;

        public EmployeeController(EmployeeService service, IContentService contentService)
        {
            this.service = service;
            this.contentService = contentService;
        }


        [Route("About")]
        public IActionResult About()
        {
            //var header = contentService.GetHeader();
            //var body = contentService.GetBody();
            //return View(contentService);

            
            return View(service.GetAbout());
        }


        [Route("")]
        public IActionResult Index()
        {

            var employees = service.GetAllEmployees();
            return View(employees);
        }

        [Route("/Employee/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/Employee/Create")]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                service.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
        }

        [Route("/Employee/Details/{Id}")]
        public IActionResult Details(int id)
        {
            var employee = service.GetEmployeeById(id);
            return View(employee);
        }

    }
}

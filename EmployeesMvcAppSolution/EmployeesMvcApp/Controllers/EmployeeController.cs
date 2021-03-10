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
        EmployeeService service = new EmployeeService();

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

    }
}

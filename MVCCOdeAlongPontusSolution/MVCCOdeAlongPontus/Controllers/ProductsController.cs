using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCOdeAlongPontus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCOdeAlongPontus.Controllers
{
    public class ProductsController : Controller
    {
        ProductService service = new ProductService();

        // En action svarar på ett HTTP-anrop
        [Route("")]
        public IActionResult Index()
        {
            // return Content("Hello from Index :) Här visar vi våra produkter.");
            var products = service.GetAll();
            return View(products);
        }

        [Route("products/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("products/create")]
        [HttpPost]
        //public IActionResult Create(IFormCollection form)
        public IActionResult Create(Product product)

        {
            if (!ModelState.IsValid)
                return View(product);
            else
                return RedirectToAction(nameof(Index));
            //return View();
        }

        [Route("products/{id}")]

        // inparametern måste ha samma namn som namnet i måsvingarna i Route
        public IActionResult Details(int id)
        {
            return Content($"Hello from ShowId :) Här visar vi produkt {id}");
        }

    }
}

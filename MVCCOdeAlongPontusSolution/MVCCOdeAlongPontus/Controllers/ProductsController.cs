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
        public IActionResult Create()
        {
            return Content("Hello from Create :) Här visar vi ett formulär för att skapa en ny produkt.");
        }

        [Route("products/{id}")]
        
        // inparametern måste ha samma namn som namnet i måsvingarna i Route
        public IActionResult Details(int id)
        {
            return Content($"Hello from ShowId :) Här visar vi produkt {id}");
        }

    }
}

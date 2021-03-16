using MemoriesProject.Models.Services;
using MemoriesProject.Models.ViewModels;
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
        
        [Route("")]
        public IActionResult Index()
        {
            //var memories = service.GetAllMemories();
            //List<MemoryIndexVM> memoryList = new List<MemoryIndexVM>();
            //var memory = new MemoryIndexVM
            //{
            //    MemoryTitle = "Vänder sig",
            //    WhenInWords = "3 månader gammal",
            //    Description = "Vänder sig från mage till rygg för första gången. Jag hör henne skrika på golvet " +
            //    "och hittar henne strandad på rygg, och hon ser ganska förvånad ut. Mest missnöjd dock eftersom " +
            //    "hon inte kan vända sig tillbaka till mage än."
            //};
            //memoryList.Add(memory);
            return View();
            //return View(memories);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyOwnAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiPhotosController : ControllerBase
    {
        ApiPhotosService service;

        public ApiPhotosController(ApiPhotosService service)
        {
            this.service = service;
        }
        [Route("")]
        [HttpGet]
        public ActionResult<Photo[]> Index()
        {
            var photos = service.GetPhotosJson();

            if (photos != null)
                return photos;
            else
                return BadRequest("Error");
        }
    }
}

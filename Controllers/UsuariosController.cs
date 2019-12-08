using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Usuarios.Controllers
{
    [Route("/Nombre")]
    public class UsuariosController : Controller
    {
        //[HttpGet]
        [Route("/Nombre/Frank")]
        public IActionResult Index(string data, int age = 51)
        {
            String datos = data+ " " + age;
            return View("Index",datos);
        }

        public IActionResult Index()
        {            
            return View();
        }
    }
}
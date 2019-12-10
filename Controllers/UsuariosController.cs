using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Usuarios.Controllers
{
    //[Route("[controller]")]
    public class UsuariosController : Controller
    {
        //[HttpGet]
        //[Route("/Usuarios/Frank")]
        //[HttpGet("[controller]/[action]/{data:int}")]
        public IActionResult Index(int data)
        {
            //var url = Url.Action("Metodo","Usuarios",new { age= 51, name="Frank"});
            //return View("Index",data);
            var url = Url.RouteUrl("Franqui", new { age = 51, name = "Frank" });
            return Redirect(url);
        }

        [HttpGet("[controller]/[action]",Name = "Franqui")]
        public IActionResult Metodo(int code)
        {
            var data = $"codigo de Estado {code}";
            return View("Index", data);
        }
    }
}
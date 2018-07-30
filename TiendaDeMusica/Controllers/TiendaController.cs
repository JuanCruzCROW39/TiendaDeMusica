using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaDeMusica.Controllers
{
    public class TiendaController : Controller
    {
        //// GET: Tienda
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string Index()
        {
            return "Hola desde Tienda.Index()";
        }

        public string About()
        {
            return "Hola desde Tienda.About()";
        }

        public string Contact()
        {
            return "Hola desde Tienda.Contact()";
        }

        public string Texto(string texto)
        {
            string mensaje = HttpUtility.HtmlEncode("Este es la palabra ingresada ->" + texto);
            return mensaje;
        }

        public string Numero(int id)
        {
            string mensaje = "Numero ingresado >>> " + id;
            return mensaje;
        }
    }
}
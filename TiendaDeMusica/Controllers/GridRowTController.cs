using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TiendaDeMusica.Models;

namespace TiendaDeMusica.Controllers
{
    public class GridRowTController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();
        // GET: GridRowT
        public ActionResult Index()
        {
            ViewBag.Artistas = context.Artistas.ToList();
            ViewBag.Generos = context.Generoes.ToList();
            var model = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            return View(model);
        }

        public ActionResult Details(int key)
        {
            var canciones = context.Canciones.Where(c => c.AlbumId == key).ToList();
            var info = context.DescripcionAlbums.Where(d => d.AlbumId == key).ToList();
            return Json(data: new { canciones = canciones, info = info }, behavior: JsonRequestBehavior.AllowGet);
        }

        public ActionResult Gauge()
        {
            return View();
        }
    }
}
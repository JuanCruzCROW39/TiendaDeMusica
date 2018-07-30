using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TiendaDeMusica.Models;

namespace TiendaDeMusica.Controllers
{
    public class MapaController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();

        // GET: Mapa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mapa()
        {
            var model = context.Hospitales.ToList();
            return View(model);
        }

        public ActionResult Split()
        {
            var model = context.Hospitales.ToList();
            return View(model);
        }

        
        public ActionResult Coordenadas()
        {
            var data = context.Markers.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Albums()
        {
            var data = context.Albums.ToList();
            ViewBag.Artistas = context.Artistas.ToList();
            ViewBag.Generos = context.Generoes.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(string album)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            Album x = json.Deserialize<Album>(album);
            context.Albums.Add(x);
            context.SaveChanges();
            var data = context.Albums.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string album)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            Album x = json.Deserialize<Album>(album);
            var search = context.Albums.Where(a => a.AlbumId == x.AlbumId).FirstOrDefault();
            if (search != null)
            {
                search.Titulo = x.Titulo;
                search.ArtistaId = x.ArtistaId;
                search.GeneroId = x.GeneroId;
                search.Precio = x.Precio;
                search.AlbumArtURL = x.AlbumArtURL;
            }
            context.SaveChanges();
            var data = context.Albums.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int key)
        {            
            var search = context.Albums.Where(a => a.AlbumId == key).FirstOrDefault();
            context.Albums.Remove(search);
            context.SaveChanges();
            var data = context.Albums.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
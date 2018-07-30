using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeMusica.Models;
using System.Data.Entity;

namespace TiendaDeMusica.Controllers
{
    public class SyncPruebaController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();
        private int noRegistro;

        // GET: SyncPrueba
        public ActionResult Index()
        {
            var album = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            ViewBag.DataSourceArtista = context.Artistas.ToList();
            ViewBag.DataSourceGenero = context.Generoes.ToList();
            noRegistro = context.Albums.Count()+1;
            return View(album);
        }

        public ActionResult Create(Album value)
        {
            
            context.Albums.Add(value);
            context.SaveChanges();
            var data = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            //ViewBag.Count = context.Albums.Count() + 1;
            return Json(value, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        public ActionResult Update(Album value)
        {
            
            var album = context.Albums.Where(a => a.AlbumId == value.AlbumId).FirstOrDefault();
            if (album != null)
            {
                album.AlbumArtURL = value.AlbumArtURL;
                album.Artista = value.Artista;
                album.ArtistaId = value.ArtistaId;
                album.Genero = value.Genero;
                album.GeneroId = value.GeneroId;
                album.Precio = value.Precio;
                album.Titulo = value.Titulo;
            }

            context.SaveChanges();

            var data = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int key)
        {
            var album = context.Albums.Where(a => a.AlbumId == key).FirstOrDefault();
            try
            {
                context.Albums.Remove(album);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
            var data = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            return Json(key, JsonRequestBehavior.AllowGet);
        }
    }
}
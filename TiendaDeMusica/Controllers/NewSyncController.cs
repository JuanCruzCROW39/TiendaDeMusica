using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TiendaDeMusica.Models;

namespace TiendaDeMusica.Controllers
{
    public class AlbumModel
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public int ArtistaId { get; set; }
        public string Artista { get; set; }
        public int GeneroId { get; set; }
        public string Genero { get; set; }
        public decimal Precio { get; set; }
    }

    public class NewSyncController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();

        // GET: NewSync
        public ActionResult Index()
        {
            var data = from album in context.Albums
                       join artista in context.Artistas on album.ArtistaId equals artista.ArtistaId
                       join genero in context.Generoes on album.GeneroId equals genero.GeneroId
                       select new AlbumModel
                       {
                           ID = album.AlbumId,
                           Titulo = album.Titulo,
                           ArtistaId = album.ArtistaId,
                           Artista = album.Artista.Nombre,
                           GeneroId = album.GeneroId,
                           Genero = album.Genero.Nombre,
                           Precio = album.Precio
                       };
            return View(data.ToList());
        }

        public ActionResult Create(AlbumModel value)
        {
            Album x = new Album()
            {
                AlbumId = value.ID,
                Titulo = value.Titulo,
                ArtistaId = value.ArtistaId,
                GeneroId = value.GeneroId,
                Precio = value.Precio
            };
            try
            {
                context.Albums.Add(x);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
            var data= from album in context.Albums
                      join artista in context.Artistas on album.ArtistaId equals artista.ArtistaId
                      join genero in context.Generoes on album.GeneroId equals genero.GeneroId
                      select new AlbumModel
                      {
                          ID = album.AlbumId,
                          Titulo = album.Titulo,
                          ArtistaId = album.ArtistaId,
                          Artista = album.Artista.Nombre,
                          GeneroId = album.GeneroId,
                          Genero = album.Genero.Nombre,
                          Precio = album.Precio
                      };
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(AlbumModel value)
        {
            var m = context.Albums.Where(n => n.AlbumId == value.ID).FirstOrDefault();

            if (m != null)
            {
                m.Titulo = value.Titulo;
                m.ArtistaId = value.ArtistaId;
                m.GeneroId = value.GeneroId;
                m.Precio = value.Precio;
            }

            try
            {
                context.Entry(m).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            var data = from album in context.Albums
                       join artista in context.Artistas on album.ArtistaId equals artista.ArtistaId
                       join genero in context.Generoes on album.GeneroId equals genero.GeneroId
                       select new AlbumModel
                       {
                           ID = album.AlbumId,
                           Titulo = album.Titulo,
                           ArtistaId = album.ArtistaId,
                           Artista = album.Artista.Nombre,
                           GeneroId = album.GeneroId,
                           Genero = album.Genero.Nombre,
                           Precio = album.Precio
                       };
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int key)
        {
            var x = context.Albums.Find(key);
            context.Albums.Remove(x);
            context.SaveChanges();

            var data = from album in context.Albums
                       join artista in context.Artistas on album.ArtistaId equals artista.ArtistaId
                       join genero in context.Generoes on album.GeneroId equals genero.GeneroId
                       select new AlbumModel
                       {
                           ID = album.AlbumId,
                           Titulo = album.Titulo,
                           ArtistaId = album.ArtistaId,
                           Artista = album.Artista.Nombre,
                           GeneroId = album.GeneroId,
                           Genero = album.Genero.Nombre,
                           Precio = album.Precio
                       };
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
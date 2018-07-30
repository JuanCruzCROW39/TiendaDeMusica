using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaDeMusica.Models;

namespace TiendaDeMusica.Controllers
{
    public class GerenteTiendaController : Controller
    {
        private TiendaDeMusicaContext db = new TiendaDeMusicaContext();

        // GET: GerenteTienda
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artista).Include(a => a.Genero);
            return View(albums.ToList());
        }

        // GET: GerenteTienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: GerenteTienda/Create
        public ActionResult Create()
        {
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre");
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre");
            return View();
        }

        // POST: GerenteTienda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GeneroId,ArtistaId,Titulo,Precio,AlbumArtURL")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre", album.ArtistaId);
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", album.GeneroId);
            return View(album);
        }

        // GET: GerenteTienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre", album.ArtistaId);
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", album.GeneroId);
            return View(album);
        }

        // POST: GerenteTienda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GeneroId,ArtistaId,Titulo,Precio,AlbumArtURL")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistaId = new SelectList(db.Artistas, "ArtistaId", "Nombre", album.ArtistaId);
            ViewBag.GeneroId = new SelectList(db.Generoes, "GeneroId", "Nombre", album.GeneroId);
            return View(album);
        }

        // GET: GerenteTienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: GerenteTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

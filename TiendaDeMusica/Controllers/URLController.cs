using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeMusica.Models;
using System.Data.Entity;

namespace TiendaDeMusica.Controllers
{
    public class URLController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();

        // GET: URL
        public ActionResult Index()
        {
            ViewBag.DataSourceArtista = context.Artistas.ToList();
            ViewBag.DataSourceGenero = context.Generoes.ToList();

            return View();
        }

        public ActionResult DataSource(Syncfusion.JavaScript.DataManager dm)
        {
            DataResult result = new DataResult();
            Syncfusion.JavaScript.DataSources.DataOperations dataOperations = new Syncfusion.JavaScript.DataSources.DataOperations();

            result.result= context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                result.result = dataOperations.PerformSorting(result.result, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                result.result = dataOperations.PerformWhereFilter(result.result, dm.Where, dm.Where[0].Operator);
                if (!dm.RequiresCounts)
                {
                    return Json(result.result);
                }
            }
            result.count = context.Albums.Include(a => a.Artista).Include(a => a.Genero).AsQueryable().Count();
            if (dm.Skip != 0)
            {
                result.result = dataOperations.PerformSkip(result.result, dm.Skip);
            }
            if (dm.Take != 0)
            {
                result.result = dataOperations.PerformTake(result.result, dm.Take);
            }
            if (dm.Search != null)
            {
                result.result = dataOperations.PerformSearching(result.result, dm.Search);
            }

            return Json(new { result = result.result, count = result.count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(Album value)
        {
            int reg = context.Albums.Count() + 1;
            
            try
            {
                context.Albums.Add(value);
                context.SaveChanges();
                var data = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
                ViewBag.Count = context.Albums.Include(a => a.Artista).Include(a => a.Genero).Count() + 1;
                return Json(value, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('[Albums]', RESEED,{reg})");
                return Json(new { value = e.Message }, JsonRequestBehavior.AllowGet);
                
            }
            
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
            ViewBag.Count = context.Albums.Include(a => a.Artista).Include(a => a.Genero).Count() + 1;

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
            ViewBag.Count = context.Albums.Include(a => a.Artista).Include(a => a.Genero).Count() + 1;
            var data = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
            return Json(key, JsonRequestBehavior.AllowGet);
        }
    }

    public class DataResult
    {
        public IEnumerable<Album> result { get; set; }
        public int count { get; set; }
    }
}
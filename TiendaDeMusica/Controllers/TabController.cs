using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeMusica.Models;
using System.Data.Entity;
using Syncfusion.EJ.Export;
using Syncfusion.EJ;
using Syncfusion.XlsIO;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.JavaScript;

using Syncfusion.JavaScript.Models;
using System.Web.Script.Serialization;
using System.Collections;
using System.Reflection;
using System.Drawing;

namespace TiendaDeMusica.Controllers
{
    public class TabController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();

        // GET: Tab
        public ActionResult Index()
        {
            ViewBag.DataSourceArtista = context.Artistas.ToList();
            ViewBag.DataSourceGenero = context.Generoes.ToList();
            return View();
        }

        public ActionResult GetAlbum()
        {
            ViewBag.DataSourceArtista = context.Artistas.ToList();
            ViewBag.DataSourceGenero = context.Generoes.ToList();
            return PartialView("Album");
        }

        public ActionResult GetArtista()
        {
            return PartialView("Artista");
        }

        public ActionResult GetGenero()
        {
            return PartialView("Genero");
        }

        public ActionResult DataAlbum(Syncfusion.JavaScript.DataManager dm)
        {
            DataResult result = new DataResult();
            Syncfusion.JavaScript.DataSources.DataOperations dataOperations = new Syncfusion.JavaScript.DataSources.DataOperations();

            result.result = context.Albums.Include(a => a.Artista).Include(a => a.Genero).ToList();
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

            return Json(new { result = result.result, count = result.count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DataArtista(Syncfusion.JavaScript.DataManager dm)
        {
            DataResultArtista result = new DataResultArtista();
            Syncfusion.JavaScript.DataSources.DataOperations dataOperations = new Syncfusion.JavaScript.DataSources.DataOperations();

            result.result = context.Artistas.ToList();
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
            result.count = context.Artistas.AsQueryable().Count();
            if (dm.Skip != 0)
            {
                result.result = dataOperations.PerformSkip(result.result, dm.Skip);
            }
            if (dm.Take != 0)
            {
                result.result = dataOperations.PerformTake(result.result, dm.Take);
            }

            return Json(new { result = result.result, count = result.count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DataGenero(Syncfusion.JavaScript.DataManager dm)
        {
            DataResultGenero result = new DataResultGenero();
            Syncfusion.JavaScript.DataSources.DataOperations dataOperations = new Syncfusion.JavaScript.DataSources.DataOperations();

            result.result = context.Generoes.ToList();
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
            result.count = context.Generoes.AsQueryable().Count();
            if (dm.Skip != 0)
            {
                result.result = dataOperations.PerformSkip(result.result, dm.Skip);
            }
            if (dm.Take != 0)
            {
                result.result = dataOperations.PerformTake(result.result, dm.Take);
            }

            return Json(new { result = result.result, count = result.count }, JsonRequestBehavior.AllowGet);
        }

        public void ExportToExcelAlbum(string GridModel)
        {
            ExcelExport exp = new ExcelExport();
           var DataSource = context.Albums.ToList();
            //GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            GridProperties obj = ConvertGridObject(GridModel);
            obj.Columns[2].DataSource = context.Artistas.ToList();
            obj.Columns[3].DataSource = context.Generoes.ToList();
            exp.Export(obj, DataSource, "ExcelAlbum.xlsx", Syncfusion.XlsIO.ExcelVersion.Excel2010, false, false, "default-theme");
        }

        public void ExportToExcelArtista(string GridModel)
        {
            ExcelExport exp = new ExcelExport();
            var DataSource = context.Artistas.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            exp.Export(obj, DataSource, "ExcelArtista.xlsx", Syncfusion.XlsIO.ExcelVersion.Excel2010, false, false, "flat-saffron");
        }

        public void ExportToExcelGenero(string GridModel)
        {
            ExcelExport exp = new ExcelExport();
            var DataSource = context.Generoes.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            exp.Export(obj, DataSource, "ExcelGenero.xlsx", Syncfusion.XlsIO.ExcelVersion.Excel2010, false, false, "flat-saffron");
        }

        public void ExportToWordAlbum(string GridModel)
        {
            WordExport exp = new WordExport();
            var DataSource = context.Albums.ToList();
            //GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            GridProperties obj = ConvertGridObject(GridModel);
            obj.Columns[2].DataSource = context.Artistas.ToList();
            obj.Columns[3].DataSource = context.Generoes.ToList();
            exp.Export(obj, DataSource, "WordAlbum.docx", false, false, "flat-saffron");
        }

        public void ExportToWordArtista(string GridModel)
        {
            WordExport exp = new WordExport();
            var DataSource = context.Artistas.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            exp.Export(obj, DataSource, "WordArtista.docx", false, false, "flat-saffron");
        }

        public void ExportToWordGenero(string GridModel)
        {
            WordExport exp = new WordExport();
            var DataSource = context.Generoes.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            exp.Export(obj, DataSource, "WordGenero.docx", false, false, "flat-saffron");
        }

        public void ExportToPdfAlbum(string GridModel)
        {
            PdfExport exp = new PdfExport();
            var DataSource = context.Albums.ToList();
            //GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            GridProperties obj = ConvertGridObject(GridModel);
            obj.Columns[2].DataSource = context.Artistas.ToList();
            obj.Columns[3].DataSource = context.Generoes.ToList();
            exp.Export(obj, DataSource, "PDFAlbum.pdf", false, false, "flat-saffron");
        }

        public void ExportToPdfArtista(string GridModel)
        {
            PdfExport exp = new PdfExport();
            var DataSource = context.Artistas.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            exp.Export(obj, DataSource, "PDFArtista.pdf", false, false, "flat-saffron");
        }

        public void ExportToPdfGenero(string GridModel)
        {
            PdfExport exp = new PdfExport();
            var DataSource = context.Generoes.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            exp.Export(obj, DataSource, "PDFGenero.pdf", false, false, "flat-saffron");
        }

        public ActionResult InsertAlbum(Album value)
        {
            context.Albums.Add(value);
            context.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertArtista(Artista value)
        {
            context.Artistas.Add(value);
            context.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertGenero(Genero value)
        {
            if (value.Nombre=="rap")
            {
                value.Nombre = "Rap";
            }
            if (value.Nombre == "band")
            {
                value.Nombre = "Banda";
            }
            context.Generoes.Add(value);
            context.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateAlbum(Album value)
        {
            var search = context.Albums.Where(a => a.AlbumId == value.AlbumId).FirstOrDefault();
            if (search != null)
            {
                search.Artista = value.Artista;
                search.AlbumArtURL = value.AlbumArtURL;
                search.ArtistaId = value.ArtistaId;
                search.Genero = value.Genero;
                search.GeneroId = value.GeneroId;
                search.Precio = value.Precio;
                search.Titulo = value.Titulo;
            }
            context.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateArtista(Artista value)
        {
            var search = context.Artistas.Where(a => a.ArtistaId == value.ArtistaId).FirstOrDefault();
            if (search != null)
            {
                search.Nombre = value.Nombre;
            }
            context.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateGenero(Genero value)
        {
            var search = context.Generoes.Where(g => g.GeneroId == value.GeneroId).FirstOrDefault();
            if (search != null)
            {
                search.Nombre = value.Nombre;
                search.Descripcion = value.Descripcion;
            }
            context.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveAlbum(int key)
        {
            var search = context.Albums.Where(a => a.AlbumId == key).FirstOrDefault();
            context.Albums.Remove(search);
            context.SaveChanges();
            return Json(key, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveArtista(int key)
        {
            var search = context.Artistas.Where(a => a.ArtistaId == key).FirstOrDefault();
            context.Artistas.Remove(search);
            context.SaveChanges();
            return Json(key, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveGenero(int key)
        {
            var search = context.Generoes.Where(g => g.GeneroId == key).FirstOrDefault();
            context.Generoes.Remove(search);
            context.SaveChanges();
            return Json(key, JsonRequestBehavior.AllowGet);
        }

        private GridProperties ConvertGridObject(string gridProperty)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IEnumerable div = (IEnumerable)serializer.Deserialize(gridProperty, typeof(IEnumerable));
            GridProperties gridProp = new GridProperties();
            foreach (KeyValuePair<string, object> ds in div)
            {
                var property = gridProp.GetType().GetProperty(ds.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (property != null)
                {
                    Type type = property.PropertyType;
                    string serialize = serializer.Serialize(ds.Value);
                    object value = serializer.Deserialize(serialize, type);
                    property.SetValue(gridProp, value, null);
                }
            }
            return gridProp;
        }
    }

    public class DataResultArtista
    {
        public IEnumerable<Artista> result { get; set; }
        public int count { get; set; }
    }

    public class DataResultGenero
    {
        public IEnumerable<Genero> result { get; set; }
        public int count { get; set; }
    }
}
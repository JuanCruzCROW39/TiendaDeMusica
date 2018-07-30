using Syncfusion.EJ.Export;
using Syncfusion.JavaScript.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeMusica.Models;

namespace TiendaDeMusica.Controllers
{
    public class EmpleadoController : Controller
    {
        private TiendaDeMusicaContext context = new TiendaDeMusicaContext();

        // GET: Empleado
        public ActionResult Index()
        {
            ViewBag.Registros = context.Empleados.Count();
            ViewBag.Departamentos = context.Departamentos.ToList();
            ViewBag.Sexo = context.Sexo.ToList();
            ViewBag.EstadoCivil = context.EstadoCivil.ToList();
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Departamentos = context.Departamentos.ToList();
            ViewBag.Sexo = context.Sexo.ToList();
            ViewBag.EstadoCivil = context.EstadoCivil.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId, Nombre, Apellidos, Edad, Direccion, DepartamentoId, Externo, CURP, RFC, Telefono, Email, FechaDeNacimiento, SexoId, EstadoCivilId")]Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departamentos = context.Departamentos.ToList();
            ViewBag.Sexo = context.Sexo.ToList();
            ViewBag.EstadoCivil = context.EstadoCivil.ToList();
            return View(empleado);
        }

        public ActionResult ListaEmpleados()
        {
            ViewBag.Departamentos = context.Departamentos.ToList();
            ViewBag.Sexo = context.Sexo.ToList();
            ViewBag.EstadoCivil = context.EstadoCivil.ToList();
            var model = context.Empleados.Include(e => e.Departamento).Include(e => e.Sexo).Include(e => e.EstadoCivil).ToList();
            return View("ListaEmpleados", model);
        }

        public ActionResult GetEmpleado()
        {
            ViewBag.Departamentos = context.Departamentos.ToList();
            ViewBag.Sexo = context.Sexo.ToList();
            ViewBag.EstadoCivil = context.EstadoCivil.ToList();
            return PartialView("Lista");
        }

        public ActionResult DataEmpleado(Syncfusion.JavaScript.DataManager dm)
        {
            DataResultEmpleado result = new DataResultEmpleado();
            Syncfusion.JavaScript.DataSources.DataOperations dataOperations = new Syncfusion.JavaScript.DataSources.DataOperations();
            result.result = context.Empleados.Include(e => e.Departamento).Include(e => e.Sexo).Include(e => e.EstadoCivil).ToList();
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
            result.count = context.Empleados.Include(e => e.Departamento).Include(e => e.Sexo).Include(e => e.EstadoCivil).AsQueryable().Count();
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

        public ActionResult UpdateEmpleado(Empleado value)
        {
            var search = context.Empleados.Where(e => e.EmpleadoId == value.EmpleadoId).FirstOrDefault();
            if (search != null)
            {
                search.Nombre = value.Nombre;
                search.Apellidos = value.Apellidos;
                search.Edad = value.Edad;
                search.Direccion = value.Direccion;
                search.DepartamentoId = value.DepartamentoId;
                search.Externo = value.Externo;
                search.CURP = value.CURP;
                search.RFC = value.RFC;
                search.Telefono = value.Telefono;
                search.Email = value.Email;
                search.FechaDeNacimiento = value.FechaDeNacimiento;
                search.SexoId = value.SexoId;
                search.EstadoCivilId = value.EstadoCivilId;

                context.SaveChanges();
                return Json(value, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveEmpleado(int key)
        {
            var search = context.Empleados.Where(e => e.EmpleadoId == key).FirstOrDefault();
            if (search != null)
            {
                context.Empleados.Remove(search);
                context.SaveChanges();
                return Json(key, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        public void ExcelEmpleado(string GridModel)
        {
            ExcelExport exp = new ExcelExport();
            var DataSource = context.Empleados.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            obj.Columns[5].DataSource = context.Departamentos.ToList();
            obj.Columns[12].DataSource = context.Sexo.ToList();
            obj.Columns[13].DataSource = context.EstadoCivil.ToList();
            exp.Export(obj, DataSource, "Empleados.xlsx", Syncfusion.XlsIO.ExcelVersion.Excel2010, false, false, "default-theme");
        }

        public void WordEmpleado(string GridModel)
        {
            WordExport exp = new WordExport();
            var DataSource = context.Empleados.ToList();
            GridProperties obj = (GridProperties)Syncfusion.JavaScript.Utils.DeserializeToModel(typeof(GridProperties), GridModel);
            obj.Columns[5].DataSource = context.Departamentos.ToList();
            obj.Columns[12].DataSource = context.Sexo.ToList();
            obj.Columns[13].DataSource = context.EstadoCivil.ToList();
            exp.Export(obj, DataSource, "Empleados.docx", false, false, "default-theme");
        }
    }

    public class DataResultEmpleado
    {
        public IEnumerable<Empleado> result { get; set; }
        public int count { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using panaderia.Models;

namespace panaderia.Controllers
{
    public class ReporteProduccionController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: ReporteProduccion
        public ActionResult Index()
        {
            var produccion = db.produccion.Include(p => p.receta);
            return View(produccion.ToList());
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

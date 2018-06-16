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
    public class produccionsController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: produccions
        public ActionResult Index()
        {
            var produccion = db.produccion.Include(p => p.receta);
            return View(produccion.ToList());
        }

        // GET: produccions
        public ActionResult ReporteKilos()
        {
            var produccion = db.produccion.Include(p => p.receta);
            return View(produccion.ToList());
        }



        // GET: produccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccion.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            return View(produccion);
        }

        // GET: produccions/Create
        public ActionResult Create()
        {
            ViewBag.recetaId = new SelectList(db.receta, "Id", "nombre");
            return View();
        }

        // POST: produccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fecha_produccion,recetaId,valor,cantidad")] produccion produccion)
        {
            if (ModelState.IsValid)
            {
                db.produccion.Add(produccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recetaId = new SelectList(db.receta, "Id", "nombre", produccion.recetaId);
            return View(produccion);
        }

        // GET: produccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccion.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.recetaId = new SelectList(db.receta, "Id", "nombre", produccion.recetaId);
            return View(produccion);
        }

        // POST: produccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fecha_produccion,recetaId,valor,cantidad")] produccion produccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recetaId = new SelectList(db.receta, "Id", "nombre", produccion.recetaId);
            return View(produccion);
        }

        // GET: produccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccion.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            return View(produccion);
        }

        // POST: produccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produccion produccion = db.produccion.Find(id);
            db.produccion.Remove(produccion);
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

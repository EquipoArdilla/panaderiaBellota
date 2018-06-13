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
    public class ViewsController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: Views
        public ActionResult Index()
        {
            return View(db.View.ToList());
        }

        // GET: Views/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View view = db.View.Find(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        // GET: Views/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Views/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,formato,lineaId,familiaId,usuarioId,stock,precio_venta,medidaId")] View view)
        {
            if (ModelState.IsValid)
            {
                db.View.Add(view);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        // GET: Views/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View view = db.View.Find(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        // POST: Views/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,formato,lineaId,familiaId,usuarioId,stock,precio_venta,medidaId")] View view)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Views/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View view = db.View.Find(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        // POST: Views/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            View view = db.View.Find(id);
            db.View.Remove(view);
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

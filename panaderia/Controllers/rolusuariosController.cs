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
    public class rolusuariosController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: rolusuarios
        public ActionResult Index()
        {
            return View(db.rolusuario.ToList());
        }

        // GET: rolusuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rolusuario rolusuario = db.rolusuario.Find(id);
            if (rolusuario == null)
            {
                return HttpNotFound();
            }
            return View(rolusuario);
        }

        // GET: rolusuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rolusuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,rol")] rolusuario rolusuario)
        {
            if (ModelState.IsValid)
            {
                db.rolusuario.Add(rolusuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolusuario);
        }

        // GET: rolusuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rolusuario rolusuario = db.rolusuario.Find(id);
            if (rolusuario == null)
            {
                return HttpNotFound();
            }
            return View(rolusuario);
        }

        // POST: rolusuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,rol")] rolusuario rolusuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolusuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolusuario);
        }

        // GET: rolusuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rolusuario rolusuario = db.rolusuario.Find(id);
            if (rolusuario == null)
            {
                return HttpNotFound();
            }
            return View(rolusuario);
        }

        // POST: rolusuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rolusuario rolusuario = db.rolusuario.Find(id);
            db.rolusuario.Remove(rolusuario);
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

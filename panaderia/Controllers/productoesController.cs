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
    public class productoesController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: productoes
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.familia).Include(p => p.usuario).Include(p => p.medida);
            return View(producto.ToList());
        }

        // GET: productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productoes/Create
        public ActionResult Create()
        {
            ViewBag.familiaId = new SelectList(db.familia, "Id", "nombre");
            ViewBag.usuarioId = new SelectList(db.usuario, "Id", "nombre");
            ViewBag.medidaId = new SelectList(db.medida, "Id", "nombre");
            return View();
        }

        // POST: productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,formato,familiaId,usuarioId,medidaId,precio")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.familiaId = new SelectList(db.familia, "Id", "nombre", producto.familiaId);
            ViewBag.usuarioId = new SelectList(db.usuario, "Id", "nombre", producto.usuarioId);
            ViewBag.medidaId = new SelectList(db.medida, "Id", "nombre", producto.medidaId);
            return View(producto);
        }

        // GET: productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.familiaId = new SelectList(db.familia, "Id", "nombre", producto.familiaId);
            ViewBag.usuarioId = new SelectList(db.usuario, "Id", "nombre", producto.usuarioId);
            ViewBag.medidaId = new SelectList(db.medida, "Id", "nombre", producto.medidaId);
            return View(producto);
        }

        // POST: productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,formato,familiaId,usuarioId,medidaId,precio")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.familiaId = new SelectList(db.familia, "Id", "nombre", producto.familiaId);
            ViewBag.usuarioId = new SelectList(db.usuario, "Id", "nombre", producto.usuarioId);
            ViewBag.medidaId = new SelectList(db.medida, "Id", "nombre", producto.medidaId);
            return View(producto);
        }

        // GET: productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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

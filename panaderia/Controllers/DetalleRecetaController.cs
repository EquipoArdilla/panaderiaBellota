using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using panaderia.Models;


namespace panaderia.Controllers
{
    [Authorize]
    public class DetalleRecetaController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        public ActionResult Index(int? id)
        {
            var data = new CombosSelecciona();
            var recetas = new List<detalle_receta>(); //lista donde poner los registros de db.detalle_receta
            recetas = id == null ? db.detalle_receta.ToList() : db.detalle_receta.Where(r => r.recetaId == id).ToList(); //traigo los datos de db.detalle_receta
            data.producto = db.producto.ToList(); //Obtengo productos para combobox
            data.receta = db.receta.ToList(); //Obtengo receta para combobox
            data.medida = db.medida.ToList(); //Obtengo medida para combobox
            data.detalle_receta = recetas; // array receteta
            data.idSeleccionado = id; //mantengo ID
            ViewBag.id = id;
            return View(data); // muestro data 
        }

        public ActionResult SeleccionaReceta(int id)
        {
            return RedirectToAction("DetalleReceta");
        }

        public ActionResult AgregaReceta(FormCollection f)
        {
            var d = new detalle_receta();
            foreach (var a in f.AllKeys)
            {
                switch (a) // Selecciono input dependiendo el id
                {
                    case "txtReceta":
                        d.recetaId = int.Parse(f[a]);
                        break;
                    case "selectProducto":
                        d.productoId = int.Parse(f[a]);
                        break;
                    case "selectMedida":
                        d.medidaId = int.Parse(f[a]);
                        break;
                    case "txtCantidad":
                        d.cantidad = int.Parse(f[a]);
                        break;
                }
            }
            //Response.Write(d.recetaId);
            //return null;
            try
            {
                // agrego Detalle recetas a la DB
                detalle_receta dr = new detalle_receta();
                dr.cantidad = d.cantidad;
                dr.recetaId = d.recetaId;
                dr.productoId = d.productoId;
                dr.medidaId = d.medidaId;
                db.detalle_receta.Add(dr);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error al Agregar Detalle Receta", e);
            }
            return RedirectToAction("Index", "DetalleReceta", new { id = d.recetaId });
        }
        public ActionResult Eliminar(int productoId, int recetaId) // Captura de datos 
        {
            var dr = new detalle_receta { productoId = productoId, recetaId = recetaId };//db.detalle_receta.Find(productoId, recetaId);
            db.detalle_receta.Attach(dr);
            db.detalle_receta.Remove(dr); //remuevo 
            db.SaveChanges();
            return RedirectToAction("Index", "DetalleReceta", new { id = recetaId });
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
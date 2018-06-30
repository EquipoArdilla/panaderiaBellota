
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using panaderia.Models;
using System.Collections.ObjectModel;
using System.Collections;

namespace panaderia.Controllers
{
    [Authorize]
    public class detalleRecetaController : Controller
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

        public ActionResult AgregaRecetaDetalle(FormCollection f)
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
                int cantidadD = 0;
                // agrego Detalle recetas a la DB
                detalle_receta dr = new detalle_receta();
                producto pr = new producto();
                receta rt = new receta();
                var query = from rtd in db.detalle_receta where rtd.productoId == d.productoId && rtd.recetaId == d.recetaId select rtd.cantidad;
                foreach (int grp in query)
                {
                    cantidadD = grp;
                }
                if (cantidadD != 0) throw new ArgumentException("Producto ya se encuentra registrado");

                rt = db.receta.Find(d.recetaId);
                pr = db.producto.Find(d.productoId);
                dr.cantidad = d.cantidad;
                dr.recetaId = d.recetaId;
                dr.productoId = d.productoId;
                dr.medidaId = pr.medidaId;
                dr.estado = true;
                db.detalle_receta.Add(dr);
                int idReceta = d.recetaId;
                int valor = Convert.ToInt16(rt.costo_receta) + (Convert.ToInt16(d.cantidad) * ((Convert.ToInt16(pr.precio) / Convert.ToInt16(pr.formato))));
                rt.costo_receta = Convert.ToInt16(valor);
                db.SaveChanges();

 
                return RedirectToAction("Index", "DetalleReceta", new { id = d.recetaId });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "DetalleReceta", new { id = d.recetaId, editar=1 });
            }

           


        }
        public ActionResult EliminarInsumo(int productoId, int recetaId) // Captura de datos 
        {
            try
            {
                int recId = recetaId;
                int proId = productoId;
                int cantidadD = 0;
                var dr = new detalle_receta { productoId = productoId, recetaId = recetaId };//db.detalle_receta.Find(productoId, recetaId);   
                producto pr = new producto();
                receta rt = new receta();
                rt = db.receta.Find(recetaId);
                pr = db.producto.Find(productoId);
                db.detalle_receta.Attach(dr);

                var query = from rtd in db.detalle_receta  where rtd.productoId == proId && rtd.recetaId == recId select rtd.cantidad;
                foreach (int grp in query)
                {
                    cantidadD = grp;
                }

                rt.costo_receta = Convert.ToInt16(rt.costo_receta) - (cantidadD * ((Convert.ToInt16(pr.precio) / Convert.ToInt16(pr.formato))));
                db.detalle_receta.Remove(dr); //remuevo 
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error al Eliminar Insumo Receta", e);
            }
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
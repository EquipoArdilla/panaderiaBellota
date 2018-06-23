
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using panaderia.Models;
using panaderia;
using panaderia.Controllers;

namespace panaderia.Tests.Controllers
{


    [TestClass]
    public class ComprasTest
    {
        PanaderiaEntities db = new PanaderiaEntities();

        [TestMethod]
        public void Insercion()
        {
            int cm_originales = db.compra.Count();
            compra cm = new compra();
            cm.Id = cm_originales + 1;
            cm.precio_neto = 2;
            cm.proveedor_rut = 1;
            cm.productoId = 30;
            cm.fecha_compra = DateTime.Today;
            db.compra.Add(cm);
            db.SaveChanges();
            int cm_cambiadas = db.compra.Count();
            Assert.AreEqual(cm_originales + 1, cm_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            compra cm = new compra();
            int cm_compra = 2;
            cm = db.compra.Find(Convert.ToInt16(cm_compra));
            //Prueba de buscar
            Assert.AreEqual(cm.Id, cm_compra);

        }

        [TestMethod]
        public void Edicion()
        {
            int cm_originales = db.compra.Count();
            compra cm = new compra();
            int cm_nombre_reemplazo = 2;
            int cm_nombre_orginal = 3;
            cm = db.compra.Find(Convert.ToInt16(cm_originales));
            cm.proveedor_rut = cm_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(cm.proveedor_rut, cm_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int cm_originales = db.compra.Count();
            compra cm = new compra();
            cm = db.compra.Find(Convert.ToInt16(cm_originales));
            db.compra.Remove(cm);
            db.SaveChanges();
            int cm_cambiadas = db.compra.Count();
            Assert.AreEqual(cm_originales - 1, cm_cambiadas);
        }
    }
}

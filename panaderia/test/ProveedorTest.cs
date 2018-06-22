
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
    public class ProveedorTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Prueba" + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int pr_originales = db.proveedor.Count();
            proveedor pr = new proveedor();
            pr.rut = pr_originales + 1;
            pr.nombre = nombre;
            db.proveedor.Add(pr);
            db.SaveChanges();
            int pr_cambiadas = db.proveedor.Count();
            Assert.AreEqual(pr_originales + 1, pr_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            proveedor pr = new proveedor();
            string nombre_proveedor = nombre;
            int pr_proveedor = db.proveedor.Count();
            pr = db.proveedor.Find(Convert.ToInt16(pr_proveedor));
            //Prueba de buscar
            Assert.AreEqual(pr.nombre, nombre_proveedor);

        }

        [TestMethod]
        public void Edicion()
        {
            int pr_originales = db.proveedor.Count();
            proveedor pr = new proveedor();
            string pr_nombre_reemplazo = nombre_remplazo;
            string pr_nombre_orginal = nombre;
            pr = db.proveedor.Find(Convert.ToInt16(pr_originales));
            pr.nombre = pr_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(pr.nombre, pr_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int pr_originales = db.proveedor.Count();
            proveedor pr = new proveedor();
            pr = db.proveedor.Find(Convert.ToInt16(pr_originales));
            db.proveedor.Remove(pr);
            db.SaveChanges();
            int pr_cambiadas = db.proveedor.Count();
            Assert.AreEqual(pr_originales - 1, pr_cambiadas);
        }
    }
}

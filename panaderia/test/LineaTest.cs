
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
    public class LineaTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Prueba" + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int ln_originales = db.linea.Count();
            linea ln = new linea();
            ln.Id = ln_originales + 1;
            ln.nombre = nombre;
            db.linea.Add(ln);
            db.SaveChanges();
            int ln_cambiadas = db.linea.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            linea ln = new linea();
            string nombre_linea = nombre;
            int ln_linea = db.linea.Count();
            ln = db.linea.Find(Convert.ToInt16(ln_linea));
            //Prueba de buscar
            Assert.AreEqual(ln.nombre, nombre_linea);

        }

        [TestMethod]
        public void Edicion()
        {
            int ln_originales = db.linea.Count();
            linea ln = new linea();
            string ln_nombre_reemplazo = nombre_remplazo;
            string ln_nombre_orginal = nombre;
            ln = db.linea.Find(Convert.ToInt16(ln_originales));
            ln.nombre = ln_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(ln.nombre, ln_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int ln_originales = db.linea.Count();
            linea ln = new linea();
            ln = db.linea.Find(Convert.ToInt16(ln_originales));
            db.linea.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.linea.Count();
            Assert.AreEqual(ln_originales - 1, ln_cambiadas);
        }
    }
}

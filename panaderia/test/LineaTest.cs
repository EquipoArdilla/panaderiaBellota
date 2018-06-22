
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
        string nombre = "Pruebas " + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int rt_originales = db.linea.Count();
            linea rt = new linea();
            rt.Id = rt_originales + 1;
            rt.nombre = nombre;
            db.linea.Add(rt);
            db.SaveChanges();
            int rt_cambiadas = db.linea.Count();
            Assert.AreEqual(rt_originales + 1, rt_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            linea rt = new linea();
            string nombre_linea = nombre;
            int rt_linea = db.linea.Count();
            rt = db.linea.Find(Convert.ToInt16(rt_linea));
            //Prueba de buscar
            Assert.AreEqual(rt.nombre, nombre_linea);

        }

        [TestMethod]
        public void Edicion()
        {
            int rt_originales = db.linea.Count();
            linea rt = new linea();
            string rt_nombre_reemplazo = nombre_remplazo;
            string rt_nombre_orginal = nombre;
            rt = db.linea.Find(Convert.ToInt16(rt_originales));
            rt.nombre = rt_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(rt.nombre, rt_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int rt_originales = db.linea.Count();
            linea rt = new linea();
            rt = db.linea.Find(Convert.ToInt16(rt_originales));
            db.linea.Remove(rt);
            db.SaveChanges();
            int rt_cambiadas = db.linea.Count();
            Assert.AreEqual(rt_originales - 1, rt_cambiadas);
        }
    }
}

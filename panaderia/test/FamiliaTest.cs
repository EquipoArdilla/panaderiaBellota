
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
    public class FamiliaTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Prueba" + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int fm_originales = db.familia.Count();
            familia fm = new familia();
            fm.Id = fm_originales + 1;
            fm.nombre = nombre;
            fm.lineaId = 2;
            db.familia.Add(fm);
            db.SaveChanges();
            int fm_cambiadas = db.familia.Count();
            Assert.AreEqual(fm_originales + 1, fm_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            familia fm = new familia();
            string nombre_familia = nombre;
            int fm_familia = db.familia.Count();
            fm = db.familia.Find(Convert.ToInt16(fm_familia));
            //Prueba de buscar
            Assert.AreEqual(fm.nombre, nombre_familia);

        }

        [TestMethod]
        public void Edicion()
        {
            int fm_originales = db.familia.Count();
            familia fm = new familia();
            string fm_nombre_reemplazo = nombre_remplazo;
            string fm_nombre_orginal = nombre;
            fm = db.familia.Find(Convert.ToInt16(fm_originales));
            fm.nombre = fm_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(fm.nombre, fm_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int fm_originales = db.familia.Count();
            familia fm = new familia();
            fm = db.familia.Find(Convert.ToInt16(fm_originales));
            db.familia.Remove(fm);
            db.SaveChanges();
            int fm_cambiadas = db.familia.Count();
            Assert.AreEqual(fm_originales - 1, fm_cambiadas);
        }
    }
}

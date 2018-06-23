
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
    public class MedidaTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Prueba" + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int md_originales = db.medida.Count();
            medida md = new medida();
            md.Id = md_originales + 1;
            md.nombre = nombre;
            db.medida.Add(md);
            db.SaveChanges();
            int md_cambiadas = db.medida.Count();
            Assert.AreEqual(md_originales + 1, md_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            medida md = new medida();
            string nombre_medida = nombre;
            int md_medida = db.medida.Count();
            md = db.medida.Find(Convert.ToInt16(md_medida));
            //Prueba de buscar
            Assert.AreEqual(md.nombre, nombre_medida);

        }

        [TestMethod]
        public void Edicion()
        {
            int md_originales = db.medida.Count();
            medida md = new medida();
            string md_nombre_reemplazo = nombre_remplazo;
            string md_nombre_orginal = nombre;
            md = db.medida.Find(Convert.ToInt16(md_originales));
            md.nombre = md_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(md.nombre, md_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int md_originales = db.medida.Count();
            medida md = new medida();
            md = db.medida.Find(Convert.ToInt16(md_originales));
            db.medida.Remove(md);
            db.SaveChanges();
            int md_cambiadas = db.medida.Count();
            Assert.AreEqual(md_originales - 1, md_cambiadas);
        }
    }
}

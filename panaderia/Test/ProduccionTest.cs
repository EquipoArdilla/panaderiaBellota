using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using panaderia.Models;
using panaderia.Controllers;
namespace panaderia.Tests.Controllers
{
    [TestClass]
    public class ProduccionTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        DateTime fechaProduccion = DateTime.Today;
        string nombre = "Pruebas " + DateTime.Today;
        int receta = 1;
        int receta_reemplazo = 2;
        decimal canti = 0;
        long costokilo = 0;
        long costoproduccion = 0;
        long ventakilo = 0;
        long totalventa = 0;
        long rentabilidad = 0;

               
        [TestMethod]
        public void Insercion()
        {

            int pr_originales = db.produccion.Count();
            produccion pr = new produccion();
            pr.Id = pr_originales + 1;
            pr.fecha_produccion = fechaProduccion;
            pr.recetaId = receta;
            db.produccion.Add(pr);
            db.SaveChanges();
            int pr_cambiadas = db.produccion.Count();
            Assert.AreEqual(pr_originales + 1, pr_cambiadas);

        }

        [TestMethod]
        public void Busqueda()
        {
            produccion pr = new produccion();
            int pr_cantidad = db.produccion.Count();
            pr = db.produccion.Find(Convert.ToInt16(pr_cantidad));
            int numero_produccion = pr_cantidad;
            //Prueba de buscar
            Assert.AreEqual(pr.Id, numero_produccion);

        }

        [TestMethod]
        public void Edicion()
        {
            int pr_originales = db.produccion.Count();
            produccion pr = new produccion();
            int pr_receta_reemplazo = receta_reemplazo;
            int pr_receta_original = receta;
            pr = db.produccion.Find(Convert.ToInt16(pr_receta_original));
            pr.recetaId = pr_receta_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(pr.recetaId, pr_receta_original);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int pr_originales = db.produccion.Count();
            produccion pr = new produccion();
            pr = db.produccion.Find(Convert.ToInt16(pr_originales));
            db.produccion.Remove(pr);
            db.SaveChanges();
            int pr_cambiadas = db.produccion.Count();
            Assert.AreEqual(pr_originales - 1, pr_cambiadas);
        }
    }
}
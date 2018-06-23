
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
    public class ProductoTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Pruebas " + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int rd_originales = db.producto.Count();
            producto rd = new producto();
            rd.Id = rd_originales + 1;
            rd.nombre = nombre;
            rd.familiaId = 1;
            rd.usuarioId = 1;
            rd.medidaId = 3;
            rd.precio = 200;
            db.producto.Add(rd);
            db.SaveChanges();
            int rd_cambiadas = db.producto.Count();
            Assert.AreEqual(rd_originales + 1, rd_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            producto rd = new producto();
            string nombre_producto = nombre;
            int rd_cantidad = db.producto.Count();
            rd = db.producto.Find(Convert.ToInt16(rd_cantidad));
            //Prueba de buscar
            Assert.AreEqual(rd.nombre, nombre_producto);

        }

        [TestMethod]
        public void Edicion()
        {
            int rd_originales = db.producto.Count();
            producto rd = new producto();
            string rd_nombre_reemplazo = nombre_remplazo;
            string rd_nombre_orginal = nombre;
            rd = db.producto.Find(Convert.ToInt16(rd_originales));
            rd.nombre = rd_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(rd.nombre, rd_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int rd_originales = db.producto.Count();
            producto rd = new producto();
            rd = db.producto.Find(Convert.ToInt16(rd_originales));
            db.producto.Remove(rd);
            db.SaveChanges();
            int rd_cambiadas = db.producto.Count();
            Assert.AreEqual(rd_originales - 1, rd_cambiadas);
        }
    }
}

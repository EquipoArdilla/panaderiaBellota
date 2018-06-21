﻿
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
    public class RecetasTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Pruebas " + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int rt_originales = db.receta.Count();
            receta rt = new receta();
            rt.Id = rt_originales + 1;
            rt.nombre = nombre;
            db.receta.Add(rt);
            db.SaveChanges();
            int rt_cambiadas = db.receta.Count();
            Assert.AreEqual(rt_originales + 1, rt_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            receta rt = new receta();
            string nombre_receta = nombre;
            int rt_cantidad = db.receta.Count();
            rt = db.receta.Find(Convert.ToInt16(rt_cantidad));
            //Prueba de buscar
            Assert.AreEqual(rt.nombre, nombre_receta);

        }

        [TestMethod]
        public void Edicion()
        {
            int rt_originales = db.receta.Count();
            receta rt = new receta();
            string rt_nombre_reemplazo = nombre_remplazo;
            string rt_nombre_orginal = nombre;
            rt = db.receta.Find(Convert.ToInt16(rt_originales));
            rt.nombre = rt_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(rt.nombre, rt_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int rt_originales = db.receta.Count();
            receta rt = new receta();
            rt = db.receta.Find(Convert.ToInt16(rt_originales));
            db.receta.Remove(rt);
            db.SaveChanges();
            int rt_cambiadas = db.receta.Count();
            Assert.AreEqual(rt_originales - 1, rt_cambiadas);
        }
    }
}
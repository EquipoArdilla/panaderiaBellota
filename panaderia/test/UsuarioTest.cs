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
    public class UsuarioTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Prueba" + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int us_originales = db.usuario.Count();
            usuario us = new usuario();
            us.Id = us_originales + 1;
            us.nombre = nombre;
            us.clave = "1234";
            us.rolusuarioId = 1;
            db.usuario.Add(us);
            db.SaveChanges();
            int us_cambiadas = db.usuario.Count();
            Assert.AreEqual(us_originales + 1, us_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            usuario us = new usuario();
            string nombre_usuario = nombre;
            int us_usuario = db.usuario.Count();
            us = db.usuario.Find(Convert.ToInt16(us_usuario));
            //Prueba de buscar
            Assert.AreEqual(us.nombre, nombre_usuario);

        }

        [TestMethod]
        public void Edicion()
        {
            int us_originales = db.usuario.Count();
            usuario us = new usuario();
            string us_nombre_reemplazo = nombre_remplazo;
            string us_nombre_orginal = nombre;
            us = db.usuario.Find(Convert.ToInt16(us_originales));
            us.nombre = us_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(us.nombre, us_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int us_originales = db.usuario.Count();
            usuario us = new usuario();
            us = db.usuario.Find(Convert.ToInt16(us_originales));
            db.usuario.Remove(us);
            db.SaveChanges();
            int us_cambiadas = db.usuario.Count();
            Assert.AreEqual(us_originales - 1, us_cambiadas);
        }
    }
}

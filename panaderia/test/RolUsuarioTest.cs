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
    public class RolUsuarioTest
    {
        PanaderiaEntities db = new PanaderiaEntities();
        string nombre = "Prueba" + DateTime.Today;
        string nombre_remplazo = "Reemplazo " + DateTime.Today;

        [TestMethod]
        public void Insercion()
        {
            int rl_originales = db.rolusuario.Count();
            rolusuario rl = new rolusuario();
            rl.Id = rl_originales + 1;
            rl.rol = nombre;
            db.rolusuario.Add(rl);
            db.SaveChanges();
            int rl_cambiadas = db.rolusuario.Count();
            Assert.AreEqual(rl_originales + 1, rl_cambiadas);
        }

        [TestMethod]
        public void Busqueda()
        {
            rolusuario rl = new rolusuario();
            string nombre_rolusuario = nombre;
            int rl_rolusuario = db.rolusuario.Count();
            rl = db.rolusuario.Find(Convert.ToInt16(rl_rolusuario));
            //Prueba de buscar
            Assert.AreEqual(rl.rol, nombre_rolusuario);

        }

        [TestMethod]
        public void Edicion()
        {
            int rl_originales = db.rolusuario.Count();
            rolusuario rl = new rolusuario();
            string rl_nombre_reemplazo = nombre_remplazo;
            string rl_nombre_orginal = nombre;
            rl = db.rolusuario.Find(Convert.ToInt16(rl_originales));
            rl.rol = rl_nombre_reemplazo;
            db.SaveChanges();
            Assert.AreNotEqual(rl.rol, rl_nombre_orginal);
        }

        [TestMethod]
        public void Eliminacion()
        {
            int rl_originales = db.rolusuario.Count();
            rolusuario rl = new rolusuario();
            rl = db.rolusuario.Find(Convert.ToInt16(rl_originales));
            db.rolusuario.Remove(rl);
            db.SaveChanges();
            int rl_cambiadas = db.rolusuario.Count();
            Assert.AreEqual(rl_originales - 1, rl_cambiadas);
        }
    }
}

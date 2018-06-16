using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using panaderia;
using panaderia.Controllers;

namespace panaderia.Tests.Controllers
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void usuariosIndexNoNulo()
        {
            // Arrange
            usuariosController controller = new usuariosController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
    }
}

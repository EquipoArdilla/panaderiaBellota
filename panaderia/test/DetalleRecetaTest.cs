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
    public class DetalleRecetaTest
    {
        [TestMethod]
        public void BuscoRecetaParaDetalleNoNulo()
        {
            // Arrange
            DetalleRecetaController controller = new DetalleRecetaController();

            // Act
            ViewResult result = controller.Index(2) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
    }
}

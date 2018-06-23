
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
    public class DetalleRecetasControllerTest
    {
        int Id = 0;

        [TestMethod]
        public void Index()
        {
            // Arrange
            detalleRecetaController controller = new detalleRecetaController();

            // Act
            ViewResult result = controller.Index(Id) as ViewResult;

            // Assert
            Assert.IsNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
       
    }
}

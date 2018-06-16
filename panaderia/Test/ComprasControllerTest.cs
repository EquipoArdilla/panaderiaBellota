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
    public class ComprasControllerTest
    {
        [TestMethod]
        public void IndexComprasNoNulo()
        {
            // Arrange
            comprasController controler = new comprasController();

            // Act
            ViewResult result = controler.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
    }
}

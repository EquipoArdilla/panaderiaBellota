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
        public void Index()
        {
            // Arrange
            comprasController controler = new comprasController();

            // Act
            ViewResult result = controler.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            comprasController controler = new comprasController();

            // Act
            ViewResult result = controler.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            comprasController controler = new comprasController();

            // Act
            ViewResult result = controler.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            comprasController controler = new comprasController();

            // Act
            ViewResult result = controler.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
        [TestMethod]
        public void Edit()
        {
            // Arrange
            comprasController controler = new comprasController();

            // Act
            ViewResult result = controler.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
    }
}

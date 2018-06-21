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
    public class RecetasControllerTest
    {
        int Id = 0;
     
        [TestMethod]
        public void Index()
        {
            // Arrange
            recetasController controller = new recetasController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
        [TestMethod]
        public void Details()
        {
            // Arrange
            recetasController controller = new recetasController();

            // Act
            ViewResult result = controller.Details(Id) as ViewResult;

            // Assert
            Assert.IsNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
        [TestMethod]
        public void Create()
        {
            // Arrange
            recetasController controller = new recetasController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
        [TestMethod]
        public void Edit()
        {
            // Arrange
            recetasController controller = new recetasController();

            // Act
            ViewResult result = controller.Edit(Id) as ViewResult;

            // Assert
            Assert.IsNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
        [TestMethod]
        public void Delete()
        {
            // Arrange
            recetasController controller = new recetasController();

            // Act
            ViewResult result = controller.Delete(Id) as ViewResult;

            // Assert
            Assert.IsNull(result);
            //Assert.AreEqual(3,result.ViewBag.id );
        }
       
    }
}

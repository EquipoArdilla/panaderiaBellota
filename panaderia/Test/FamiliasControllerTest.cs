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
    public class FamiliasControllerTest
    {

        int Id = 3;
        [TestMethod]
        public void Index()
        {
            // Arrange
            familiasController controller = new familiasController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            familiasController controller = new familiasController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            familiasController controller = new familiasController();

            // Act
            ViewResult result = controller.Details(Id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            familiasController controller = new familiasController();

            // Act
            ViewResult result = controller.Edit(Id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            familiasController controller = new familiasController();

            // Act
            ViewResult result = controller.Delete(Id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}

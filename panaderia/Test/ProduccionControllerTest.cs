using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using panaderia.Models;
using panaderia.Controllers;
namespace panaderia.Tests.Controllers
{
    [TestClass]
    public class ProduccionTest
    {
        [TestMethod]
        public void Index()
        {

            produccionsController controller = new produccionsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }
        [TestMethod]
        public void Create()
        {

            produccionsController controller = new produccionsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }

        [TestMethod]
        public void Edit()
        {

            produccionsController controller = new produccionsController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }
        [TestMethod]
        public void Details()
        {

            produccionsController controller = new produccionsController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }

        [TestMethod]
        public void Delete()
        {

            produccionsController controller = new produccionsController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }


    }
}

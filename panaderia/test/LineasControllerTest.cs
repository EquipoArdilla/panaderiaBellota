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
    public class LineasControllerTest
    {
        [TestMethod]
        public void PruebaIndexLineas()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }


        [TestMethod]
        public void PruebaCreateLineas()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }


        [TestMethod]
        public void PruebaEditLineas()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Edit(10) as ViewResult;

            // Assert
            //Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);
            //Assert.AreEqual(1,result.ViewBag.id );
            Assert.IsNull(result);
        }


     

    }
}

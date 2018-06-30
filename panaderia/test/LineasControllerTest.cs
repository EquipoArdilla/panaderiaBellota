﻿using System;
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
        int Id = 3;
        //string nombre = "Pruebas ";
        
        [TestMethod]
        public void Index()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Index("") as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }


        [TestMethod]
        public void Create()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);

        }


        [TestMethod]
        public void Edit()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Edit(Id) as ViewResult;

            // Assert
            //Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);
            //Assert.AreEqual(1,result.ViewBag.id );
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Details(Id) as ViewResult;

            // Assert
            //Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);
            //Assert.AreEqual(1,result.ViewBag.id );
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {

            lineasController controller = new lineasController();

            // Act
            ViewResult result = controller.Delete(Id) as ViewResult;

            // Assert
            //Assert.IsNotNull(result);

            //Assert.AreEqual("Details", result.ViewName);
            //Assert.AreEqual(1,result.ViewBag.id );
            Assert.IsNotNull(result);
        }
         





    }
}

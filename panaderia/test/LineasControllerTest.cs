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


     
    }
}
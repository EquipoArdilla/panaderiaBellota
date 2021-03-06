﻿using System;
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
    public class ReporteControllerTEst
    {
        [TestMethod]
        public void PruebaReporteIndexNoNulo()
        {
            // Arrange
            ReporteProduccionController controller = new ReporteProduccionController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            
        }
    }
}

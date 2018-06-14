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
    public class DetalleReceta
    {
        [TestMethod]
        public void PruebaDetalleRecetaBusca()
        {
            DetalleRecetaController controller = new DetalleRecetaController();

            ViewResult result = controller.Index(1) as ViewResult;

            Assert.IsNotNull(result);

        }
    }
}

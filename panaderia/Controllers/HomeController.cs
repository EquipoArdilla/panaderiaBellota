using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using panaderia.Models;

namespace panaderia.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles= "Administrador, Gerente, Bodeguero")]        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(usuario model, string returnUrl)
        {
            PanaderiaEntities db = new PanaderiaEntities();
            var dataItem = db.usuario.Where(x => x.nombre == model.nombre && x.clave == model.clave).First();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.nombre, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                         && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

    }
}
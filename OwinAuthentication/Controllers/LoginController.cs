
using OwinAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Para se autenticar via FormsAuthentication
//Temos que usar o seguinte Namespace:
using System.Web.Security;

namespace OwinAuthentication.Controllers
{
    //COM ESTE ANNOTATION ESTA CONTROLLER NAO ENTRARA NA REGRA DE AUTENTICAÇAP DA GLOBAL.asax
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken] //Validando a origem.
        [HttpPost]
        public ActionResult Index(LoginModel login, string returnUrl)
        {
            return View();
        }

        public ActionResult LogOff() {
            
            return RedirectToAction("Index", "Home");
        }
    }
}
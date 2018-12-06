using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpeCar.BusinessEntities.Seguridad;

namespace OpeCar.OperCar.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Autenticar(ELogin login)
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
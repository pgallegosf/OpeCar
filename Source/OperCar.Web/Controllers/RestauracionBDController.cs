using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpeCar.BusinessEntities.Restauracion;
using OpeCar.BusinessLogic.Service.Restauracion;

namespace OpeCar.OperCar.Web.Controllers
{
    public class RestauracionBDController : Controller
    {
        readonly NRestauracionBD _NRestauracionBD = new NRestauracionBD();
        // GET: RestauracionBD
        public ActionResult Index()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            var rol = System.Web.HttpContext.Current.Session["rolAdmin"];
            if (rol == null) return RedirectToAction("Index", "Aplicacion");
            ViewBag.EsSuperAdmin = rol.ToString().Equals("superAdmin");
            return View();
        }
        [HttpPost]
        public JsonResult RestaurarBaseDatos(ERestauracionBDRequest request)
        {
            request.Usuario = System.Web.HttpContext.Current.Session["userName"].ToString();
            var result = _NRestauracionBD.RestaurarBD(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
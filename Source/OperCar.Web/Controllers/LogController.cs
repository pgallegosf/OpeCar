using System.Web.Mvc;
using OpeCar.BusinessLogic.Service.Seguridad;

namespace OpeCar.OperCar.Web.Controllers
{
    public class LogController : Controller
    {
        readonly NLog _Nlog = new NLog();
        // GET: Log
        public ActionResult Index()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            //ViewBag.EsSuperAdmin = true;
            return View();
        }
        public ActionResult ListarAccesos(int anio)
        {
            var result = _Nlog.ListarAccesos(anio, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
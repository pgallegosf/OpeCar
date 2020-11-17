using System.Web.Mvc;
using OpeCar.BusinessEntities.GestionArchivo;

namespace OpeCar.OperCar.Web.Controllers
{
    public class LogController : Controller
    {
        readonly BusinessLogic.Service.Seguridad.NLog _Nlog = new BusinessLogic.Service.Seguridad.NLog();
        readonly BusinessLogic.Service.GestionDocumental.NLog _NlogDoc = new BusinessLogic.Service.GestionDocumental.NLog();
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
        public ActionResult ReporteLog()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            var requestLog = new ELogRequest();
            var listaLog = _NlogDoc.Listar(requestLog,null);
            return View(listaLog);
        }

    }
}
using System.Web.Mvc;

namespace OpeCar.OperCar.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            ViewBag.Title = "Inicio";
            return View();
        }
    }
}
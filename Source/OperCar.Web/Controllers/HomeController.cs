using System.Web.Mvc;

namespace OpeCar.OperCar.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Inicio";
            return View();
        }
    }
}
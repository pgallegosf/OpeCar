using System.Web.Mvc;
using System.Web.Routing;

namespace OpeCar.OperCar.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Aplicacion",
                url: "Aplicacion",
                defaults: new { controller = "Aplicacion", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

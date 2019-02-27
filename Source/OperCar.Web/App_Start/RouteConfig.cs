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
                name: "Logout",
                url: "Logout",
                defaults: new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Organizacion",
                url: "Organizacion",
                defaults: new { controller = "Organizacion", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SIG",
                url: "SIG",
                defaults: new { controller = "SIG", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "SIGDetalle",
                "SIGDetalle",
                 new { controller = "SIG", action = "SIGDetalle", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "ObtenerFichero",
                "ObtenerFichero",
                 new { controller = "SIG", action = "ObtenerFichero", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "RegistrarSubArea",
                "RegistrarSubArea",
                 new { controller = "SIG", action = "RegistrarSubArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "ListaComboSubArea",
                "ListaComboSubArea",
                 new { controller = "SIG", action = "ListaComboSubArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Aplicacion",
                url: "Aplicacion",
                defaults: new { controller = "Aplicacion", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "AbrirDocumento",
                "AbrirArchivo",
                new { controller = "Aplicacion", action = "AbrirArchivo", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "RegistrarDocumento",
                "RegistrarDocumento",
                 new { controller = "SIG", action = "RegistrarDocumento", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Aplicaciones",
                "Index",
                new { controller = "Aplicacion", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

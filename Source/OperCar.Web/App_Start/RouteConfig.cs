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
                 "Autenticar",
                 "Autenticar",
                 new { controller = "Login", action = "Autenticar", id = UrlParameter.Optional }
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
                url: "SIG/",
                defaults: new { controller = "SIG", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RegistrarArea",
                url: "RegistrarArea",
                defaults: new { controller = "SIG", action = "RegistrarArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditarArea",
                url: "EditarArea",
                defaults: new { controller = "SIG", action = "EditarArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EliminarArea",
                url: "EliminarArea",
                defaults: new { controller = "SIG", action = "EliminarArea", id = UrlParameter.Optional }
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
                 "EditarSubArea",
                "EditarSubArea",
                 new { controller = "SIG", action = "EditarSubArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "EliminarSubArea",
                "EliminarSubArea",
                 new { controller = "SIG", action = "EliminarSubArea", id = UrlParameter.Optional }
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
                 "EliminarDocumento",
                "EliminarDocumento",
                 new { controller = "SIG", action = "EliminarDocumento", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Aplicaciones",
                "Index",
                new { controller = "Aplicacion", action = "Index", id = UrlParameter.Optional }
            );
            //GDocumentaria
            routes.MapRoute(
                name: "GDocumentaria",
                url: "GDocumentaria",
                defaults: new { controller = "GDocumentaria", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 "GDocumentariaDetalle",
                "GDocumentariaDetalle",
                 new { controller = "GDocumentaria", action = "GDocumentariaDetalle", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RegistrarAreaGD",
                url: "RegistrarAreaGD",
                defaults: new { controller = "GDocumentaria", action = "RegistrarArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditarAreaGD",
                url: "EditarAreaGD",
                defaults: new { controller = "GDocumentaria", action = "EditarArea", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EliminarAreaGD",
                url: "EliminarAreaGD",
                defaults: new { controller = "SIG", action = "EliminarAreaGD", id = UrlParameter.Optional }
            );
            //Aplicacion
            routes.MapRoute(
                name: "AplicacionMantenimiento",
                url: "AplicacionMantenimiento",
                defaults: new { controller = "Aplicacion", action = "AplicacionMantenimiento", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RegistrarAplicacion",
                url: "RegistrarAplicacion",
                defaults: new { controller = "Aplicacion", action = "RegistrarAplicacion", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EliminarAplicacion",
                url: "EliminarAplicacion",
                defaults: new { controller = "Aplicacion", action = "EliminarAplicacion", id = UrlParameter.Optional }
            );
            //Seccion
            routes.MapRoute(
                name: "OrganizacionMantenimiento",
                url: "OrganizacionMantenimiento",
                defaults: new { controller = "Organizacion", action = "OrganizacionMantenimiento", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RegistrarOrganizacion",
                url: "RegistrarOrganizacion",
                defaults: new { controller = "Organizacion", action = "RegistrarOrganizacion", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EliminarOrganizacion",
                url: "EliminarOrganizacion",
                defaults: new { controller = "Organizacion", action = "EliminarOrganizacion", id = UrlParameter.Optional }
            );
            //Seguridad
            routes.MapRoute(
                name: "ListarPermisos",
                url: "ListarPermisos",
                defaults: new { controller = "Seguridad", action = "ListarPermisos", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ListarUsuariosAD",
                url: "ListarUsuariosAD",
                defaults: new { controller = "Seguridad", action = "ListarUsuariosAD", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AgregarUsuario",
                url: "AgregarUsuario",
                defaults: new { controller = "Seguridad", action = "AgregarUsuario", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DeshabilitarUsuario",
                url: "DeshabilitarUsuario",
                defaults: new { controller = "Seguridad", action = "DeshabilitarUsuario", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AgregarPermiso",
                url: "AgregarPermiso",
                defaults: new { controller = "Seguridad", action = "AgregarPermiso", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EliminarPermiso",
                url: "EliminarPermiso",
                defaults: new { controller = "Seguridad", action = "EliminarPermiso", id = UrlParameter.Optional }
            );
            //Log
            routes.MapRoute(
                name: "Log",
                url: "Log",
                defaults: new { controller = "Log", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ListarAccesos",
                url: "ListarAccesos",
                defaults: new { controller = "Log", action = "ListarAccesos", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ListarMantenimiento",
               url: "ListarMantenimiento",
               defaults: new { controller = "Organizacion", action = "ListarMantenimiento"}
           );

            routes.MapRoute(
               name: "ListarMenuFooter",
               url: "ListarMenuFooter",
               defaults: new { controller = "Organizacion", action = "ListarMenuFooter"}
           );
        }
    }
}

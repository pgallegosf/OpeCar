using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.BusinessLogic.Service.GestionDocumental;

namespace OpeCar.OperCar.Web.Controllers
{
    public class OrganizacionController : Controller
    {
        readonly NSeccion _Nseccion = new NSeccion();
        // GET: Organizacion
        public ActionResult Index()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            var listaSeccion = _Nseccion.Listar(1, null);
            return View(listaSeccion);
        }
        public ActionResult OrganizacionMantenimiento()
        {

            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            if (rolAdmin == null) return RedirectToAction("Index", "Organizacion");
            var listaSeccion = _Nseccion.Listar(1, null);
            return View(listaSeccion);
        }
        [HttpPost]
        public string RegistrarOrganizacion(HttpPostedFileBase fileImagen, string titulo, int? idOrganizacion, string contenido,int posicion)
        {
            var request = new ESeccionRequest();
            string response;
            string imgEnlace;
            if (fileImagen == null)
            {
                imgEnlace = "";
            }
            else
            {
                string archivo = (fileImagen.FileName);
                string ext = Path.GetExtension(archivo);
                string urlImg = "~/Content/images";
                bool exists = System.IO.Directory.Exists(Server.MapPath(urlImg));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(urlImg));

                urlImg = @"" + urlImg + "\\" + archivo;
                imgEnlace = "/Content/images/" + archivo;
                fileImagen.SaveAs(Server.MapPath(urlImg));
            }
            request.IdSeccion = idOrganizacion;
            request.RutaMultimedia = imgEnlace;
            request.Titulo = titulo;
            request.Contenido = contenido;
            request.Posicion = posicion;
            request.IdUsuario = 1;
            request.IndicadorHabilitado = true;
            request.IdTipoSeccion = 1;
            var result = _Nseccion.Registrar(request, null);
            response = "";
            return response;
        }
        public JsonResult EliminarOrganizacion(ESeccionRequest request)
        {
            request.IdUsuario = 1;
            var result = _Nseccion.Eliminar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
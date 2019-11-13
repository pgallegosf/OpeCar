using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.BusinessLogic.Service.GestionDocumental;

namespace OpeCar.OperCar.Web.Controllers
{
    public class AplicacionController : Controller
    {
        readonly NEnlace _Nenlace = new NEnlace();
        // GET: Aplicacion
        public ActionResult Index()
        {
            
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            var listaEnlace = _Nenlace.Listar(null);
            return View(listaEnlace);
        }
        
        [HttpPost]
        public JsonResult AbrirArchivo(string archivo)
        {

            try { 
            Process p = new Process();
            p.StartInfo.FileName = archivo;
            //"D:\\Afinity\\DQ_PV\\Documentos\\RQ2018-1088_AT.docx";
            p.Start();
            var result = true;

            return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex){
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AplicacionMantenimiento()
        {           
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            if (rolAdmin == null) return RedirectToAction("Index", "Aplicacion");
            var listaEnlace = _Nenlace.Listar(null);
            //ViewBag.EsSuperAdmin = true;
            return View(listaEnlace);
        }
        [HttpPost]
        public string RegistrarAplicacion(HttpPostedFileBase fileImagen, string descripcion, int? idAplicacion, string enlace)
        {
            var request = new EEnlaceRequest();
            string response;
            string imgEnlace;
            if (fileImagen == null)
            {
                imgEnlace =idAplicacion!=null?"": "/Content/images/iconos_ALEATICA-33.png";
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
                //file.SaveAs(Server.MapPath("~/" + urlDocumento));
                fileImagen.SaveAs(Server.MapPath(urlImg));
            }
            request.IdEnlace = idAplicacion;
            request.ImgEnlace = imgEnlace;
            request.Descripcion = descripcion;
            request.UrlEnlace = enlace;
            request.IdUsuario = 1;
            request.IndicadorHabilitado = true;
            var result = _Nenlace.Registrar(request, null);
            response = "";
            return response;
        }
        public JsonResult EliminarAplicacion(EEnlaceRequest request)
        {
            request.IdUsuario = 1;
            var result = _Nenlace.Eliminar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
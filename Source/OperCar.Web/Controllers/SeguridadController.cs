using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpeCar.BusinessEntities.Seguridad;
using OpeCar.BusinessLogic.Service.Seguridad;

namespace OpeCar.OperCar.Web.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            var rol = System.Web.HttpContext.Current.Session["rolAdmin"];
            if (rol == null) return RedirectToAction("Index", "Aplicacion");
            ViewBag.EsSuperAdmin = rol.ToString().Equals("superAdmin");
            var Usuario = new NUsuario();
            var request = new GetUserFilters
            {
                IdRol=0,
                Nombre=""
            };
            var listaUsuario = Usuario.Listar(request, null);
            return View(listaUsuario);
        }
        public JsonResult ListarPermisos(int idUsuario)
        {
            var nPermiso = new NPermiso();
            var result = nPermiso.ListarPermiso(idUsuario, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListarUsuariosAD(string usuario)
        {
            var nUsuario = new NUsuario();
            var result = nUsuario.Buscar(usuario, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AgregarUsuario(EUserAddDto request)
        {
            request.IdUsuarioCreacion = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"].ToString());
            var nUsuario = new NUsuario();
            var result = nUsuario.Agregar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeshabilitarUsuario(int idUsuario)
        {
            var nUsuario = new NUsuario();
            var result = nUsuario.Deshabilitar(idUsuario, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AgregarPermiso(ERolAddDto request)
        {
            request.IdUsuarioCreacion = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"].ToString());
            var nPermiso = new NPermiso();
            var result = nPermiso.Agregar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarPermiso(ERolFilterSearch request)
        {
            var nPermiso = new NPermiso();
            var result = nPermiso.Eliminar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
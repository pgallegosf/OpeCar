using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpeCar.BusinessEntities.Seguridad;
using OpeCar.BusinessLogic.Service.Seguridad;

namespace OpeCar.OperCar.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Autenticar(LoginRequest login)
        {
            var response = true;
            var nLogin = new NLogin();
            var nPermiso= new NPermiso();
            var result = new Object();
            try
            {

            
            var autenticacion = nLogin.Autenticar(login, null);
            

            if (autenticacion.IdUsuario == 0)
            {
                result = new { Success = false, Error = autenticacion.NombreCompleto };
            }
            else
            {
                result = new { Success = true, Data = autenticacion };
                System.Web.HttpContext.Current.Session["userName"] = login.Usuario;
                System.Web.HttpContext.Current.Session["rolUsuario"] = "user";
                if (autenticacion.IdUsuario == null)
                {
                    
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                System.Web.HttpContext.Current.Session["idUser"] = autenticacion.IdUsuario;
                var listaPermisos = nPermiso.ListarPermiso(autenticacion.IdUsuario, null);

                foreach (var item in listaPermisos)
                {
                    if (item.IdRol == 2)
                    {
                        System.Web.HttpContext.Current.Session["rolUsuario"] = "admin";
                    }
                    if (item.IdRol == 3)
                    {
                        System.Web.HttpContext.Current.Session["rolAdmin"] = "superAdmin";
                    }
                }
                
                //List<HeaderServicio> listHeader = new List<HeaderServicio>();
                //listHeader.Add(new HeaderServicio { key = "Authorization", value = autenticacion.Token });
                //AppSession.Current.Header = listHeader;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                result = new {Success = false, Error = ex.Message};
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
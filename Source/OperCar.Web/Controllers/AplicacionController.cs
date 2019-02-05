using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpeCar.OperCar.Web.Controllers
{
    public class AplicacionController : Controller
    {
        // GET: Aplicacion
        public ActionResult Index()
        {
            return View();
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

    }
}
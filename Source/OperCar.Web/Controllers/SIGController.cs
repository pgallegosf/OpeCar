using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Newtonsoft.Json;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.BusinessLogic.Service.GestionDocumental;
using System.Configuration;

namespace OpeCar.OperCar.Web.Controllers
{
    public class SIGController : Controller
    {
        private NArea _Area { get; set; }
        
        // GET: SIG                                                          
        public ActionResult Index()
        {
            //Tomar como ejemplo
             _Area = new NArea();
            var listaArea = _Area.Listar(1, null);
            //var li = listaArea;
            //END ejemplo
            return View(listaArea);
        }
        public ActionResult SIGDetalle(int idArea)
        {
            _Area = new NArea();
            var _SubArea = new NSubArea();
            var _Documento = new NDocumento();
            var area = _Area.Listar(1, null).FirstOrDefault(x => x.IdArea == idArea);
            if (area != null)
            {
                ViewBag.Title = area.Descripcion;
            }

            ViewBag.IdArea= idArea;
            
            var listaDocumento = new List<EDocumento>();
            
            var modelo = new ESubAreaDocumento();
            //modelo.ListaDocumentos = listaDocumento;
            modelo.ListaDocumentos = _Documento.Listar(idArea, null); 
            //modelo.ListaSubAreas = listaSubArea.Where(x=>x.IdArea==idArea).ToList();
            modelo.ListaSubAreas = _SubArea.Listar(idArea, null);

            return View(modelo);
        }
        public ActionResult ObtenerFichero(string urlDoc, string nombreDoc)
        {
            //Aquí convendría validar que id no contenga cosas raras

            string rutaCompleta = Path.Combine(@"", urlDoc);
            return File(rutaCompleta, MimeMapping.GetMimeMapping(rutaCompleta), nombreDoc);
        }

        public JsonResult RegistrarSubArea(ESubAreaRequest request)
        {
            NSubArea _NsubArea= new NSubArea();
            //var idUsuario = AppSession.Current.UsuarioAutenticado.IdUsuario;
            request.IdUsuario = 1;
            request.FechaTransaccion = DateTime.Now;
            //var header = JsonConvert.SerializeObject(AppSession.Current.Header);
            var result = _NsubArea.Registrar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaComboSubArea(ESubAreaRequest request)
        {
            NSubArea _NsubArea = new NSubArea();
            var result = _NsubArea.Listar(request.IdArea, null).Where(x=>x.IdPadre==request.IdPadre).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string RegistrarDocumento(HttpPostedFileBase file, int idSubArea)
        {
            var request = new EDocumentoRequest();
            string response;
            string urlDocumento;
            if (file == null)
            {
                urlDocumento = " ";
            }
            else
            {
                string archivo = (file.FileName).ToLower();
                string ext = Path.GetExtension(archivo);
                string dicoUrl = ConfigurationManager.AppSettings["DiscoUrl"];
                urlDocumento = @""+dicoUrl + idSubArea;
                bool exists = System.IO.Directory.Exists(urlDocumento);

                if (!exists)
                    System.IO.Directory.CreateDirectory(urlDocumento);

                urlDocumento = @""+dicoUrl + idSubArea +"\\"+ archivo;
                //file.SaveAs(Server.MapPath("~/" + urlDocumento));
                file.SaveAs(urlDocumento);
                request.UrlDocumento = urlDocumento;
                request.Descripcion = archivo;
                request.IdSubArea = idSubArea;
                request.IdHistorico = 1;
                if(ext==".pdf"){
                    request.IdTipoDocumento = 1;
                }
                else if (ext == ".doc" || ext == ".docx" || ext == "Docm" || ext == "Dotm" || ext == "Dot")
                {
                    request.IdTipoDocumento = 2;
                }
                else if (ext == ".ppt" || ext == ".pptm" || ext == ".pptx" || ext == ".potx" || ext == ".potm" || ext == ".pot" || ext == ".ppsx")
                {
                    request.IdTipoDocumento = 4;
                }
                else if (ext == ".xlsx" || ext == ".xlsm" || ext == ".xlsb" || ext == ".xltx" || ext == ".xltm" || ext == ".xls" || ext == ".xlt" || ext == ".xml" || ext == ".xlam" || ext == ".xla" || ext == ".xlw" || ext == ".xlr")
                {
                    request.IdTipoDocumento = 3;
                }
                else
                {
                    request.IdTipoDocumento = 5;
                }
            }

            NDocumento _Ndocumento = new NDocumento();
            //var idUsuario = AppSession.Current.UsuarioAutenticado.IdUsuario;
            request.IdUsuario = 1;
            request.FechaTransaccion = DateTime.Now;
            request.IndicadorHabilitado = true;
            //var header = JsonConvert.SerializeObject(AppSession.Current.Header);
            var result = _Ndocumento.Registrar(request, null);
            response = "";
            return response;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.BusinessLogic.Service.GestionDocumental;

namespace OpeCar.OperCar.Web.Controllers
{
    public class OrganizacionController : Controller
    {
        readonly NSeccion _Nseccion = new NSeccion();
        readonly NMantenimiento _NMantenimiento = new NMantenimiento();
        readonly NMenuFooter _NMenuFooter = new NMenuFooter();

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

        public ActionResult Mantenimiento()
        {
            var rolAdmin = System.Web.HttpContext.Current.Session["rolAdmin"];
            ViewBag.EsSuperAdmin = rolAdmin != null && rolAdmin.ToString().Equals("superAdmin");
            if (rolAdmin == null) return RedirectToAction("Index", "Mantenimiento");
            var listaMantenimiento = _NMantenimiento.Listar();
            int mantenimientoId = listaMantenimiento[0].MantenimientoId;
            var listaMenuFooter = _NMenuFooter.Listar(mantenimientoId);
            var eMantMenu = new EMantMenu()
            {
                Mantenimiento = listaMantenimiento,
                MenuFooter = listaMenuFooter
            };
            return View(eMantMenu);
        }
               
        public JsonResult ListarMantenimiento()
        {
            var result = _NMantenimiento.Listar();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarMenuFooter(int mantenimientoId)
        {
            var result = _NMenuFooter.Listar(mantenimientoId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public bool GuardarMantenimiento(EMantenimiento mantenimiento)
        {
            var mantenimientoLogoImage = mantenimiento.MantenimientoLogoImage;
            try
            {
                if (mantenimientoLogoImage != null && mantenimientoLogoImage.ContentLength > 0)
                {
                    string filePath = Server.MapPath("~/Content/images/");
                    string extension = ".png";
                    string fileName = "logo";

                    // Determining file size.
                    int fileSize = mantenimientoLogoImage.ContentLength;

                    // Creating a byte array corresponding to file size.
                    byte[] fileByteArray = new byte[fileSize];

                    // Basic validation for file extension
                    string[] allowedExtension = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };
                    string[] allowedMimeType = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };

                    if (allowedExtension.Contains(extension) && allowedMimeType.Contains(MimeMapping.GetMimeMapping(mantenimientoLogoImage.FileName)))
                    {
                        // Posted file is being pushed into byte array.
                        mantenimientoLogoImage.InputStream.Read(fileByteArray, 0, fileSize);

                        // Uploading properly formatted file to server.
                        mantenimientoLogoImage.SaveAs(filePath + fileName + extension);
                        string json = "";
                        Hashtable resp = new Hashtable();
                        string urlPath = MapURL(filePath) + fileName + extension;

                        // Make the response an json object
                        resp.Add("link", urlPath);
                        json = JsonConvert.SerializeObject(resp);

                        // Clear and send the response back to the browser.
                        Response.Clear();
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.Write(json);
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            mantenimiento.MantenimientoLogoImage = null;

            return _NMantenimiento.Guardar(mantenimiento);
        }

        [HttpPost]
        public bool GuardarMenuFooter(EMenuFooter menuFooter)
        {
            return _NMenuFooter.Guardar(menuFooter);
        }


        [HttpPost]
        public string RegistrarOrganizacion(string titulo, int? idOrganizacion, string contenido, int posicion)
        {
            var request = new ESeccionRequest();
            string response;
            string imgEnlace = "";
            request.IdSeccion = idOrganizacion;
            request.RutaMultimedia = imgEnlace;
            request.Titulo = titulo;
            request.Contenido = contenido;
            request.Posicion = posicion;
            request.IdUsuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"].ToString());
            request.IndicadorHabilitado = true;
            request.IdTipoSeccion = 1;
            var result = _Nseccion.Registrar(request, null);
            response = "";
            return response;
        }

        public JsonResult EliminarOrganizacion(ESeccionRequest request)
        {
            request.IdUsuario = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"].ToString());
            var result = _Nseccion.Eliminar(request, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertImage()
        {
            if (Request.Files["file"] != null)
            {
                HttpPostedFileBase MyFile = Request.Files["file"];

                // Setting location to upload files
                string TargetLocation = Server.MapPath("~/Content/file/froala_editor/");

                try
                {
                    if (MyFile.ContentLength > 0)
                    {
                        // Get File Extension
                        string Extension = Path.GetExtension(MyFile.FileName);

                        // Determining file name. You can format it as you wish.
                        string FileName = Path.GetFileName(MyFile.FileName);
                        FileName = Guid.NewGuid().ToString().Substring(0, 8);

                        // Determining file size.
                        int FileSize = MyFile.ContentLength;

                        // Creating a byte array corresponding to file size.
                        byte[] FileByteArray = new byte[FileSize];

                        // Basic validation for file extension
                        string[] AllowedExtension = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };
                        string[] AllowedMimeType = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };

                        if (AllowedExtension.Contains(Extension) && AllowedMimeType.Contains(MimeMapping.GetMimeMapping(MyFile.FileName)))
                        {
                            // Posted file is being pushed into byte array.
                            MyFile.InputStream.Read(FileByteArray, 0, FileSize);

                            // Uploading properly formatted file to server.
                            MyFile.SaveAs(TargetLocation + FileName + Extension);
                            string json = "";
                            Hashtable resp = new Hashtable();
                            string urlPath = MapURL(TargetLocation) + FileName + Extension;

                            // Make the response an json object
                            resp.Add("link", urlPath);
                            json = JsonConvert.SerializeObject(resp);

                            // Clear and send the response back to the browser.
                            Response.Clear();
                            Response.ContentType = "application/json; charset=utf-8";
                            Response.Write(json);
                            Response.End();
                        }
                        else
                        {
                            // Handle validation errors
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                }
            }
            return View();
        }

        [HttpPost]
        public JsonResult DeleteImage(string filePath)
        {
            string message;
            try
            {               
                string fullPath = Request.MapPath(filePath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath); 
                    message = "success";
                }
                else
                {
                    message = "not_found";
                }
            }
            catch(Exception e)
            {
                message = e.Message.ToString();
            }
            return Json(message, JsonRequestBehavior.AllowGet);

        }

        // Convert file path to url
        // http://stackoverflow.com/questions/16007/how-do-i-convert-a-file-path-to-a-url-in-asp-net
        private string MapURL(string path)
        {
            string appPath = Server.MapPath("/").ToLower();
            return string.Format("/{0}", path.ToLower().Replace(appPath, "").Replace(@"\", "/"));
        }
    }
}
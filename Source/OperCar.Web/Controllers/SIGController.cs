using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using OpeCar.BusinessEntities.GestionArchivo;

namespace OpeCar.OperCar.Web.Controllers
{
    public class SIGController : Controller
    {
        
        public static EDocumento Documento1 = new EDocumento
            {
                IdDocumento = 1,
                ImagenFondo = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Recaudación",
                Archivo = "",
                Tipo = 1,
                Nivel = 1
            };
            public static EDocumento Documento2 = new EDocumento
            {
                IdDocumento = 2,
                ImagenFondo = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Conservación Vial",
                Archivo = "",
                Tipo = 1,
                Nivel = 1
            };
            public  static EDocumento Documento3 = new EDocumento
            {
                IdDocumento = 3,
                ImagenFondo = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Atención al Usuario",
                Archivo = "",
                Tipo = 1,
                Nivel = 1
            };
            public static EDocumento Documento4 = new EDocumento
            {
                IdDocumento = 4,
                ImagenFondo = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Sistemas e Infraestructura de TI",
                Archivo = "",
                Tipo = 1,
                Nivel = 1
            };
        public List<EDocumento> Lista = new List<EDocumento>{Documento1,Documento2,Documento3,Documento4};
        // GET: SIG
        public ActionResult Index()
        {
            

            ViewBag.listaSIG = Lista;
            return View(Lista);
        }
        public ActionResult SIGDetalle( int idDocumento)
        {
            var titulo = Lista.FirstOrDefault(x => x.IdDocumento==idDocumento);
            if (titulo != null)
                ViewBag.Title = titulo.Descripcion;

            ViewBag.IdPadre = idDocumento;
            var lista = new List<EDocumento>();
            var documento1 = new EDocumento
            {
                IdDocumento = 5,
                ImagenFondo = "",
                Descripcion = "Procedimientos",
                Archivo="~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 1
            };
            var documento2 = new EDocumento
            {
                IdDocumento = 6,
                ImagenFondo = "",
                Descripcion = "Instructivos",
                Archivo="~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 1
            };
            var documento3 = new EDocumento
            {
                IdDocumento = 7,
                ImagenFondo = "",
                Descripcion = "Formatos",
                Archivo="~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 1
            };
            var documento4 = new EDocumento
            {
                IdDocumento = 5,
                ImagenFondo = "",
                Descripcion = "Procedimientos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 2
            };
            var documento5 = new EDocumento
            {
                IdDocumento = 6,
                ImagenFondo = "",
                Descripcion = "Instructivos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 2
            };
            var documento6 = new EDocumento
            {
                IdDocumento = 7,
                ImagenFondo = "",
                Descripcion = "Formatos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 2
            };
            var documento7 = new EDocumento
            {
                IdDocumento = 5,
                ImagenFondo = "",
                Descripcion = "Procedimientos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 2
            };
            var documento8 = new EDocumento
            {
                IdDocumento = 6,
                ImagenFondo = "",
                Descripcion = "Instructivos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 2
            };
            var documento9 = new EDocumento
            {
                IdDocumento = 7,
                ImagenFondo = "",
                Descripcion = "Formatos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 2
            };
            var documento10 = new EDocumento
            {
                IdDocumento = 7,
                ImagenFondo = "",
                Descripcion = "procedimiento 1",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 2
            };
            lista.Add(documento1);
            lista.Add(documento2);
            lista.Add(documento3);
            lista.Add(documento4);

            ViewBag.listaSIG = lista;
            return View(lista);
        }
    }
}
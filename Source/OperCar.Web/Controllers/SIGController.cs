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
                IdDocumento = 8,
                ImagenFondo = "",
                Descripcion = "Procedimientos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 2
            };
            var documento5 = new EDocumento
            {
                IdDocumento = 9,
                ImagenFondo = "",
                Descripcion = "Instructivos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 2
            };
            var documento6 = new EDocumento
            {
                IdDocumento = 10,
                ImagenFondo = "",
                Descripcion = "Formatos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 2
            };
            var documento7 = new EDocumento
            {
                IdDocumento = 11,
                ImagenFondo = "",
                Descripcion = "Procedimientos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 3
            };
            var documento8 = new EDocumento
            {
                IdDocumento = 12,
                ImagenFondo = "",
                Descripcion = "Instructivos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 3
            };
            var documento9 = new EDocumento
            {
                IdDocumento = 13,
                ImagenFondo = "",
                Descripcion = "Formatos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 3
            };
            var documento10 = new EDocumento
            {
                IdDocumento = 14,
                ImagenFondo = "",
                Descripcion = "Procedimientos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 4
            };
            var documento11 = new EDocumento
            {
                IdDocumento = 15,
                ImagenFondo = "",
                Descripcion = "Instructivos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 2,
                IdPadre = 4
            };
            var documento12 = new EDocumento
            {
                IdDocumento = 16,
                ImagenFondo = "",
                Descripcion = "Formatos",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 1,
                IdPadre = 4
            };
            var documento13 = new EDocumento
            {
                IdDocumento = 17,
                ImagenFondo = "",
                Descripcion = "Procedimiento 1",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 3,
                IdPadre = 5
            };
            var documento14 = new EDocumento
            {
                IdDocumento = 18,
                ImagenFondo = "",
                Descripcion = "Procedimiento 2",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 3,
                IdPadre = 5
            };
            var documento15 = new EDocumento
            {
                IdDocumento = 19,
                ImagenFondo = "",
                Descripcion = "Instructivo 1",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 1,
                Nivel = 3,
                IdPadre = 6
            };
            var documento16 = new EDocumento
            {
                IdDocumento = 20,
                ImagenFondo = "",
                Descripcion = "Instructivo 2",
                Archivo = "~/Content/images/iconos_ALEATICA-40.png",
                Tipo = 2,
                Nivel = 3,
                IdPadre = 6
            };
            lista.Add(documento1);
            lista.Add(documento2);
            lista.Add(documento3);
            lista.Add(documento4);
            lista.Add(documento5);
            lista.Add(documento6);
            lista.Add(documento7);
            lista.Add(documento8);
            lista.Add(documento9);
            lista.Add(documento10);
            lista.Add(documento11);
            lista.Add(documento12);
            lista.Add(documento13);
            lista.Add(documento14);
            lista.Add(documento15);
            lista.Add(documento16);
            //lista.Add(documento17);
            //lista.Add(documento18);
            //lista.Add(documento19);
            //lista.Add(documento20);

            ViewBag.listaSIG = lista;
            return View(lista);
        }
    }
}
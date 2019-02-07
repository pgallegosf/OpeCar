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

        public static EArea Area = new EArea
            {
                
                IdArea = 1,
                UrlImg = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Recaudación",
                IdTipo = 1
            };
        public static EArea Area1 = new EArea
            {
                IdArea = 2,
                UrlImg = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Conservación Vial",
                IdTipo = 1
            };
        public static EArea Area2 = new EArea
            {
                IdArea = 3,
                UrlImg = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Atención al Usuario",
                IdTipo = 1
            };
        public static EArea Area3 = new EArea
            {
                IdArea = 4,
                UrlImg = "Content/images/iconos_ALEATICA-40.png",
                Descripcion = "Sistemas e Infraestructura de TI",
                IdTipo = 1
            };
        public List<EArea> ListaArea = new List<EArea> { Area,Area1, Area2, Area3 };
        // GET: SIG
        public ActionResult Index()
        {
            //ViewBag.listaSIG = ListaArea;
            return View(ListaArea);
        }
        public ActionResult SIGDetalle(int idArea)
        {
            var titulo = ListaArea.FirstOrDefault(x => x.IdArea == idArea);
            if (titulo != null)
                ViewBag.Title = titulo.Descripcion;

            ViewBag.IdArea= idArea;
            var listaSubArea = new List<ESubArea>();
            var listaDocumento = new List<EDocumento>();
            var area1 = new ESubArea
            {
                IdSubArea = 1,
                IdArea = 1,
                Descripcion = "Procedimientos",
                IdPadre = 1
            };
            var area2 = new ESubArea
            {
                IdSubArea = 2,
                IdArea = 1,
                Descripcion = "Instructivos",
                IdPadre = 1
            };
            var area3 = new ESubArea
            {
                IdSubArea = 3,
                IdArea = 1,
                Descripcion = "Formatos",
                IdPadre = 1
            };
            var area4 = new ESubArea
            {
                IdSubArea = 4,
                IdArea = 2,
                Descripcion = "Procedimientos",
                IdPadre = 2
            };
            var area5 = new ESubArea
            {
                IdSubArea = 5,
                IdArea = 2,
                Descripcion = "Instructivos",
                IdPadre = 2
            };
            var area6 = new ESubArea
            {
                IdSubArea = 6,
                IdArea = 2,
                Descripcion = "Formatos",
                IdPadre = 2
            };
            var area7 = new ESubArea
            {
                IdSubArea = 7,
                IdArea = 3,
                Descripcion = "Procedimientos",
                IdPadre = 3
            };
            var area8 = new ESubArea
            {
                IdSubArea = 8,
                IdArea = 3,
                Descripcion = "Instructivos",
                IdPadre = 3
            };
            var area9 = new ESubArea
            {
                IdSubArea = 9,
                IdArea = 3,
                Descripcion = "Formatos",
                IdPadre = 3
            };
            var area10 = new ESubArea
            {
                IdSubArea = 10,
                IdArea = 4,
                Descripcion = "Procedimientos",
                IdPadre = 4
            };
            var area11 = new ESubArea
            {
                IdSubArea = 11,
                IdArea = 4,
                Descripcion = "Instructivos",
                IdPadre = 4
            };
            var area12 = new ESubArea
            {
                IdSubArea = 12,
                IdArea = 4,
                Descripcion = "Formatos",
                IdPadre = 4
            };
            var documento1 = new EDocumento
            {
                IdDocumento = 1,
                IdSubArea = 1,
                NombreDocumento = "Procedimiento 1",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            var documento2 = new EDocumento
            {
                IdDocumento = 2,
                IdSubArea = 1,
                NombreDocumento = "Procedimiento 2",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            var documento3 = new EDocumento
            {
                IdDocumento = 3,
                IdSubArea = 2,
                NombreDocumento = "Instructivo 1",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            var documento4 = new EDocumento
            {
                IdDocumento = 4,
                IdSubArea = 2,
                NombreDocumento = "Instructivo 2",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            listaSubArea.Add(area1);
            listaSubArea.Add(area2);
            listaSubArea.Add(area3);
            listaSubArea.Add(area4);
            listaSubArea.Add(area5);
            listaSubArea.Add(area6);
            listaSubArea.Add(area7);
            listaSubArea.Add(area8);
            listaSubArea.Add(area9);
            listaSubArea.Add(area10);
            listaSubArea.Add(area11);
            listaSubArea.Add(area12);
            listaDocumento.Add(documento1);
            listaDocumento.Add(documento2);
            listaDocumento.Add(documento3);
            listaDocumento.Add(documento4);
            //lista.Add(documento17);
            //lista.Add(documento18);
            //lista.Add(documento19);
            //lista.Add(documento20);

            ViewBag.listaSubArea = listaSubArea;
            return View(listaDocumento);
        }
    }
}
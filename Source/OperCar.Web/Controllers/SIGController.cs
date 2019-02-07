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
        public static EArea Area4 = new EArea
        {
            IdArea = 5,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Recursos Humanos",
            IdTipo = 1
        };
        public static EArea Area5 = new EArea
        {
            IdArea = 6,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Logística y Almacén",
            IdTipo = 1
        };
        public static EArea Area6 = new EArea
        {
            IdArea = 7,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Seguridad y Salud en el Trabajo",
            IdTipo = 1
        };
        public static EArea Area7 = new EArea
        {
            IdArea = 8,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Gestión Ambiental y Asuntos Sociales",
            IdTipo = 1
        };
        public static EArea Area8 = new EArea
        {
            IdArea = 9,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Sistema Integrado de Gestión",
            IdTipo = 1
        };
        public static EArea Area9 = new EArea
        {
            IdArea = 10,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Estadística y Control de Gestión",
            IdTipo = 1
        };
        public static EArea Area10 = new EArea
        {

            IdArea = 11,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Recaudación",
            IdTipo = 2
        };
        public static EArea Area11 = new EArea
        {
            IdArea = 12,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Conservación Vial",
            IdTipo = 2
        };
        public static EArea Area12 = new EArea
        {
            IdArea = 13,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Atención al Usuario",
            IdTipo = 2
        };
        public static EArea Area13 = new EArea
        {
            IdArea = 14,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Sistemas e Infraestructura de TI",
            IdTipo = 2
        };
        public static EArea Area14 = new EArea
        {
            IdArea = 15,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Recursos Humanos",
            IdTipo = 2
        };
        public static EArea Area15 = new EArea
        {
            IdArea = 16,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Logística y Almacén",
            IdTipo = 2
        };
        public static EArea Area16 = new EArea
        {
            IdArea = 17,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Seguridad y Salud en el Trabajo",
            IdTipo = 2
        };
        public static EArea Area17 = new EArea
        {
            IdArea = 18,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Gestión Ambiental y Asuntos Sociales",
            IdTipo = 2
        };
        public static EArea Area18 = new EArea
        {
            IdArea = 19,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Estadística y Control de Gestión",
            IdTipo = 2
        };
        public static EArea Area19 = new EArea
        {
            IdArea = 20,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Prevención de riesgos, GA, RSE",
            IdTipo = 2
        };
        public static EArea Area20 = new EArea
        {
            IdArea = 21,
            UrlImg = "Content/images/iconos_ALEATICA-40.png",
            Descripcion = "Sistema Integrado de Gestión",
            IdTipo = 2
        };
        public List<EArea> ListaArea = new List<EArea> { Area,Area1, Area2, Area3, Area4, Area5, Area6, Area7, Area8, Area9, Area10, Area11, Area12, Area13, Area14, Area15, Area16, Area17, Area18, Area19, Area20};
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
            var area13 = new ESubArea
            {
                IdSubArea = 13,
                IdArea = 5,
                Descripcion = "Procedimientos",
                IdPadre = 5
            };
            var area14 = new ESubArea
            {
                IdSubArea = 14,
                IdArea = 5,
                Descripcion = "Instructivos",
                IdPadre = 5
            };
            var area15 = new ESubArea
            {
                IdSubArea = 15,
                IdArea = 5,
                Descripcion = "Formatos",
                IdPadre = 5
            };
            var area16 = new ESubArea
            {
                IdSubArea = 16,
                IdArea = 6,
                Descripcion = "Procedimientos",
                IdPadre = 6
            };
            var area17 = new ESubArea
            {
                IdSubArea = 17,
                IdArea = 6,
                Descripcion = "Instructivos",
                IdPadre = 6
            };
            var area18 = new ESubArea
            {
                IdSubArea = 18,
                IdArea = 6,
                Descripcion = "Formatos",
                IdPadre = 6
            };
            var area19 = new ESubArea
            {
                IdSubArea = 19,
                IdArea = 7,
                Descripcion = "Procedimientos",
                IdPadre = 7
            };
            var area20 = new ESubArea
            {
                IdSubArea = 20,
                IdArea = 7,
                Descripcion = "Instructivos",
                IdPadre = 7
            };
            var area21 = new ESubArea
            {
                IdSubArea = 21,
                IdArea = 7,
                Descripcion = "Formatos",
                IdPadre = 7
            };
            var area22 = new ESubArea
            {
                IdSubArea = 22,
                IdArea = 8,
                Descripcion = "Procedimientos",
                IdPadre = 8
            };
            var area23 = new ESubArea
            {
                IdSubArea = 23,
                IdArea = 8,
                Descripcion = "Instructivos",
                IdPadre = 8
            };
            var area24 = new ESubArea
            {
                IdSubArea = 24,
                IdArea = 8,
                Descripcion = "Formatos",
                IdPadre = 8
            };
            var area25 = new ESubArea
            {
                IdSubArea = 25,
                IdArea = 9,
                Descripcion = "Procedimientos",
                IdPadre = 9
            };
            var area26 = new ESubArea
            {
                IdSubArea = 26,
                IdArea = 9,
                Descripcion = "Instructivos",
                IdPadre = 9
            };
            var area27 = new ESubArea
            {
                IdSubArea = 27,
                IdArea = 9,
                Descripcion = "Formatos",
                IdPadre = 9
            };
            var area28 = new ESubArea
            {
                IdSubArea = 28,
                IdArea = 10,
                Descripcion = "Procedimientos",
                IdPadre = 10
            };
            var area29 = new ESubArea
            {
                IdSubArea = 29,
                IdArea = 10,
                Descripcion = "Instructivos",
                IdPadre = 10
            };
            var area30 = new ESubArea
            {
                IdSubArea = 30,
                IdArea = 10,
                Descripcion = "Formatos",
                IdPadre = 10
            };
            var area31 = new ESubArea
            {
                IdSubArea = 31,
                IdArea = 11,
                Descripcion = "Planes",
                IdPadre = 11
            };
            var area32 = new ESubArea
            {
                IdSubArea = 32,
                IdArea = 11,
                Descripcion = "Infornes",
                IdPadre = 11
            };
            var area33 = new ESubArea
            {
                IdSubArea = 33,
                IdArea = 11,
                Descripcion = "Registros",
                IdPadre = 11
            };
            var area34 = new ESubArea
            {
                IdSubArea = 34,
                IdArea = 12,
                Descripcion = "Planes",
                IdPadre = 12
            };
            var area35 = new ESubArea
            {
                IdSubArea = 35,
                IdArea = 12,
                Descripcion = "Infornes",
                IdPadre = 12
            };
            var area36 = new ESubArea
            {
                IdSubArea = 36,
                IdArea = 12,
                Descripcion = "Registros",
                IdPadre = 12
            };
            var area37 = new ESubArea
            {
                IdSubArea = 37,
                IdArea = 13,
                Descripcion = "Planes",
                IdPadre = 13
            };
            var area38 = new ESubArea
            {
                IdSubArea = 32,
                IdArea = 13,
                Descripcion = "Infornes",
                IdPadre = 13
            };
            var area39 = new ESubArea
            {
                IdSubArea = 33,
                IdArea = 13,
                Descripcion = "Registros",
                IdPadre = 13
            };
            var area40 = new ESubArea
            {
                IdSubArea = 40,
                IdArea = 14,
                Descripcion = "Planes",
                IdPadre = 14
            };
            var area41 = new ESubArea
            {
                IdSubArea = 41,
                IdArea = 14,
                Descripcion = "Informes",
                IdPadre = 14
            };
            var area42 = new ESubArea
            {
                IdSubArea = 42,
                IdArea = 14,
                Descripcion = "Registros",
                IdPadre = 14
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
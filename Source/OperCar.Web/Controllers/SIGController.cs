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
        public List<EArea> ListaArea = new List<EArea> { Area,Area1, Area2, Area3, Area4, Area5, Area6, Area7, Area8, Area9};
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
            
            var listaDocumento = new List<EDocumento>();
            var area1 = new ESubArea
            {
                IdSubArea = 1,
                IdArea = 1,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area2 = new ESubArea
            {
                IdSubArea = 2,
                IdArea = 1,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area3 = new ESubArea
            {
                IdSubArea = 3,
                IdArea = 1,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area4 = new ESubArea
            {
                IdSubArea = 4,
                IdArea = 2,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area5 = new ESubArea
            {
                IdSubArea = 5,
                IdArea = 2,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area6 = new ESubArea
            {
                IdSubArea = 6,
                IdArea = 2,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area7 = new ESubArea
            {
                IdSubArea = 7,
                IdArea = 3,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area8 = new ESubArea
            {
                IdSubArea = 8,
                IdArea = 3,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area9 = new ESubArea
            {
                IdSubArea = 9,
                IdArea = 3,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area10 = new ESubArea
            {
                IdSubArea = 10,
                IdArea = 4,
                Descripcion = "Procedimientos",
                EsUltimo = false
            };
            var area12 = new ESubArea
            {
                IdSubArea = 12,
                IdArea = 4,
                Descripcion = "Formatos",
                EsUltimo = false
            };
            var area13 = new ESubArea
            {
                IdSubArea = 13,
                IdArea = 5,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area14 = new ESubArea
            {
                IdSubArea = 14,
                IdArea = 5,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area15 = new ESubArea
            {
                IdSubArea = 15,
                IdArea = 5,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area16 = new ESubArea
            {
                IdSubArea = 16,
                IdArea = 6,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area17 = new ESubArea
            {
                IdSubArea = 17,
                IdArea = 6,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area18 = new ESubArea
            {
                IdSubArea = 18,
                IdArea = 6,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area19 = new ESubArea
            {
                IdSubArea = 19,
                IdArea = 7,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area20 = new ESubArea
            {
                IdSubArea = 20,
                IdArea = 7,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area21 = new ESubArea
            {
                IdSubArea = 21,
                IdArea = 7,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area22 = new ESubArea
            {
                IdSubArea = 22,
                IdArea = 8,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area23 = new ESubArea
            {
                IdSubArea = 23,
                IdArea = 8,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area24 = new ESubArea
            {
                IdSubArea = 24,
                IdArea = 8,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area25 = new ESubArea
            {
                IdSubArea = 25,
                IdArea = 9,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area26 = new ESubArea
            {
                IdSubArea = 26,
                IdArea = 9,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area27 = new ESubArea
            {
                IdSubArea = 27,
                IdArea = 9,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area28 = new ESubArea
            {
                IdSubArea = 28,
                IdArea = 10,
                Descripcion = "Procedimientos",
                EsUltimo = true
            };
            var area29 = new ESubArea
            {
                IdSubArea = 29,
                IdArea = 10,
                Descripcion = "Instructivos",
                EsUltimo = true
            };
            var area30 = new ESubArea
            {
                IdSubArea = 30,
                IdArea = 10,
                Descripcion = "Formatos",
                EsUltimo = true
            };
            var area31 = new ESubArea
            {
                IdSubArea = 31,
                IdArea = 11,
                Descripcion = "Planes",
                EsUltimo = true
            };
            var area32 = new ESubArea
            {
                IdSubArea = 32,
                IdArea = 11,
                Descripcion = "Infornes",
                EsUltimo = true
            };
            var area33 = new ESubArea
            {
                IdSubArea = 33,
                IdArea = 11,
                Descripcion = "Registros",
                EsUltimo = true
            };
            var area34 = new ESubArea
            {
                IdSubArea = 34,
                IdArea = 12,
                Descripcion = "Planes",
                EsUltimo = true
            };
            var area35 = new ESubArea
            {
                IdSubArea = 35,
                IdArea = 12,
                Descripcion = "Infornes",
                EsUltimo = true
            };
            var area36 = new ESubArea
            {
                IdSubArea = 36,
                IdArea = 12,
                Descripcion = "Registros",
                EsUltimo = true
            };
            var area37 = new ESubArea
            {
                IdSubArea = 37,
                IdArea = 13,
                Descripcion = "Planes",
                EsUltimo = true
            };
            var area38 = new ESubArea
            {
                IdSubArea = 32,
                IdArea = 13,
                Descripcion = "Infornes",
                EsUltimo = true
            };
            var area39 = new ESubArea
            {
                IdSubArea = 33,
                IdArea = 13,
                Descripcion = "Registros",
                EsUltimo = true
            };
            var area40 = new ESubArea
            {
                IdSubArea = 40,
                IdArea = 14,
                Descripcion = "Planes",
                EsUltimo = false
            };
            var area41 = new ESubArea
            {
                IdSubArea = 41,
                IdArea = 14,
                Descripcion = "Informes",
                EsUltimo = false
            };
            var area42 = new ESubArea
            {
                IdSubArea = 42,
                IdArea = 14,
                Descripcion = "Registros",
                EsUltimo = false
            };
            //prueba sistemas
            var area43 = new ESubArea
            {
                IdSubArea = 43,
                IdArea = 4,
                Descripcion = "2018",
                IdPadre = 10,
                EsUltimo = true
            };
            var area44 = new ESubArea
            {
                IdSubArea = 44,
                IdArea = 4,
                Descripcion = "2019",
                IdPadre = 10,
                EsUltimo = true
            };
            //end pruebas sistemas
            var listaSubArea = new List<ESubArea> { area1, area2, area3, area4, area5, area6, area7, area8, area9, area10, area12, area13, area14, area15, area16, area17, area18, area19, area20, area21, area22, area23, area24, area25, area26, area27, area28, area29, area30, area31, area32, area33, area34, area35, area36, area37, area38, area39, area40, area41, area42, area43, area44 };

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

            //pruebas docu sistemas
            var documento5 = new EDocumento
            {
                IdDocumento = 5,
                IdSubArea = 43,
                NombreDocumento = "Procedimientos 1-2018",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            var documento6 = new EDocumento
            {
                IdDocumento = 6,
                IdSubArea = 43,
                NombreDocumento = "Procedimientos 2-2018",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            var documento7 = new EDocumento
            {
                IdDocumento = 7,
                IdSubArea = 44,
                NombreDocumento = "Procedure 1-2019",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            var documento8 = new EDocumento
            {
                IdDocumento = 8,
                IdSubArea = 44,
                NombreDocumento = "Procedure 2-2019",
                UrlDocumento = "~/Content/images/iconos_ALEATICA-40.png",
                Extencion = "pdf"
            };
            //end pruebas docu sistemas
            
            
            listaDocumento.Add(documento1);
            listaDocumento.Add(documento2);
            listaDocumento.Add(documento3);
            listaDocumento.Add(documento4);
            listaDocumento.Add(documento5);
            listaDocumento.Add(documento6);
            listaDocumento.Add(documento7);
            listaDocumento.Add(documento8);
            //lista.Add(documento17);
            //lista.Add(documento18);
            //lista.Add(documento19);
            //lista.Add(documento20);
            var modelo = new ESubAreaDocumento();
            modelo.ListaDocumentos = listaDocumento;
            modelo.ListaSubAreas = listaSubArea.Where(x=>x.IdArea==idArea).ToList();

            return View(modelo);
        }
    }
}
using System;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EEnlaceResponse
    {
        public int IdEnlace { get; set; }
        public string Descripcion { get; set; }
        public string UrlEnlace { get; set; }
        public string ImgEnlace { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

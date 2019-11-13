using System;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class ESeccionResponse
    {
        public int IdSeccion { get; set; }
        public short IdTipoSeccion { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string RutaMultimedia { get; set; }
        public int? Posicion { get; set; }
    }
}

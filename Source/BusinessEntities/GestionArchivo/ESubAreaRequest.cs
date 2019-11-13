using System;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class ESubAreaRequest:Base<int?>
    {
        public int IdArea { get; set; }
        public int? IdPadre { get; set; }
        public int IdHistorial { get; set; }
        public bool EsUltimo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}

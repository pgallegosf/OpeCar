using System;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class ELog
    {
        public long IDLog { get; set; }
        public string Usuario { get; set; }
        public string TipoLog { get; set; }
        public string Funcion { get; set; }
        public string RegistroLog { get; set; }
        public string RequestLog { get; set; }
        public DateTime FechaLog { get; set; }
    }
}

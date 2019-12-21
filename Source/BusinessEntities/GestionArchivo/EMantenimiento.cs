using System;
using System.Web;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EMantenimiento
    {
        public int MantenimientoId { get; set; }
        public string MantenimientoLogo { get; set; }
        public string MantenimientoMenuFooter { get; set; }
        public string MantenimientoSobreNosotros { get; set; }
        public string MantenimientoDerechosReservados { get; set; }
        public string MantenimientoTelefono { get; set; }
        public DateTime MantenimientoFechaActualizacion { get; set; }
        public HttpPostedFileBase MantenimientoLogoImage { get; set; }
    }
}

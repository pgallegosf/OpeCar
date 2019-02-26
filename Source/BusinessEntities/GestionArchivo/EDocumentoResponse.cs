using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EDocumentoResponse:Base<int>
    {
        public int IdSubArea { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdHistorico { get; set; }
        public string UrlDocumento { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public int FechaModificaciom { get; set; }
        public bool IndicadorHabilitado { get; set; }
    }
}

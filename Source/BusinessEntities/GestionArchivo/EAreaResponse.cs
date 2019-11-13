using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EAreaResponse
    {
        public int IdArea { get; set; }
        public int IdTipoArea { get; set; }
        public string UrlImg { get; set; }
        public string Descripcion { get; set; }
        public int IdHistorial { get; set; }
    }
}

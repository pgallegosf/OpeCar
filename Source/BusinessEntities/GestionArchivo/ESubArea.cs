using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class ESubArea
    {
        public int IdSubArea { get; set; }
        public int IdArea { get; set; }
        public int IdPadre { get; set; }
        public string Descripcion { get; set; }

    }
}

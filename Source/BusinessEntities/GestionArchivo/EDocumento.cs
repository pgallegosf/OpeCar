using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EDocumento
    {
        public int IdDocumento { get; set; }
        public string ImagenFondo { get; set; }
        public string Descripcion { get; set; }
        public string Archivo { get; set; }
        public int Tipo { get; set; }
        public int Nivel { get; set; }
        public int? IdPadre { get; set; }
    }
}

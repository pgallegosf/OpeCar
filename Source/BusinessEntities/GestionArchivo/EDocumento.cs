﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeCar.BusinessEntities.GestionArchivo
{
    public class EDocumento
    {
        public int IdDocumento { get; set; }
        public int IdSubArea { get; set; }
        public string NombreDocumento { get; set; }
        public string Extencion { get; set; }
        public string UrlDocumento { get; set; }
    }
}

using System;

namespace OpeCar.BusinessEntities.Seguridad
{
    public class EAcceso
    {
        public string NombreUsuario { get; set; }
        public int Periodo { get; set; }
        public int TotalVisitas { get; set; }
        public string Mes
        {
            get { return Enum.GetName(typeof(EnumMeses), Periodo); }

        }
    }
}

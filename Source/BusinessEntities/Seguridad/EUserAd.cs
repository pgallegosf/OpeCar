using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeCar.BusinessEntities.Seguridad
{
    public class EUserAd
    {
        public string Usuario { get; set; }
        public string NombreCuenta { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Compania { get; set; }
        public string Iniciales { get; set; }
        public DateTime? FechaExpiracionCuenta { get; set; }
        public DateTime? FechaExpiracionContrasena { get; set; }
        public DateTime? FechaCuentaBloqueada { get; set; }
        public DateTime? FechaUltimaConfiguracionContrasena { get; set; }
        public string Path { get; set; }
        public string Categoria { get; set; }
        public bool Bloquado
        {
            get { return FechaCuentaBloqueada.HasValue; }
        }
        public bool CuentaVencida
        {
            get { return FechaExpiracionCuenta.HasValue && FechaExpiracionCuenta <= DateTime.Now; }
        }
        public bool ContrasenaVencida
        {
            get { return FechaExpiracionContrasena.HasValue && FechaExpiracionContrasena <= DateTime.Now; }
        }
        public bool Autenticado { get; set; }
    }
}

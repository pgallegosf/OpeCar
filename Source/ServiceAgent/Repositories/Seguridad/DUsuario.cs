using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.BusinessEntities.Seguridad;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.Seguridad
{
    public class DUsuario
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EUserAd> Buscar(string usuario, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Usuario_Buscar");
            var metodoComplete = string.Format(metodo, usuario);

            return CallApiRest.Get<List<EUserAd>>(urlBase, metodoComplete, headers);
        }
        public List<EUserDto> Listar(GetUserFilters request, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Usuario_Listar");
            return CallApiRest.Post<List<EUserDto>, GetUserFilters>(request, urlBase, metodo, headers);
        }
        public bool Agregar(EUserAddDto request, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Usuario_Agregar");
            return CallApiRest.Post<bool, EUserAddDto>(request, urlBase, metodo, headers);
        }
        public bool Deshabilitar(int idUsuario, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Usuario_Deshabilitar");
            var metodoComplete = string.Format(metodo, idUsuario);

            return CallApiRest.Get<bool>(urlBase, metodoComplete, headers);
        }
    }
}

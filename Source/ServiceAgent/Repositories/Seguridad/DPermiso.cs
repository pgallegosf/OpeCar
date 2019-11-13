using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LP.Util.Web;
using OpeCar.BusinessEntities.Seguridad;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.Seguridad
{
    public class DPermiso
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EPermiso> ListarPermiso(int? idUsuario, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Usuario_ListarPermiso");
            var metodoComplete = string.Format(metodo, idUsuario);

            return CallApiRest.Get<List<EPermiso>>(urlBase, metodoComplete, headers);
        }
        public bool Agregar(ERolAddDto request, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Permiso_Agregar");
            return CallApiRest.Post<bool, ERolAddDto>(request, urlBase, metodo, headers);
        }
        public bool Eliminar(ERolFilterSearch request, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Permiso_Eliminar");
            return CallApiRest.Post<bool, ERolFilterSearch>(request, urlBase, metodo, headers);
        }
    }
}

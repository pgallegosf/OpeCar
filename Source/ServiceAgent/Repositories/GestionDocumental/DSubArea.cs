using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DSubArea
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<ESubAreaResponse> Listar(int idArea, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "SubArea_Listar");
            var metodoComplete = string.Format(metodo, idArea);

            return CallApiRest.Get<List<ESubAreaResponse>>(urlBase, metodoComplete, headers);
        }
        public bool Registrar(ESubAreaRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "SubArea_Registrar");
            return CallApiRest.Post<bool, ESubAreaRequest>(request, urlBase, metodo, headers);
        }
        public bool Editar(ESubAreaRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "SubArea_Editar");
            return CallApiRest.Post<bool, ESubAreaRequest>(request, urlBase, metodo, headers);
        }
        public bool Eliminar(ESubAreaRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "SubArea_Eliminar");
            return CallApiRest.Post<bool, ESubAreaRequest>(request, urlBase, metodo, headers);
        }

    }
}

using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DEnlace
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EEnlaceResponse> Listar(string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Enlace_Listar");
            var metodoComplete = string.Format(metodo);

            return CallApiRest.Get<List<EEnlaceResponse>>(urlBase, metodoComplete, headers);
        }
        public bool Registrar(EEnlaceRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Enlace_Registrar");
            return CallApiRest.Post<bool, EEnlaceRequest>(request, urlBase, metodo, headers);
        }
        public bool Eliminar(EEnlaceRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Enlace_Eliminar");
            return CallApiRest.Post<bool, EEnlaceRequest>(request, urlBase, metodo, headers);
        }
    }
}

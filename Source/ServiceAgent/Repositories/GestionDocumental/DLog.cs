using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;


namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DLog
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public bool Registrar(ELogRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Log_Registrar");
            return CallApiRest.Post<bool, ELogRequest>(request, urlBase, metodo, headers);
        }
        public List<ELog> Listar(ELogRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Log_Listar");
            return CallApiRest.Post<List<ELog>, ELogRequest>(request, urlBase, metodo, headers);
        }
    }
}

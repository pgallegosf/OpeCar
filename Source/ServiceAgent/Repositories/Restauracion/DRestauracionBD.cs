using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.Restauracion;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.Restauracion
{
    public class DRestauracionBD
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public ERestauracionBDResponse RestaurarBD(ERestauracionBDRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("Restauracion");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Restauracion_RestaurarBD");
            return CallApiRest.Post<ERestauracionBDResponse, ERestauracionBDRequest>(request, urlBase, metodo, headers);
        }
    }
}

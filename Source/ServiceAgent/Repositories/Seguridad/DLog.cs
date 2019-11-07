using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.Seguridad;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.Seguridad
{
    public class DLog
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EAcceso> ListarAccesos(int anio, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seguridad_Log_ListarAccesos");
            var metodoComplete = string.Format(metodo, anio);

            return CallApiRest.Get<List<EAcceso>>(urlBase, metodoComplete, headers);
        
        }
    }
}

using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DMantenimiento
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EMantenimiento> Listar()
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Mantenimiento_Listar");
            var metodoComplete = string.Format(metodo);

            return CallApiRest.Get<List<EMantenimiento>>(urlBase, metodoComplete);
        }

        public bool Guardar(EMantenimiento request)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Mantenimiento_Guardar");
            var metodoComplete = string.Format(metodo);
            return CallApiRest.Post<bool, EMantenimiento>(request, urlBase, metodoComplete, null);
        }
    }
}

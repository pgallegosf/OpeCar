using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DSeccion
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<ESeccionResponse> Listar(int idTipo, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seccion_Listar");
            var metodoComplete = string.Format(metodo, idTipo);

            return CallApiRest.Get<List<ESeccionResponse>>(urlBase, metodoComplete, headers);
        }
        public bool Registrar(ESeccionRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seccion_Registrar");
            return CallApiRest.Post<bool, ESeccionRequest>(request, urlBase, metodo, headers);
        }
        public bool Eliminar(ESeccionRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Seccion_Eliminar");
            return CallApiRest.Post<bool, ESeccionRequest>(request, urlBase, metodo, headers);
        }
    }
}

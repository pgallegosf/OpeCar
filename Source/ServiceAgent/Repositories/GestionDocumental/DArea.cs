using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DArea
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EAreaResponse> Listar(int? idUsuario,int idTipo, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Area_Listar");
            var metodoComplete = string.Format(metodo,idUsuario, idTipo);

            return CallApiRest.Get<List<EAreaResponse>>(urlBase, metodoComplete, headers);
        }
        public bool Registrar(EAreaRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Area_Registrar");
            return CallApiRest.Post<bool, EAreaRequest>(request, urlBase, metodo, headers);
        }
        public bool Editar(EAreaRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Area_Editar");
            return CallApiRest.Post<bool, EAreaRequest>(request, urlBase, metodo, headers);
        }
        public bool Eliminar(EAreaRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Area_Eliminar");
            return CallApiRest.Post<bool, EAreaRequest>(request, urlBase, metodo, headers);
        }
    }
}

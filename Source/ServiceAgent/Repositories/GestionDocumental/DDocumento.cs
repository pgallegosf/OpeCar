using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DDocumento
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EDocumentoResponse> Listar(int idArea, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Documento_Listar");
            var metodoComplete = string.Format(metodo, idArea);

            return CallApiRest.Get<List<EDocumentoResponse>>(urlBase, metodoComplete, headers);
        }
        public bool Registrar(EDocumentoRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Documento_Registrar");
            return CallApiRest.Post<bool, EDocumentoRequest>(request, urlBase, metodo, headers);
        }
        public bool Eliminar(int idDocumento, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Documento_Eliminar");
            var metodoComplete = string.Format(metodo, idDocumento);

            return CallApiRest.Get<bool>(urlBase, metodoComplete, headers);
        }
    }
}

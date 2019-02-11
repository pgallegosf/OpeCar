using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DArea
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EAreaResponse> Listar(int idTipo, string headers)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Area_Listar");
            var metodoComplete = string.Format(metodo, idTipo);

            return CallApiRest.Get<List<EAreaResponse>>(urlBase, metodoComplete, headers);
        }
    }
}

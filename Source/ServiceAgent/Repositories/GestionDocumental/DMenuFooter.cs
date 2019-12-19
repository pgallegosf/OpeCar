using System.Collections.Generic;
using LP.Util.Web;
using OpeCar.BusinessEntities.GestionArchivo;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.GestionDocumental
{
    public class DMenuFooter
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public List<EMenuFooter> Listar(int mantenimientoId)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Mantenimiento_ListarMenuFooter");
            var metodoComplete = string.Format(metodo, mantenimientoId);

            return CallApiRest.Get<List<EMenuFooter>>(urlBase, metodoComplete);
        }

        public bool Guardar(EMenuFooter request)
        {
            var service = _utilEndPoint.GetService("GestionDocumental");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Mantenimiento_GuardarMenuFooter");
            var metodoComplete = string.Format(metodo);
            return CallApiRest.Post<bool, EMenuFooter>(request, urlBase, metodoComplete, null);
        }
    }
}

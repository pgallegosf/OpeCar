using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    public class NLog
    {
        readonly DLog _filter = new DLog();
        public bool Registrar(ELogRequest request, string headers)
        {
            return _filter.Registrar(request, headers);
        }
        public List<ELog> Listar(ELogRequest request, string headers)
        {
            return _filter.Listar(request, headers);
        }
    }
}

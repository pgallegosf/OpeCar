using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    public class NEnlace
    {
        readonly DEnlace _filter = new DEnlace();
        public List<EEnlaceResponse> Listar(string headers)
        {
            return _filter.Listar(headers);

        }
        public bool Registrar(EEnlaceRequest request, string headers)
        {
            return _filter.Registrar(request, headers);
        }
        public bool Eliminar(EEnlaceRequest request, string headers)
        {
            return _filter.Eliminar(request, headers);
        }
    }
}

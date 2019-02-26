using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    
    public class NArea
    {
        readonly DArea _filter = new DArea();
        public List<EAreaResponse> Listar(int idTipoArea, string headers)
        {
            return _filter.Listar(idTipoArea, headers);

        }
        public bool Registrar(EAreaRequest request, string headers)
        {
            return _filter.Registrar(request, headers);
        }
    }
}

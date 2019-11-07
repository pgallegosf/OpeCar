using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    public class NSeccion
    {
        readonly DSeccion _filter = new DSeccion();
        public List<ESeccionResponse> Listar(int idTipoArea, string headers)
        {
            return _filter.Listar(idTipoArea, headers);

        }
        public bool Registrar(ESeccionRequest request, string headers)
        {
            return _filter.Registrar(request, headers);
        }
        public bool Eliminar(ESeccionRequest request, string headers)
        {
            return _filter.Eliminar(request, headers);
        }
    }
}

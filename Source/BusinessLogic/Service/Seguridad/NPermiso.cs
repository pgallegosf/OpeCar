using System.Collections.Generic;
using OpeCar.BusinessEntities.Seguridad;
using OpeCar.ServiceAgent.Repositories.Seguridad;

namespace OpeCar.BusinessLogic.Service.Seguridad
{
    public class NPermiso
    {
        readonly DPermiso _filter = new DPermiso();
        public List<EPermiso> ListarPermiso(int? idUsuario, string headers)
        {
            return _filter.ListarPermiso(idUsuario, headers);
        }
        public bool Agregar(ERolAddDto request, string headers)
        {
            return _filter.Agregar(request, headers);
        }
        public bool Eliminar(ERolFilterSearch request, string headers)
        {
            return _filter.Eliminar(request, headers);
        }
    }
}

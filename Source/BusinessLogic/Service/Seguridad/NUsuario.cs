using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpeCar.BusinessEntities.Seguridad;
using OpeCar.ServiceAgent.Repositories.Seguridad;

namespace OpeCar.BusinessLogic.Service.Seguridad
{
    public class NUsuario
    {
        readonly DUsuario _filter = new DUsuario();
        public List<EUserAd> Buscar(string usuario, string headers)
        {
            return _filter.Buscar(usuario, headers);
        }
        public List<EUserDto> Listar(GetUserFilters request, string headers)
        {
            return _filter.Listar(request, headers);
        }
        public bool Agregar(EUserAddDto request, string headers)
        {
            return _filter.Agregar(request, headers);
        }
        public bool Deshabilitar(int idUsuario, string headers)
        {
            return _filter.Deshabilitar(idUsuario, headers);
        }
    }
}

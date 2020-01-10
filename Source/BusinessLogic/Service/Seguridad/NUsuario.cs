using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public List<EListaPermisos> ListarPermisoDetalle(int idUsuario, int idRol, string headers)
        {
            var listarPermisoDetalle=_filter.ListarPermisoDetalle(idUsuario, idRol, headers);
            var listaResponse = listarPermisoDetalle.ListaAreas.Where(l => l.LlavePadre == null)
                .Select(l => new EListaPermisos
                {
                    id = l.Llave,
                    text = l.Descripcion,
                    @checked = l.Habilitado,
                    //population = l.Population,
                    //flagUrl = l.FlagUrl,
                    children = GetChildren(listarPermisoDetalle.ListaAreas, l.Llave)
                }).ToList();
            return listaResponse;
        }
        public bool RegistrarPermisoDetalle(int idUsuario, int idRol, List<int> checkedIds,int idUsuarioTransaccion, string headers)
        {
            
            var requestPermiso = new EPermisoDetalle
            {
                IdRol = idRol,
                IdUsuario = idUsuario,
                IdUsuarioTransanccion = idUsuarioTransaccion,
                ListaAreas = new List<EPermisoAreas>()
            };
            var listarPermisoDetalle = _filter.ListarPermisoDetalle(idUsuario, idRol, headers);
            foreach (var item in listarPermisoDetalle.ListaAreas)
            {
                item.Habilitado = checkedIds.Contains(item.Llave);
            }
            requestPermiso.ListaAreas = listarPermisoDetalle.ListaAreas.Where(x => x.EstadoDatos && x.LlavePadre != null).ToList();
            return _filter.RegistrarPermisoDetalle(requestPermiso, headers);
        }
        private List<EListaPermisos> GetChildren(List<EPermisoAreas> listaPermisoArea, int parentId)
        {
            return listaPermisoArea.Where(l => l.LlavePadre == parentId)
                .Select(l => new EListaPermisos
                {
                    id = l.Llave,
                    text = l.Descripcion,
                    @checked = l.Habilitado,
                    children = GetChildren(listaPermisoArea, l.Llave)
                }).ToList();
        }
    }
}

﻿using System.Collections.Generic;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    
    public class NArea
    {
        readonly DArea _filter = new DArea();
        public List<EAreaResponse> Listar(int? idUsuario,int idTipoArea, string headers)
        {
            return _filter.Listar(idUsuario,idTipoArea, headers);

        }
        public bool Registrar(EAreaRequest request, string headers)
        {
            return _filter.Registrar(request, headers);
        }
        public bool Editar(EAreaRequest request, string headers)
        {
            return _filter.Editar(request, headers);
        }
        public bool Eliminar(EAreaRequest request, string headers)
        {
            return _filter.Eliminar(request, headers);
        }
    }
}

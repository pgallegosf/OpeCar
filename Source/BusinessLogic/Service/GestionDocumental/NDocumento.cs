using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    public class NDocumento
    {
        readonly DDocumento _filter = new DDocumento();
        public List<EDocumentoResponse> Listar(int idArea, string headers)
        {
            return _filter.Listar(idArea, headers);

        }
        public bool Registrar(EDocumentoRequest request, string headers)
        {
            return _filter.Registrar(request, headers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpeCar.BusinessEntities.GestionArchivo;
using OpeCar.ServiceAgent.Repositories.GestionDocumental;

namespace OpeCar.BusinessLogic.Service.GestionDocumental
{
    
    public class NArea
    {
        DArea _filterArea = new DArea();
        public List<EAreaResponse> Listar(int idTipoArea, string headers)
        {
            return _filterArea.Listar(idTipoArea, headers);

        }
    }
}

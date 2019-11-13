using System.Collections.Generic;
using System.Linq;
using OpeCar.BusinessEntities.Seguridad;
using OpeCar.ServiceAgent.Repositories.Seguridad;

namespace OpeCar.BusinessLogic.Service.Seguridad
{
    public class NLog
    {
        readonly DLog _filter = new DLog();
        public List<EAcceso> ListarAccesos(int anio, string headers)
        {
            return _filter.ListarAccesos(anio, headers).OrderBy(x=>x.Periodo).ToList();
        }
    }
}

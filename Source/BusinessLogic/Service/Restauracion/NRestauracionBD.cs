using OpeCar.BusinessEntities.Restauracion;
using OpeCar.ServiceAgent.Repositories.Restauracion;

namespace OpeCar.BusinessLogic.Service.Restauracion
{
   public class NRestauracionBD
    {
        readonly DRestauracionBD _filter = new DRestauracionBD();
        public ERestauracionBDResponse RestaurarBD(ERestauracionBDRequest request, string headers)
        {
            return _filter.RestaurarBD(request, headers);
        }
    }
}

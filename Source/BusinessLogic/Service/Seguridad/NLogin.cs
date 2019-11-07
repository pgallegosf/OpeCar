using OpeCar.BusinessEntities.Seguridad;
using OpeCar.ServiceAgent.Repositories.Seguridad;

namespace OpeCar.BusinessLogic.Service.Seguridad
{
    public class NLogin
    {
        readonly DLogin _filter = new DLogin();
        public UserDto Autenticar(LoginRequest request, string headers)
        {
            return _filter.Autenticar(request, headers);
        }
    }
}

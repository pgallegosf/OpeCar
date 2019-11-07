using LP.Util.Web;
using OpeCar.BusinessEntities.Seguridad;
using Rest;

namespace OpeCar.ServiceAgent.Repositories.Seguridad
{
    public class DLogin
    {
        private readonly UtilEndPoint _utilEndPoint = new UtilEndPoint();
        public UserDto Autenticar(LoginRequest request, string headers)
        {
            var service = _utilEndPoint.GetService("Seguridad");
            var urlBase = service.Url;
            var metodo = _utilEndPoint.GetMethod(service, "Login_Autenticar");
            return CallApiRest.Post<UserDto, LoginRequest>(request, urlBase, metodo, headers);
        }
    }
}

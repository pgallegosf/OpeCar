using Microsoft.Owin;
using OpeCar.OperCar.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OpeCar.OperCar.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

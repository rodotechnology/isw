using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(clinicaOdontologicaMVC.Startup))]
namespace clinicaOdontologicaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

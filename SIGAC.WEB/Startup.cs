using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIGAC.WEB.Startup))]
namespace SIGAC.WEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

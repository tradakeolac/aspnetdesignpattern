using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETPatterns.Chap8.FrontController.UI.Web.Startup))]
namespace ASPNETPatterns.Chap8.FrontController.UI.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

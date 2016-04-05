using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETPatterns.Chap7.Library.UI.Web.Startup))]
namespace ASPNETPatterns.Chap7.Library.UI.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

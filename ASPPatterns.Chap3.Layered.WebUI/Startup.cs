using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPPatterns.Chap3.Layered.WebUI.Startup))]
namespace ASPPatterns.Chap3.Layered.WebUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

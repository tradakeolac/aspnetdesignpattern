using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agathas.Storefront.UI.Web.Mvc.Startup))]
namespace Agathas.Storefront.UI.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

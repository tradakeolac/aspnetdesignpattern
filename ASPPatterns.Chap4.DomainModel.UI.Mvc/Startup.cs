using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPPatterns.Chap4.DomainModel.UI.Mvc.Startup))]
namespace ASPPatterns.Chap4.DomainModel.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

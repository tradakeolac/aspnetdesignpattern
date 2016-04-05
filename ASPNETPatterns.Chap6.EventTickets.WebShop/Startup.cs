using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETPatterns.Chap6.EventTickets.WebShop.Startup))]
namespace ASPNETPatterns.Chap6.EventTickets.WebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace ASPNETPatterns.Chap6.EventTickets.WebShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

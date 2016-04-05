using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Navigation
{
    public class PageNavigator : IPageNavigator
    {
        public void NavigateTo(PageDirectory page)
        {
            switch(page)
            {
                case PageDirectory.Home:
                    HttpContext.Current.Server.Transfer("~/Views/Home/Index.aspx");
                    break;
                case PageDirectory.ProductDetail:
                    HttpContext.Current.Server.Transfer("~/Views/Product/ProductDetail.aspx");
                    break;
                case PageDirectory.CategoryProducts:
                    HttpContext.Current.Server.Transfer("~/Views/Product/CategoryProducts.aspx");
                    break;
                case PageDirectory.MissingPage:
                    HttpContext.Current.Server.Transfer("~/Views/Shared/404.aspx");
                    break;
            }
        }
    }
}

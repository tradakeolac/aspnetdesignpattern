using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Request
{
    public class WebRequestFactory : IWebRequestFactory
    {
        public WebRequest CreateFrom(HttpContext context)
        {
            WebRequest request = new WebRequest();
            request.RequestUrl = context.Request.Url.ToString();
            request.QueryArguments = context.Request.QueryString;

            return request;
        }
    }
}

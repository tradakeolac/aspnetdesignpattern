using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Request
{
    public interface IWebRequestFactory
    {
        WebRequest CreateFrom(HttpContext context);
    }
}

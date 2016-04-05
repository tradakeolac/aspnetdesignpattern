using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Agathas.Storefront.Core.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string resource) =>
            $"{HttpContext.Current.Request.Url.Scheme}" +
            $"://{HttpContext.Current.Request.ServerVariables["HTTP_HOST"]}" +
            (HttpContext.Current.Request.ApplicationPath.Equals("/")
            ? string.Empty 
            : HttpContext.Current.Request.ApplicationPath) +
            resource;
    }
}

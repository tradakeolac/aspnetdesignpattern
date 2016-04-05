using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Request
{
    public class WebRequest
    {
        public string RequestUrl { get; set; }
        public NameValueCollection QueryArguments { get; set; }
    }
}

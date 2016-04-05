using ASPNETPatterns.Chap8.FrontController.Controller.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Routing
{
    public class Route
    {
        private string _route;

        public Route(string route)
        {
            this._route = route;
        }

        public bool Matches(WebRequest request)
        {
            return request.RequestUrl.ToLower().Contains(this._route.ToLower());
        }

        public string Url { get { return this._route; } }
    }
}

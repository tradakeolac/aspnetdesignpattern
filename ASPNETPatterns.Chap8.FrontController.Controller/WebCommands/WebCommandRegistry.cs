using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap8.FrontController.Controller.Request;

namespace ASPNETPatterns.Chap8.FrontController.Controller.WebCommands
{
    public class WebCommandRegistry : IWebCommandRegistry
    {
        private IList<IWebCommand> _webCommands = new List<IWebCommand>();

        public WebCommandRegistry()
        {
            
        }

        public IWebCommand GetCommandFor(WebRequest request)
        {
            throw new NotImplementedException();
        }


    }
}

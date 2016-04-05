using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap8.FrontController.Controller.Request;
using ASPNETPatterns.Chap8.FrontController.Controller.Navigation;
using ASPNETPatterns.Chap8.FrontController.Controller.ActionCommands;
using ASPNETPatterns.Chap8.FrontController.Controller.Routing;

namespace ASPNETPatterns.Chap8.FrontController.Controller.WebCommands
{
    public class WebCommand : IWebCommand
    {
        private IPageNavigator _navigator;
        private List<IActionCommand> _actionCommands;
        private Route _route;
        private PageDirectory _page;

        public WebCommand(IPageNavigator navigator, List<IActionCommand> actionCommands,
            Route route, PageDirectory page)
        {
            this._navigator = navigator;
            this._actionCommands = actionCommands;
            this._route = route;
            this._page = page;
        }

        public bool CanHandle(WebRequest webRequest)
        {
            return this._route.Matches(webRequest);
        }

        public void Process(WebRequest webRequest)
        {
            this._actionCommands.ForEach(cmd => cmd.Process(webRequest));
            this._navigator.NavigateTo(this._page);
        }
    }
}

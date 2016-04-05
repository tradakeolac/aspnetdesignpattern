using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Navigation
{
    public interface IPageNavigator
    {
        void NavigateTo(PageDirectory page);
    }
}

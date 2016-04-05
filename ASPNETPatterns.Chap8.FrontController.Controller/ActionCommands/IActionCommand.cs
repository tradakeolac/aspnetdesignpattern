using ASPNETPatterns.Chap8.FrontController.Controller.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.ActionCommands
{
    public interface IActionCommand
    {
        void Process(WebRequest request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Storage
{
    public static class ViewStorageFactory
    {
        public static IViewStorage GetStorage()
        {
            return new ViewStorage();
        }
    }
}

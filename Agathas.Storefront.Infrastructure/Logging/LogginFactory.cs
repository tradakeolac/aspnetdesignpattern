using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Logging
{
    public class LogginFactory
    {
        private static ILogger _logger;
        public static void InitializeLogFactory(ILogger logger) => _logger = logger;

        public static ILogger GetLogger() => _logger;
    }
}

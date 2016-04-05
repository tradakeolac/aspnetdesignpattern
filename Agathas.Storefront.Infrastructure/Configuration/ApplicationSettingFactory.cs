using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Configuration
{
    public class ApplicationSettingFactory
    {
        private static IApplicationSettings _applicationSettings;
        public static void InitializeApplicationSettingFactory(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings() => _applicationSettings;
    }
}

using Agathas.Storefront.Core.Configuration;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _logger;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            this._logger = LogManager.GetLogger(ApplicationSettingFactory.GetApplicationSettings().LoggerName);
        }

        public void Log(string message) => this._logger.Info(message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Logging;

namespace Mozu.Api.Sample.Logging
{
    public class Log4NetServiceFactory : ILoggingServiceFactory
    {
        public ILoggingService GetLoggingService()
        {
            return new Log4NetService();
        }

        public Log4NetServiceFactory()
        {
            log4net.Config.BasicConfigurator.Configure();
        }
    }
}

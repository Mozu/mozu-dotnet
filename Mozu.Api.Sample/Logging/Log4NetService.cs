using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Logging;
using log4net;
using LogManager = log4net.LogManager;

namespace Mozu.Api.Sample.Logging
{
    public class Log4NetService : ILoggingService
    {
        private Log4NetLogger GetLogger(ILog log)
        {
            return new Log4NetLogger(log);
        }

        public ILogger LoggerFor(Type type)
        {
            return GetLogger(LogManager.GetLogger(type));
        }

    }
}

using System;
using log4net;
using Mozu.Api.Logging;
using LogManager = log4net.LogManager;

namespace Mozu.Api.ToolKit.Logging
{
    public class Log4NetService : ILoggingService
    {
        private Log4NetLogger GetLogger(ILog log)
        {
            return new Log4NetLogger(log);
        }

        #region Implementation of ILoggingService


        public ILogger LoggerFor(Type type)
        {
            return GetLogger(LogManager.GetLogger(type));
        }
        #endregion

    }
}

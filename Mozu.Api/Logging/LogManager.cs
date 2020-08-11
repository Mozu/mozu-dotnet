using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Logging
{
    public static class LogManager
    {
        private static  DefaultLogger defaultLogger;
        public static ILoggingService LoggingService { get; set; }

        static LogManager()
        {
            defaultLogger = new DefaultLogger(); 
        }

        public static ILogger GetLogger(Type type)
        {
            return LoggingService == null ? defaultLogger : LoggingService.LoggerFor(type);
        }
    }
}

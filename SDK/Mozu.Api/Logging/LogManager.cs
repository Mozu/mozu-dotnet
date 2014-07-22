using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Logging
{
    public class LogManager
    {
        public static ILoggingService LoggingService { get; set; }

        public static ILogger GetLogger(Type type)
        {
            return LoggingService == null ? new DefaultLogger() : LoggingService.LoggerFor(type);
        }
    }
}

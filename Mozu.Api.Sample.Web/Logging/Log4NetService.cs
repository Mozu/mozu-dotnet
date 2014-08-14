using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Mozu.Api.Logging;
using log4net;
using LogManager = log4net.LogManager;

namespace Mozu.Api.Sample.Web.Logging
{
    public class Log4NetService : ILoggingService
    {

        public Log4NetService()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var log4netConfig = ConfigurationManager.AppSettings["log4net"];
            var log4netFile = new FileInfo(Path.Combine(Path.GetDirectoryName(path),log4netConfig));
            
            log4net.Config.XmlConfigurator.ConfigureAndWatch(log4netFile);
        }

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

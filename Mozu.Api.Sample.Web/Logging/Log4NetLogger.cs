using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using ILogger = Mozu.Api.Logging.ILogger;


namespace Mozu.Api.Sample.Web.Logging
{
    public class Log4NetLogger : ILogger
    {
        private static ILog _log;
        
        public Log4NetLogger(ILog log)
        {
            _log = log;
        }


        public bool IsInfoEnabled { get { return _log.IsInfoEnabled; } }
        public bool IsWarnEnabled { get { return _log.IsWarnEnabled; } }
        public bool IsDebugEnabled { get { return _log.IsDebugEnabled; } }
        public bool IsErrorEnabled { get { return _log.IsErrorEnabled; } }
        public bool IsFatalEnabled { get { return _log.IsFatalEnabled; } }

        public Task Info(object message, Exception ex = null, object properties = null)
        {
            _log.Info(message, ex);
            return null;
        }


        public Task Warn(object message, Exception ex = null, object properties = null)
        {
            _log.Warn(message, ex);
            return null;
        }

        public Task Debug(object message, Exception ex = null, object properties = null)
        {
            _log.Debug(message, ex);
            return null;
        }


        public Task Error(object message, Exception ex = null, object properties = null)
        {
            _log.Error(message, ex);
            return null;
        }

        public Task Fatal(object message, Exception ex = null, object properties = null)
        {
            _log.Fatal(message, ex);
            return null;
        }


       

    }
}

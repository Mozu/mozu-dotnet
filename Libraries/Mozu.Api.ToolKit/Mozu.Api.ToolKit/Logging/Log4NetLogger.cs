using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using ILogger = Mozu.Api.Logging.ILogger;

namespace Mozu.Api.ToolKit.Logging
{
    public class Log4NetLogger : ILogger
    {
        private static ILog _log;
        private readonly static Type DeclaringType = typeof(Log4NetLogger);

        private log4net.Core.ILogger Logger { get; set; }
        public Log4NetLogger(ILog log)
        {
            _log = log;
            Logger = _log.Logger;
        }


        public Task Info(object message, Exception ex = null, object properties = null)
        {
            var loggingEvent = CreateLoggingEvent(message, ex, Level.Info);
           LogEvent(loggingEvent, properties);
           return null;
        }

        public Task Warn(object message, Exception ex = null, object properties = null)
        {
            var loggingEvent = CreateLoggingEvent(message,ex, Level.Warn);
            LogEvent(loggingEvent, properties); 
            return null;
        }

        public Task Debug(object message, Exception ex = null, object properties = null)
        {
            var loggingEvent = CreateLoggingEvent(message, ex, Level.Debug);
            LogEvent(loggingEvent, properties); 
           return null;
        }

        

        public Task Error(object message, Exception ex = null, object properties = null)
        {
          //_log.Error(message, ex);

            var loggingEvent = CreateLoggingEvent(message, ex, Level.Error);
            LogEvent(loggingEvent, properties);
          return null;
        }

        public Task Fatal(object message, Exception ex = null, object properties = null)
        {
            var loggingEvent = CreateLoggingEvent(message, ex, Level.Fatal);
            LogEvent(loggingEvent, properties); 
            return null;
        }

        public bool IsInfoEnabled { get { return _log.IsInfoEnabled; } }
        public bool IsWarnEnabled { get { return _log.IsWarnEnabled; } }
        public bool IsDebugEnabled { get { return _log.IsDebugEnabled; } }
        public bool IsErrorEnabled { get { return _log.IsErrorEnabled; } }
        public bool IsFatalEnabled { get { return _log.IsFatalEnabled; } }


        private LoggingEvent CreateLoggingEvent(object message, Exception ex, Level errorLevel)
        {
            if (ex == null && message is Exception)
            {
                ex = message as Exception;
                message = "An Exception occurred:";
            }

            var mozuCorrId = (ex != null && ex.GetType() == typeof (ApiException)
                ? "Mozu CorrId " + ((ApiException) ex).CorrelationId
                : string.Empty);
            if (Trace.CorrelationManager.ActivityId != Guid.Empty)
                message = string.Format("{0} {1} {2}", Trace.CorrelationManager.ActivityId, mozuCorrId,  message);

            var logEvent =
                new LoggingEvent(DeclaringType, Logger.Repository, Logger.Name, errorLevel, message, ex);
            return logEvent;
        }

        private void LogEvent(LoggingEvent logEvent, object properties)
        {
            AddEventProperties(logEvent, properties);
            if (logEvent.ExceptionObject is ApiException)
            {
                AddEventProperties(logEvent, logEvent.ExceptionObject);
                AddEventProperties(logEvent, ((ApiException)logEvent.ExceptionObject).ApiContext);
                AddEventProperties(logEvent, ((ApiException)logEvent.ExceptionObject).ExceptionDetail);
                AddEventProperties(logEvent, ((ApiException)logEvent.ExceptionObject).Items);
            }
            
            Logger.Log(logEvent);
        }

        
        private static void AddEventProperties(LoggingEvent logEvent, object properties)
        {
            if (properties == null) return;

            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(properties))
            {
                var obj = propertyDescriptor.GetValue(properties);
                if (obj != null)
                    logEvent.Properties[propertyDescriptor.Name] = obj;
            }

        }
    }
}

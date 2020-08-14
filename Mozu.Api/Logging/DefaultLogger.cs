using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Logging
{
    public  class DefaultLogger : ILogger
    {
        public bool IsInfoEnabled { get; set; }
        public bool IsWarnEnabled { get; set; }
        public bool IsDebugEnabled { get; set; }
        public bool IsErrorEnabled { get; set; }
        public bool IsFatalEnabled { get; set; }

        public void Info(object message, Exception ex = null, object properties = null)
        {
            if(IsInfoEnabled)
            Console.WriteLine(message);
		}

        public void Warn(object message, Exception ex = null, object properties = null)
        {
            if (IsWarnEnabled)
			Console.WriteLine(message);
		}

        public void Debug(object message, Exception ex = null, object properties = null)
        {
            if(IsDebugEnabled)
			 Console.WriteLine(message);
		}

        public void Error(object message, Exception ex = null, object properties = null)
        {
            if(IsErrorEnabled)
            {
                if (message.GetType() == typeof(Exception))
                    ex = (Exception)message;
                if (ex != null)
                    message = String.Format("{0}, {1}", message, ex.StackTrace);
                Console.WriteLine(message);
            }
			
		}

        public void Fatal(object message, Exception ex = null, object properties = null)
        {
            if(IsFatalEnabled)
			 Console.WriteLine(message);
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Logging
{
    public class DefaultLogger : ILogger
    {
        public bool IsInfoEnabled { get { return true; }  }
        public bool IsWarnEnabled { get { return true; } }
        public bool IsDebugEnabled { get { return true; } }
        public bool IsErrorEnabled { get { return true; } }
        public bool IsFatalEnabled { get { return true; } }

        public void Info(object message, Exception ex = null, object properties = null)
        {
            Console.WriteLine(message);
		}

        public void Warn(object message, Exception ex = null, object properties = null)
        {
			Console.WriteLine(message);
		}

        public void Debug(object message, Exception ex = null, object properties = null)
        {
			 Console.WriteLine(message);
		}

        public void Error(object message, Exception ex = null, object properties = null)
        {
			Console.WriteLine(message);
		}

        public void Fatal(object message, Exception ex = null, object properties = null)
        {
			 Console.WriteLine(message);
		}
    }
}

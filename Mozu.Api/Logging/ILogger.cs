using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Logging
{
    public interface ILogger
    {
        bool IsInfoEnabled { get; set; }
        bool IsWarnEnabled { get; set; }
        bool IsDebugEnabled { get; set; }
        bool IsErrorEnabled { get; set; }
        bool IsFatalEnabled { get; set; }

        void Info(object message, Exception ex = null, object properties = null);
        void Warn(object message, Exception ex = null, object properties = null);
        void Debug(object message, Exception ex = null, object properties = null);
        void Error(object message, Exception ex = null, object properties = null);
        void Fatal(object message, Exception ex = null, object properties = null);
    }
}

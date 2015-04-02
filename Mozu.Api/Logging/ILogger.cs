using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Logging
{
    public interface ILogger
    {
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        Task Info(object message, Exception ex = null, object properties = null);
        Task Warn(object message, Exception ex = null, object properties = null);
        Task Debug(object message, Exception ex = null, object properties = null);
        Task Error(object message, Exception ex = null, object properties = null);
        Task Fatal(object message, Exception ex = null, object properties = null);
    }
}

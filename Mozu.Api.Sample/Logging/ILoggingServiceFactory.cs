using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Logging;

namespace Mozu.Api.Sample.Logging
{
    public interface ILoggingServiceFactory
    {
        ILoggingService GetLoggingService();
    }
}

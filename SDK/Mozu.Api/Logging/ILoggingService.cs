using System;

namespace Mozu.Api.Logging
{
    public interface ILoggingService
    {
        ILogger LoggerFor(Type type);
    }
}

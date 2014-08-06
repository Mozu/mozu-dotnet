using Mozu.Api.Logging;

namespace Mozu.Integrations.Common.Logging
{
    public interface ILoggingServiceFactory
    {
        ILoggingService GetLoggingService();
    }
}

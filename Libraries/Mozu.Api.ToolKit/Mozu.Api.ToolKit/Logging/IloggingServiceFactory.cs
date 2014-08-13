using Mozu.Api.Logging;

namespace Mozu.Api.ToolKit.Logging
{
    public interface ILoggingServiceFactory
    {
        ILoggingService GetLoggingService();
    }
}

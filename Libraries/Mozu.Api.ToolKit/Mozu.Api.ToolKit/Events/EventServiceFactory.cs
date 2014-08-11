using Mozu.Api.Events;
using Mozu.Api.Logging;

namespace Mozu.Api.ToolKit.Events
{
    public class EventServiceFactory : IEventServiceFactory
    {
        private readonly ILogger _logger = LogManager.GetLogger(typeof (EventServiceFactory));
        private readonly IEventService _eventService;
        public EventServiceFactory(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IEventService GetEventService()
        {
            return _eventService;
        }
    }
}

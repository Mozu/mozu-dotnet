using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Mozu.Api.Contracts.Event;
using Mozu.Api.Events;
using Mozu.Api.Logging;
using Mozu.Api.Resources.Commerce.Settings;

namespace Mozu.Api.ToolKit.Events
{
    public class EventService : IEventService
    {
        private readonly ILogger _logger = LogManager.GetLogger(typeof(EventService));
        private readonly IComponentContext _container;

        public EventService(IComponentContext container)
        {
            _container = container;
        }

        public async Task ProcessEventAsync(IApiContext apiContext, Event eventPayLoad)
        {
            Trace.CorrelationManager.ActivityId = !String.IsNullOrEmpty(apiContext.CorrelationId) ? Guid.Parse(apiContext.CorrelationId) : Guid.NewGuid();

            _logger.Info(String.Format("Got Event {0} for tenant {1}", eventPayLoad.Topic, apiContext.TenantId));


            var eventType = eventPayLoad.Topic.Split('.');
            var topic = eventType[0];

            if (topic != "application" && !IsAppEnabled(apiContext).Result)
            {
                _logger.Info("App is not enabled, skipping processing of event");
                return;
            }

            if (String.IsNullOrEmpty(topic))
                throw new ArgumentException("Topic cannot be null or empty");

            var eventCategory = (EventCategory)(Enum.Parse(typeof(EventCategory), topic, true));
            var eventProcessor = _container.ResolveKeyed<IEventProcessor>(eventCategory);
            await eventProcessor.ProcessAsync(_container, apiContext, eventPayLoad);

        }

        private async Task<bool> IsAppEnabled(IApiContext apiContext)
        {
            var applicationResource = new ApplicationResource(apiContext);
            var application = await applicationResource.ThirdPartyGetApplicationAsync();

            return application.Enabled.GetValueOrDefault(false);
        }

    }

}

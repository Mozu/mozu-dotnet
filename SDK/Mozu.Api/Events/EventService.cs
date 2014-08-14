using System;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using Mozu.Api.Config.Event;
using Mozu.Api.Contracts.Event;

namespace Mozu.Api.Events
{
    public interface IEventService
    {
        Task ProcessEventAsync(IApiContext apiContext, Event eventPayLoad);
    }

    public class EventService : IEventService
    {
        public async Task ProcessEventAsync(IApiContext apiContext, Event eventPayLoad)
        {
            var eventConfigSection = ConfigurationManager.GetSection("eventSection") as EventSection;

            if (eventConfigSection == null)
                throw new Exception("Events are not configured");

            var eventType = eventPayLoad.Topic.Split('.');

            var topic = eventType[0];
            var action = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(eventType[1]);

            var entityConfigElement = eventConfigSection.Events[topic];

            if (entityConfigElement == null)
                throw new Exception("CorrelationId:{0},No Registered module found for " + topic);
            var type = entityConfigElement.Type;


            await InvokeMethod(type, action, apiContext, eventPayLoad);
        }

        private async Task InvokeMethod(string type, string action, IApiContext apiContext, Event mzEvent)
        {
            var assemblyType = Type.GetType(type);

            if (assemblyType == null)
                throw new Exception("Method : " + type + " could not be loaded");

            var typeConstructor = assemblyType.GetConstructor(Type.EmptyTypes);

            if (typeConstructor == null)
                throw new Exception("Method : Default constructor not be found for type " + type);

            var typeObject = typeConstructor.Invoke(new Object[] { });

            var methodInfo = assemblyType.GetMethod(action + "Async", BindingFlags.IgnoreCase | BindingFlags.Public);

            if (methodInfo == null)
                throw new Exception("Method : " + action + " not found in " + type);
            await (Task)methodInfo.Invoke(typeObject, new Object[] { apiContext, mzEvent });

        }
    }
}

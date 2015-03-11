using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Events
{
    public interface IEventServiceFactory
    {
        IEventService GetEventService();
    }
    public class EventServiceFactory : IEventServiceFactory
    {
        public IEventService GetEventService()
        {
            return new EventService();
        }
    }
}

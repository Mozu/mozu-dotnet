using System.Web;
using System.Web.Routing;
using Autofac;
using Mozu.Api.Events;

namespace Mozu.Api.WebToolKit.Events
{
    public class EventRouteHandler : IRouteHandler
    {
        public IComponentContext Container;

        public EventRouteHandler(IComponentContext iComponentContext)
        {
            Container = iComponentContext;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return Container.Resolve<EventHttpHandler>();
        }
    }
}

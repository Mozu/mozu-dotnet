using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Mozu.Api.Events;

namespace Mozu.Api.Sample.Web
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
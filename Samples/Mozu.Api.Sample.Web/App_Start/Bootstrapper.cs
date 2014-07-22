using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Mozu.Api.Events;
using Mozu.Api.Logging;
using Mozu.Api.Sample.Web.Logging;

namespace Mozu.Api.Sample.Web
{
    public class Bootstrapper
    {
        //public static IContainer Container { get; internal set; }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register other dependencies.

            builder.RegisterType<EventServiceFactory>().As<IEventServiceFactory>().SingleInstance();
            builder.Register(c => new EventHttpHandler(c.Resolve<IEventServiceFactory>())).AsSelf().SingleInstance();
            builder.RegisterType<Log4NetService>().As<ILoggingService>().SingleInstance();
            builder.RegisterType<EventRouteHandler>().AsSelf().InstancePerApiRequest();
            
            // Build the container.
            var container = builder.Build();
            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
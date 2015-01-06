using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Mozu.Api.Contracts.InstalledApplications;
using Mozu.Api.Events;
using Mozu.Api.Logging;
using Mozu.Api.ToolKit;
using Mozu.Api.WebToolKit.Events;
using Mozu.Api.WebToolKit.Logging;
using Mozu.Api.WebToolKit.Controllers;

namespace Mozu.Api.WebToolKit
{
    public abstract class AbstractWebApiBootstrapper : AbstractBootstrapper
    {

        private HttpConfiguration _httpConfiguration;

        public AbstractWebApiBootstrapper Bootstrap(HttpConfiguration httpConfiguration)
        {
            _httpConfiguration = httpConfiguration;
            Bootstrap();
            return this;
        }

        public override void InitializeContainer(ContainerBuilder containerBuilder)
        {
            base.InitializeContainer(containerBuilder);
            
            containerBuilder.RegisterType<EventHttpHandler>().AsSelf();
            containerBuilder.RegisterType<EventRouteHandler>().AsSelf();
            containerBuilder.RegisterType<ApiLogger>().AsSelf().InstancePerRequest();
            containerBuilder.RegisterType<MvcLoggingFilter>().AsSelf().InstancePerRequest();
            containerBuilder.RegisterType<VersionController>().InstancePerRequest();
            containerBuilder.RegisterType<ApplicationController>().InstancePerRequest();
        }


        public override void PostInitialize()
        {
            base.PostInitialize();
            _httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            _httpConfiguration.MessageHandlers.Add(DependencyResolver.Current.GetService<ApiLogger>());
        }

    }
}

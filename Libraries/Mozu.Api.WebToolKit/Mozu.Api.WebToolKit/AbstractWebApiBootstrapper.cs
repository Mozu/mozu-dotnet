using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using Mozu.Api.Logging;
using Mozu.Api.ToolKit;
using Mozu.Api.WebToolKit.Events;
using Mozu.Api.WebToolKit.Logging;
using Mozu.Api.WebToolKit.Controllers;

namespace Mozu.Api.WebToolKit
{
    public abstract class AbstractWebApiBootstrapper : AbstractBootstrapper
    {
       

        public AbstractWebApiBootstrapper Bootstrap(HttpConfiguration httpConfiguration)
        {
            base.Bootstrap();
            InitDependencyResolvers(httpConfiguration);
            return this;
        }

        private void InitDependencyResolvers(HttpConfiguration httpConfiguration)
        {
            _containerBuilder.RegisterType<EventRouteHandler>().AsSelf();
            _containerBuilder.RegisterType<ApiLogger>().AsSelf().InstancePerRequest();
            _containerBuilder.RegisterType<MvcLoggingFilter>().AsSelf().InstancePerRequest();
            _containerBuilder.RegisterType<VersionController>().InstancePerRequest();

            InitializeContainer(_containerBuilder);

            Container = _containerBuilder.Build();

          
            PostInitialize();

            if (httpConfiguration == null) return;
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            httpConfiguration.MessageHandlers.Add(DependencyResolver.Current.GetService<ApiLogger>());
            
        }

    }
}

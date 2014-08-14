using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
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

        private HttpConfiguration _httpConfiguration;

        public AbstractWebApiBootstrapper Bootstrap(HttpConfiguration httpConfiguration)
        {
            Bootstrap();
            return this;
        }

        public override void InitializeContainer(ContainerBuilder containerBuilder)
        {
            base.InitializeContainer(containerBuilder);
            _containerBuilder.RegisterType<EventRouteHandler>().AsSelf();
            _containerBuilder.RegisterType<ApiLogger>().AsSelf().InstancePerRequest();
            _containerBuilder.RegisterType<MvcLoggingFilter>().AsSelf().InstancePerRequest();
            _containerBuilder.RegisterType<VersionController>().InstancePerRequest();
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

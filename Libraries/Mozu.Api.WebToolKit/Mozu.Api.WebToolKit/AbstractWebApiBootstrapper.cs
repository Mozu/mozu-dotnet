using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using Mozu.Api.Logging;
using Mozu.Api.WebToolKit.Events;
using Mozu.Api.WebToolKit.Logging;
using Mozu.Api.WebToolKit.Controllers;

namespace Mozu.Api.WebToolKit
{
    public abstract class AbstractWebApiBootstrapper
    {
        //private readonly AutofacContainerFactory _containerFactory = new AutofacContainerFactory();
        private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();
        public IContainer Container;

        public AbstractWebApiBootstrapper Bootstrap(HttpConfiguration httpConfiguration)
        {
            InitDependencyResolvers(httpConfiguration);

            return this;
        }

        private void InitDependencyResolvers(HttpConfiguration httpConfiguration)
        {
           
            _containerBuilder.RegisterType<EventRouteHandler>().AsSelf();
            _containerBuilder.RegisterType<ApiLogger>().AsSelf().InstancePerApiRequest();
            _containerBuilder.RegisterType<MvcLoggingFilter>().AsSelf().InstancePerApiRequest();
            _containerBuilder.RegisterType<VersionController>().InstancePerApiRequest();

            InitializeContainer(_containerBuilder);

            Container = _containerBuilder.Build();

          
            PostInitialize();

            if (httpConfiguration == null) return;
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            httpConfiguration.MessageHandlers.Add(DependencyResolver.Current.GetService<ApiLogger>());
            

            
        }

        public virtual void InitializeContainer(ContainerBuilder containerBuilder)
        {
        }

        public virtual void PostInitialize()
        {
            
        }
    }
}

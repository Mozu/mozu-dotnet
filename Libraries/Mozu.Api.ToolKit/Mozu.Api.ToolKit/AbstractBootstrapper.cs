using System;
using System.Collections.Generic;
using System.Configuration;
using Autofac;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Events;
using Mozu.Api.Logging;
using Mozu.Api.Security;
using Mozu.Api.ToolKit.Config;
using Mozu.Api.ToolKit.Events;
using Mozu.Api.ToolKit.Handlers;
using Mozu.Api.ToolKit.Logging;

namespace Mozu.Api.ToolKit
{
    public abstract class AbstractBootstrapper
    {
        protected readonly ContainerBuilder _containerBuilder = new ContainerBuilder();
        public IContainer Container;

        public AbstractBootstrapper Bootstrap()
        {
            InitDependencyResolvers();

            return this;
        }

        private void InitDependencyResolvers()
        {

            var appName = ConfigurationManager.AppSettings["AppName"];
            var configPath = ConfigurationManager.AppSettings["ConfigPath"];
            var environment = ConfigurationManager.AppSettings["Environment"];

            if (!string.IsNullOrEmpty(appName) && !string.IsNullOrEmpty(configPath) &&
                !String.IsNullOrEmpty(environment))
            {
                var appParams = new List<NamedParameter>
                {
                    
                    new NamedParameter("configPath",  configPath),
                    new NamedParameter("appName", appName),
                    new NamedParameter("environment", environment)
                };

                _containerBuilder.RegisterType<AppSetting>().As<IAppSetting>().SingleInstance().WithParameters(appParams);

            }
            else
            {
                _containerBuilder.RegisterType<AppSetting>().As<IAppSetting>().SingleInstance();
            }
            _containerBuilder.RegisterType<Log4NetServiceFactory>().As<ILoggingServiceFactory>().SingleInstance();
            _containerBuilder.RegisterType<Events.EventService>().As<IEventService>();
            _containerBuilder.RegisterType<Events.EventServiceFactory>().As<IEventServiceFactory>();
            _containerBuilder.RegisterType<ExtensionHandler>().As<IExtensionHandler>();
            _containerBuilder.RegisterType<EntityHandler>().As<IEntityHandler>();
            _containerBuilder.RegisterType<EntitySchemaHandler>().As<IEntitySchemaHandler>();
            _containerBuilder.RegisterType<ReturnEventProcessor>().Keyed<IEventProcessor>(EventCategory.Return);
            _containerBuilder.RegisterType<ProductEventProcessor>().Keyed<IEventProcessor>(EventCategory.Product);
            _containerBuilder.RegisterType<OrderEventProcessor>().Keyed<IEventProcessor>(EventCategory.Order);
            _containerBuilder.RegisterType<ApplicationEventProcessor>().Keyed<IEventProcessor>(EventCategory.Application);
            _containerBuilder.RegisterType<CustomerAccountEventProcessor>().Keyed<IEventProcessor>(EventCategory.CustomerAccount);
            _containerBuilder.RegisterType<DiscountEventProcessor>().Keyed<IEventProcessor>(EventCategory.Discount);
            _containerBuilder.RegisterType<CustomerSegmentEventProcessor>().Keyed<IEventProcessor>(EventCategory.CustomerSegment);
            _containerBuilder.RegisterType<TenantEventProcessor>().Keyed<IEventProcessor>(EventCategory.Tenant);


            InitializeContainer(_containerBuilder);

            Container = _containerBuilder.Build();

            LogManager.LoggingService = Container.Resolve<ILoggingServiceFactory>().GetLoggingService();
            var appSetting = Container.Resolve<IAppSetting>();

            if (!string.IsNullOrEmpty(appSetting.ApplicationId) && !string.IsNullOrEmpty(appSetting.SharedSecret))
            {
                if (!string.IsNullOrEmpty(appSetting.BaseUrl))
                    MozuConfig.BaseAppAuthUrl = appSetting.BaseUrl;
                var appAuthenticator = AppAuthenticator.InitializeAsync(new AppAuthInfo { ApplicationId = appSetting.ApplicationId, SharedSecret = appSetting.SharedSecret }).Result;

            }


            PostInitialize();

            
        }

        public virtual void InitializeContainer(ContainerBuilder containerBuilder)
        {
        }

        public virtual void PostInitialize()
        {
            
        }
    }
}

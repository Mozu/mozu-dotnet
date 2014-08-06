using Autofac;
using Mozu.Api.Events;
using Mozu.Api.Logging;
using Mozu.Integrations.Common.Events;
using Mozu.Integrations.Common.Logging;

namespace Mozu.Integrations.Common
{
    public abstract class AbstractBootstrapper
    {
        //private readonly AutofacContainerFactory _containerFactory = new AutofacContainerFactory();
        private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();
        public IContainer Container;

        public AbstractBootstrapper Bootstrap()
        {
            InitDependencyResolvers();

            return this;
        }

        private void InitDependencyResolvers()
        {

            _containerBuilder.RegisterType<Log4NetServiceFactory>().As<ILoggingServiceFactory>().SingleInstance();
            _containerBuilder.RegisterType<Events.EventService>().As<IEventService>();
            _containerBuilder.RegisterType<Events.EventServiceFactory>().As<IEventServiceFactory>();

           

            _containerBuilder.RegisterType<ReturnEventProcessor>().Keyed<IEventProcessor>(EventCategory.Return);
            _containerBuilder.RegisterType<ProductEventProcessor>().Keyed<IEventProcessor>(EventCategory.Product);
            _containerBuilder.RegisterType<OrderEventProcessor>().Keyed<IEventProcessor>(EventCategory.Order);
            _containerBuilder.RegisterType<ApplicationEventProcessor>().Keyed<IEventProcessor>(EventCategory.Application);
            _containerBuilder.RegisterType<CustomerAccountEventProcessor>().Keyed<IEventProcessor>(EventCategory.CustomerAccount);
            _containerBuilder.RegisterType<DiscountEventProcessor>().Keyed<IEventProcessor>(EventCategory.Discount);


            InitializeContainer(_containerBuilder);

            Container = _containerBuilder.Build();

            LogManager.LoggingService = Container.Resolve<ILoggingServiceFactory>().GetLoggingService();



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

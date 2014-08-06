using System;
using System.Reflection;
using Autofac;
using Mozu.Api;
using Mozu.Api.Contracts.Event;
using Mozu.Api.Events;
using Mozu.Api.Logging;

namespace Mozu.Integrations.Common.Events
{
    public interface IEventProcessor
    {
        void Process(IComponentContext container, IApiContext apiContext, Event eventPayLoad);
    }
    public abstract class EventProcessorBase 
    {
        protected readonly ILogger _logger = LogManager.GetLogger(typeof(EventService));
        private string _action;
        protected IApiContext ApiContext;
        protected Event EventPayLoad;
        protected IComponentContext Container;
       
        protected void Execute<T>(T eventType)
        {
        
            var eventCategory = EventPayLoad.Topic.Split('.');
            _action = eventCategory[1]; //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(eventCategory[1]);


            var type = eventType.GetType();
            var methodInfo = type.GetMethod(_action, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

            if (methodInfo == null)
                throw new Exception("Method : " + _action + " not found in " + type);
            try
            {
                methodInfo.Invoke(eventType, new Object[] { ApiContext, EventPayLoad });
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
                if (exc.InnerException != null)
                    throw exc.InnerException;

                throw;
            }
        }

    }

    public class OrderEventProcessor : EventProcessorBase, IEventProcessor
    {
        public new void Process(IComponentContext container,IApiContext apiContext, Event eventPayLoad)
        {
            EventPayLoad = eventPayLoad;
            ApiContext = apiContext;
            Container = container;
            _logger.Info("Processing Order event");
            var orderEvents = Container.Resolve<IOrderEvents>();
            if (orderEvents == null) throw new ArgumentNullException("IOrderEvents is not registered");
            Execute(orderEvents);
        }
    }

    public class ReturnEventProcessor : EventProcessorBase, IEventProcessor
    {
        public new void Process(IComponentContext container,IApiContext  apiContext, Event eventPayLoad)
        {
            EventPayLoad = eventPayLoad;
            ApiContext = apiContext;
            Container = container;
            _logger.Info("Processing Return event");
            var returnEvents = Container.Resolve<IReturnEvents>();
            if (returnEvents == null) throw new ArgumentNullException("IReturnEvents is not registered");
            Execute(returnEvents);
        }
    }

    public class CustomerAccountEventProcessor : EventProcessorBase, IEventProcessor
    {
        public new void Process(IComponentContext container, IApiContext apiContext, Event eventPayLoad)
        {
            EventPayLoad = eventPayLoad;
            ApiContext = apiContext;
            Container = container;
            _logger.Info("Processing Customer Account event");
            var customerAccountEvents = Container.Resolve<ICustomerAccountEvents>();
            if (customerAccountEvents == null) throw new ArgumentNullException("ICustomerAccountEvents is not registered");
            Execute(customerAccountEvents);
        }
    }

    public class ProductEventProcessor : EventProcessorBase, IEventProcessor
    {
        public new void Process(IComponentContext container, IApiContext apiContext, Event eventPayLoad)
        {
            EventPayLoad = eventPayLoad;
            ApiContext = apiContext;
            Container = container;
            _logger.Info("Processing Product event");
            var productEvents = Container.Resolve<IProductEvents>();
            if (productEvents == null) throw new ArgumentNullException("IProductEvents is not registered");
            Execute(productEvents);
        }
    }

    public class DiscountEventProcessor : EventProcessorBase, IEventProcessor
    {
        public new void Process(IComponentContext container, IApiContext apiContext, Event eventPayLoad)
        {
            EventPayLoad = eventPayLoad;
            ApiContext = apiContext;
            Container = container;
            _logger.Info("Processing Discount event");
            var discountEvents = Container.Resolve<IDiscountEvents>();
            if (discountEvents == null) throw new ArgumentNullException("IDiscountEvents is not registered");
            Execute(discountEvents);
        }
    }

    public class ApplicationEventProcessor : EventProcessorBase, IEventProcessor
    {
        public new void Process(IComponentContext container, IApiContext apiContext, Event eventPayLoad)
        {
            EventPayLoad = eventPayLoad;
            ApiContext = apiContext;
            Container = container;
            _logger.Info("Processing Application event");
            var applicationEvents = Container.Resolve<IApplicationEvents>();
            if (applicationEvents == null) throw new ArgumentNullException("IApplicationEvents is not registered");
            Execute(applicationEvents);
        }
    }

}

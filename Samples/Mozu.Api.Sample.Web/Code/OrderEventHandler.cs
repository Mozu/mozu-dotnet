using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mozu.Api.Contracts.Event;
using Mozu.Api.Events;

namespace Mozu.Api.Sample.Web.Code
{
    public class OrderEventHandler : IOrderEvents
    {
        public void Fulfilled(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }

        public void Opened(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }

        public void PendingReview(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }

        public void Closed(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }

        public void Cancelled(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }


        public void Updated(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }

        public void All(IApiContext apiContext, Event eventPayLoad)
        {
            throw new NotImplementedException();
        }
    }
}
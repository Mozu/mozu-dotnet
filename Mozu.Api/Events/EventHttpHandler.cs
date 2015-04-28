using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Mozu.Api.Logging;
using Mozu.Api.Resources.Commerce.Settings;
using Mozu.Api.Security;
using Mozu.Api.Utilities;
using Newtonsoft.Json;
using Mozu.Api.Contracts.Event;
using Mozu.Api.Config.Event;
using System.Configuration;
using System.Reflection;

namespace Mozu.Api.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class EventHttpHandler : IHttpAsyncHandler
    {
        private readonly IEventServiceFactory _eventServiceFactory;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventServiceFactory"></param>
        public EventHttpHandler(IEventServiceFactory eventServiceFactory)
        {
            _eventServiceFactory = eventServiceFactory;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {

            throw new NotImplementedException();
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            if (_eventServiceFactory == null)
                throw new Exception("Event service factory cannot be null");
            var asynch = new AsyncEventOperation(cb, context, extraData, _eventServiceFactory);
            asynch.StartAsyncWork();
            return asynch;
        }

        public void EndProcessRequest(IAsyncResult result)
        {

        }
    }

    internal class AsyncEventOperation : IAsyncResult
    {
        private static ILogger _log = LogManager.GetLogger(typeof(EventHttpHandler));
        private bool _completed;
        private Object _state;
        private AsyncCallback _callback;
        private HttpContext _context;
        private readonly IEventServiceFactory _eventServiceFactory;
        bool IAsyncResult.IsCompleted
        {
            get { return _completed; }
        }

        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return null; }
        }

        Object IAsyncResult.AsyncState
        {
            get { return _state; }
        }

        bool IAsyncResult.CompletedSynchronously
        {
            get { return false; }
        }

        public AsyncEventOperation(AsyncCallback callback, HttpContext context, Object state, IEventServiceFactory eventServiceFactory)
        {
            _callback = callback;
            _context = context;
            _state = state;
            _completed = false;
            _eventServiceFactory = eventServiceFactory;
        }

        public void StartAsyncWork()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Process), null);
        }


        private async void Process(Object workItemState)
        {
            //create http objects used to read request 
            var request = _context.Request;
            var response = _context.Response;

            //get file path to use as comparison and determine when to take action on event
            //load headers into apicontext
            var apiContext = new ApiContext(request.Headers);

            //read request into stream
            var jsonRequest = string.Empty;
            request.InputStream.Position = 0;
            using (var inputStream = new StreamReader(request.InputStream))
            {
                jsonRequest = inputStream.ReadToEnd();
            }

            response.Clear();
            response.ClearHeaders();

            _log.Debug(String.Format("CorrelationId:{0},Headers : {1}", apiContext.CorrelationId, HttpHelper.GetAllheaders(request.Headers)));
            _log.Debug(String.Format("CorrelationId:{0},Processing event : {1}", apiContext.CorrelationId, jsonRequest));

            var requestDate = DateTime.Parse(apiContext.Date, null, DateTimeStyles.AssumeUniversal).ToUniversalTime();
            var currentDate = DateTime.UtcNow;

            _log.Info(String.Format("Current DateTime : {0}", currentDate));
            _log.Info(String.Format("Request DateTime : {0}", requestDate));

            var diff = (currentDate - requestDate).TotalSeconds;
            if (SHA256Generator.GetHash(AppAuthenticator.Instance.AppAuthInfo.SharedSecret, apiContext.Date, jsonRequest) != apiContext.HMACSha256 || diff > MozuConfig.EventTimeoutInSeconds)
            {
                _log.Error(String.Format("CorrelationId:{0},Could not validate security token , request header HMACSHA256 : {1}", apiContext.CorrelationId, apiContext.HMACSha256));
                response.StatusCode = 403;
            }
            else
            {
                try
                {
                    var eventPayload = JsonConvert.DeserializeObject<Event>(jsonRequest);
                    if (string.IsNullOrEmpty(eventPayload.Id) && !String.IsNullOrEmpty(eventPayload.EventId))
                        eventPayload.Id = Guid.Parse(eventPayload.EventId).ToString("N");
                    var eventService = _eventServiceFactory.GetEventService();
                    if (string.IsNullOrEmpty(apiContext.CorrelationId))
                        apiContext.CorrelationId = eventPayload.CorrelationId;

                    await eventService.ProcessEventAsync(apiContext, eventPayload);

                    _log.Info(string.Format("CorrelationId:{0},Event processing done , EventId : {1}", apiContext.CorrelationId, eventPayload.Id));
                    response.StatusCode = 200;
                    response.StatusDescription = "OK";
                }
                catch (Exception exc)
                {
                    response.StatusCode = 500;
                    response.StatusDescription = exc.Message;
                    response.ContentType = _context.Request.ContentType;
                    _log.Error(exc.Message, exc);
                    if (exc.InnerException != null)
                        response.Write(JsonConvert.SerializeObject(exc.InnerException));
                    else
                        response.Write(JsonConvert.SerializeObject(exc));
                }
            }

            response.Flush();
            _completed = true;
            _callback(this);

        }
    }
}

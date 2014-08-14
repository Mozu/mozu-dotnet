using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
    public class EventHttpHandler: IHttpHandler
    {
        private readonly IEventServiceFactory _eventServiceFactory;
        private static ILogger _log = LogManager.GetLogger(typeof(EventHttpHandler));

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
            //create http objects used to read request 
            var request = context.Request;
            var response = context.Response;

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

            _log.Debug(String.Format("CorrelationId:{0},Headers : {1}", apiContext.CorrelationId,HttpHelper.GetAllheaders(request.Headers)));
            _log.Debug(String.Format("CorrelationId:{0},Processing event : {1}",apiContext.CorrelationId, jsonRequest));
            var requestDate = DateTime.Parse(apiContext.Date, null, DateTimeStyles.AssumeUniversal).ToUniversalTime();
            var currentDate = DateTime.UtcNow;
            var diff = (currentDate - requestDate).TotalSeconds;
            if (SHA256Generator.GetHash(AppAuthenticator.Instance.AppAuthInfo.SharedSecret, apiContext.Date, jsonRequest) !=
                apiContext.HMACSha256 || diff > MozuConfig.EventTimeoutInSeconds)
            {
                _log.Error(String.Format("CorrelationId:{0},Could not validate security token , request header HMACSHA256 : {1}", apiContext.CorrelationId,apiContext.HMACSha256));
                response.StatusCode = 403;
            }
            else
            {
                try
                {
                    var eventPayload = JsonConvert.DeserializeObject<Event>(jsonRequest);
                    //var eventServiceFactory = new EventServiceFactory();
                    var eventService = _eventServiceFactory.GetEventService();
                    eventService.ProcessEvent(apiContext, eventPayload);
                    _log.Info(string.Format("CorrelationId:{0},Event processing done , EventId : {1}",apiContext.CorrelationId, eventPayload.Id));
                    response.StatusCode = 200;
                    response.StatusDescription = "OK";

                }
                catch (Exception exc)
                {
                    response.StatusCode = 500;
                    response.StatusDescription = exc.Message;
                    response.ContentType = context.Request.ContentType;
                    _log.Error(exc.Message, exc);
                    if (exc.InnerException != null)
                        response.Write(JsonConvert.SerializeObject(exc.InnerException));
                    else
                        response.Write(JsonConvert.SerializeObject(exc));
                }
            }

            response.Flush();
            context.ApplicationInstance.CompleteRequest();

        }

    }
}

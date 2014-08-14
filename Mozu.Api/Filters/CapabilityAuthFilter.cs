using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Mozu.Api.Logging;
using Mozu.Api.Security;
using Mozu.Api.Utilities;

namespace Mozu.Api.Filters
{
     /// <summary>
     /// Validate Capability Request from Mozu
     /// </summary>
     [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method)]
    public class CapabilityAuthFilter : AuthorizationFilterAttribute 
    {
         private readonly ILogger _logger = LogManager.GetLogger(typeof(CapabilityAuthFilter));

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            var corrID = HttpHelper.GetHeaderValue(Headers.X_VOL_CORRELATION, actionContext.Request.Headers);
            _logger.Info(String.Format("{0} - Validating Capability Request", corrID));
            var content = actionContext.Request.Content.ReadAsStringAsync().Result;
            var apiContext = new ApiContext(actionContext.Request.Headers);
            var requestDate = DateTime.Parse(apiContext.Date, null, DateTimeStyles.AssumeUniversal).ToUniversalTime();
            var currentDate = DateTime.UtcNow;
            var diff = (currentDate - requestDate).TotalSeconds;
            var hash = SHA256Generator.GetHash(AppAuthenticator.Instance.AppAuthInfo.SharedSecret, apiContext.Date, content);
            if (hash == apiContext.HMACSha256 && diff <= MozuConfig.CapabilityTimeoutInSeconds) return;
            _logger.Debug(String.Format("{0} Unauthorized access : Header Hash - {1}, Computed Hash - {2}, Request Date - {3}",corrID, apiContext.HMACSha256, hash, apiContext.Date));
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

    }
}

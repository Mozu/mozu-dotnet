using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Mozu.Api.Logging;

namespace Mozu.Api.WebToolKit.Logging
{
    public class MvcLoggingFilter : ActionFilterAttribute
    {
        
        private readonly ILogger _logger = LogManager.GetLogger(typeof(MvcLoggingFilter));

       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var req = filterContext.HttpContext.Request;


            var corrId =  Guid.NewGuid();
            req.Headers.Add(Headers.X_VOL_CORRELATION, corrId.ToString());

            Trace.CorrelationManager.ActivityId = corrId;

            var requestInfo = string.Format("{0} {1}", req.HttpMethod, req.Url.AbsolutePath);

            _logger.Debug(string.Format("{0}, Originating IP - {1} ", requestInfo, req.UserHostAddress));

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(String.Format("Start Time: {0}",DateTime.Now));
                _logger.Debug( RequestBody(req));

                var headers = string.Empty;
                foreach (var key in req.Headers.AllKeys)
                {
                    if (!String.IsNullOrEmpty(headers)) headers += ", ";
                    headers += string.Format("{0} : {1}", key, req.Headers[key]);
                }
                _logger.Debug(headers);
            }

            base.OnActionExecuting(filterContext);

            var res = filterContext.HttpContext.Response;
            res.Headers.Add(Headers.X_VOL_CORRELATION, corrId.ToString());

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(String.Format("End Time: {0}", DateTime.Now));
            }

        }


        private static string RequestBody(HttpRequestBase req)
        {
            var bodyStream = new StreamReader(req.InputStream);
            bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            var bodyText = bodyStream.ReadToEnd();
            return bodyText;
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Mozu.Api.Logging;

namespace Mozu.Api.WebToolKit.Logging
{
    public class ApiLogger : DelegatingHandler
    {
        private readonly bool _isRequestResponseLoggingEnabled = false;
        private readonly ILogger _logger = LogManager.GetLogger(typeof (ApiLogger));

      

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Guid corrId = Guid.NewGuid();
            if (request.Headers.Contains(Headers.X_VOL_CORRELATION))
            {
                var headerValues = request.Headers.GetValues(Headers.X_VOL_CORRELATION);
                if (headerValues != null && !Equals(headerValues, Enumerable.Empty<string>()))
                    Guid.TryParse(headerValues.FirstOrDefault(), out corrId);
            } else
                request.Headers.Add(Headers.X_VOL_CORRELATION, corrId.ToString());

            Trace.CorrelationManager.ActivityId = corrId;
    
            var requestInfo = string.Format("{0} {1}", request.Method, request.RequestUri);

            _logger.Info(requestInfo);

            if (_logger.IsDebugEnabled)
            {
               _logger.Debug(String.Format("Start Time: {0}", DateTime.Now));
               _logger.Debug( request.Content.ReadAsStringAsync().Result);

               var headers = request.Headers.ToList().Select(x => string.Format("{0} : {1}", x.Key, x.Value.FirstOrDefault())).Aggregate((x,y)=>x+" , "+y);
               _logger.Debug(String.Format("{0} Start Time: {1}", corrId, headers));
            }

            var response = await base.SendAsync(request, cancellationToken);

            response.Headers.Add(Headers.X_VOL_CORRELATION, corrId.ToString());

            try
            {
                if (_logger.IsDebugEnabled)
                {
                    if (response.IsSuccessStatusCode && response.Content != null)
                        _logger.Debug(response.Content.ReadAsStringAsync().Result);

                    _logger.Debug(String.Format("End Time: {0}", DateTime.Now));
                }

            }
            catch (Exception exc){}
                
            
            return response;
        }
    }
}

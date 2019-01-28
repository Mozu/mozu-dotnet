using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mozu.Api.Utilities
{
    public class ResponseHelper
    {
        /// <summary>
        /// Validate HttpResponse message, throws an Api Exception with context
        /// </summary>
        /// <param name="response"></param>
        /// <param name="request"></param>
        /// <param name="apiContext"></param>
        /// <exception cref="ApiException"></exception>
        public static void EnsureSuccess(HttpResponseMessage response, HttpRequestMessage request=null, IApiContext apiContext=null)
        {
		    if (response.IsSuccessStatusCode) return;
		    if (response.StatusCode == HttpStatusCode.NotModified) return;
		    var content = response.Content.ReadAsStringAsync().Result;
		    ApiException exception ;
		    var htmlMediaType = new MediaTypeHeaderValue("text/html");
		    if (response.Content.Headers.ContentType != null && 
		        response.Content.Headers.ContentType.MediaType == htmlMediaType.MediaType)
		    {
		        var message = String.Format("Status Code {0}, Uri - {1}", response.StatusCode,
		            response.RequestMessage.RequestUri.AbsoluteUri);
		        exception = new ApiException(message, new Exception(content));
		    }
		    else if (!String.IsNullOrEmpty(content))
		        exception = JsonConvert.DeserializeObject<ApiException>(content);
		    else if (HttpStatusCode.NotFound == response.StatusCode && string.IsNullOrEmpty(content) && request != null)
                exception = new ApiException("Uri "+request.RequestUri.AbsoluteUri + " does not exist");
            else
		        exception = new ApiException("Unknow Exception");
		    exception.HttpStatusCode = response.StatusCode;
		    exception.CorrelationId = HttpHelper.GetHeaderValue(Headers.X_VOL_CORRELATION, response.Headers);
		    exception.ApiContext = apiContext;
		    if (!MozuConfig.ThrowExceptionOn404 &&
		        string.Equals(exception.ErrorCode, "ITEM_NOT_FOUND", StringComparison.OrdinalIgnoreCase)
		        && response.RequestMessage.Method.Method == "GET")
		        return;
		    throw exception;
        }

    }
}

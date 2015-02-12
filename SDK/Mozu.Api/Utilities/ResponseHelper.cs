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
		public static void EnsureSuccess(HttpResponseMessage response)
		{
			EnsureSuccess(response, null);
		}

		
		/// <summary>
		/// Validate HttpResponse message, throws an Api Exception with context
		/// </summary>
		/// <param name="response"></param>
		/// <param name="apiContext"></param>
		/// <exception cref="ApiException"></exception>
		public static void EnsureSuccess(HttpResponseMessage response, IApiContext apiContext)
        {
            if (!response.IsSuccessStatusCode)
            {
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
                else
                    exception = JsonConvert.DeserializeObject<ApiException>(content);
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
}

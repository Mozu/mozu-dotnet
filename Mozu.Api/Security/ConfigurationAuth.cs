using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web;
using System.Net;
using Microsoft.AspNetCore.Http;
using Mozu.Api.Extensions;
//using System.Web.UI;
using Mozu.Api.Logging;
using Microsoft.AspNetCore.Http.Extensions;

namespace Mozu.Api.Security
{
    public class ConfigurationAuth
    {
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(ConfigurationAuth));
        

        public static bool IsRequestValid(HttpRequest request)
        {
            var body = WebUtility.UrlDecode(GetBodyFromFormCollection(request));

            var messageHash = request.Query["messageHash"].FirstOrDefault();
            var tenantId = request.Query["tenantId"].FirstOrDefault();
            if (tenantId == null)
            {
                ApiContext context = new ApiContext(request.Form.FormCollectionToNVCollection());
                tenantId = context.TenantId.ToString();
            }
            var date = request.Query["dt"].FirstOrDefault();

            var requestDate = DateTime.Parse(date, null, DateTimeStyles.AssumeUniversal).ToUniversalTime();
            var currentDate = DateTime.UtcNow;
            _logger.Info(String.Format("Current DateTime : {0}", currentDate));
            _logger.Info(String.Format("Request DateTime : {0}", requestDate));
            var diff = (currentDate - requestDate).TotalSeconds;
            _logger.Info(String.Format("Date Diff : {0}", diff));
            _logger.Info(String.Format("ApplicationID : {0}", AppAuthenticator.Instance.AppAuthInfo.ApplicationId));
            var hash = SHA256Generator.GetHash(AppAuthenticator.Instance.AppAuthInfo.SharedSecret, date, body);
            _logger.Info(String.Format("Computed Hash : {0}", hash));
            if (body != null && (hash != messageHash || diff > MozuConfig.CapabilityTimeoutInSeconds || (!body.Contains("t" + tenantId + "."))))
            {
                _logger.Error(String.Format("Unauthorized access from {0}, {1}, {2}, {3} Computed: {4}", request.Host.Value, messageHash, date, body, hash));
                return false;
            }
            return true;
        }

        private static string GetBodyFromFormCollection(HttpRequest request)
        {
            StringBuilder sb = new StringBuilder();
            if (request.Form.Count == 0) return string.Empty;
            var formCollection = request.Form.FormCollectionToNVCollection();
            for (int i = 0; i < formCollection.Count; i++)
            {
                string curItemStr = string.Format("{0}={1}", formCollection.GetKey(i),
                                                              formCollection.GetValues(i).FirstOrDefault());
                if (i != 0)
                    sb.Append("&");
                sb.Append(curItemStr);
            }
            return sb.ToString();
        }
    }
}

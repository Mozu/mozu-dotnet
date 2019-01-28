using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Mozu.Api.Logging;

namespace Mozu.Api.Security
{
    public class ConfigurationAuth
    {
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(ConfigurationAuth));
        public static bool IsRequestValid(HttpRequestBase request)
        {
            var body = HttpUtility.UrlDecode(request.Form.ToString());

            var messageHash = request.QueryString["messageHash"];
            var tenantId = request.QueryString["tenantId"];
            if (tenantId == null)
            {
                ApiContext context = new ApiContext(request.Form);
                tenantId = context.TenantId.ToString();
            }
            var date = request.QueryString["dt"];

            var requestDate = DateTime.Parse(date, null, DateTimeStyles.AssumeUniversal).ToUniversalTime();
            var currentDate = DateTime.UtcNow;
            _logger.Info(String.Format("Current DateTime : {0}", currentDate));
            _logger.Info(String.Format("Request DateTime : {0}", requestDate));
            var diff = (currentDate - requestDate).TotalSeconds;
            _logger.Info(String.Format("Date Diff : {0}", diff));
            _logger.Info(String.Format("ApplicationID : {0}", AppAuthenticator.Instance.AppAuthInfo.ApplicationId));
            var hash = SHA256Generator.GetHash(AppAuthenticator.Instance.AppAuthInfo.SharedSecret, date, body);
            _logger.Info(String.Format("Computed Hash : {0}", hash));
            if (body != null && (hash != messageHash || diff > MozuConfig.CapabilityTimeoutInSeconds || (!body.Contains("t" + tenantId+"."))))
            {
                _logger.Error(String.Format("Unauthorized access from {0}, {1}, {2}, {3} Computed: {4}", request.UserHostAddress, messageHash, date, body, hash));
                return false;
            }
            return true;
        }
    }
}

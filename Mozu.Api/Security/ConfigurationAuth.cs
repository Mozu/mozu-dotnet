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
            var date = request.QueryString["dt"];

            var requestDate = DateTime.Parse(date, null, DateTimeStyles.AssumeUniversal).ToUniversalTime();
            var currentDate = DateTime.UtcNow;
            var diff = (currentDate - requestDate).TotalSeconds;
            var hash = SHA256Generator.GetHash(AppAuthenticator.Instance.AppAuthInfo.SharedSecret, date, body);
            if (hash != messageHash || diff > MozuConfig.CapabilityTimeoutInSeconds)
            {
                _logger.Error(String.Format("Unauthorized access from {0}, {1}, {2}, {3} Computed: {4}", request.UserHostAddress, messageHash, date, body, hash));
                return false;
            }
            return true;
        }
    }
}

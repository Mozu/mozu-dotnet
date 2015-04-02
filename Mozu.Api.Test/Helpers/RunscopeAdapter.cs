using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Mozu.Api.Test.Helpers
{
    /// <summary>
    /// Runscope Service Adapter / Hacker.  Allows to you programatically login to Runscope and check for recent bucket traffic.
    /// </summary>
    public class RunscopeAdapter : IDisposable
    {
        #region Constants
        [XmlRoot(Namespace = "http://events.mozu.com")]
        [DataContract]
        public class EventNotification
        {
            [DataMember(EmitDefaultValue = false)]
            public string EventId { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string Topic { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string EntityId { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public DateTime Timestamp { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string CorrelationId { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public bool? IsTest { get; set; }
        }
        public const string LoginUrl = "https://www.runscope.com/signin";
        public const string RequestVerificationTokenElementName = "_ct";
        protected const string NextElementName = "next";
        public const string BucketUrlBase = "https://www.runscope.com/stream";

        #endregion

        #region Public Properties

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.  UserName and Password are required.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public RunscopeAdapter(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            UserName = userName;
            Password = password;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<EventNotification>> GetRecentRequestsByProperty(string bucketKey, string propertyName, string propertyValue)
        {
            var foundItems = await GetRecentEventNotifications(bucketKey);
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyValue");
            var property = typeof(EventNotification).GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException(string.Format("Public Property with the name '{0}' does not exist for an Event Notification", propertyName));

            var foundRequestBodies = foundItems.Where(x => string.Equals(x.GetType().GetProperty(propertyName).GetValue(x, null).ToString(), propertyValue, StringComparison.OrdinalIgnoreCase)).ToList();
            return foundRequestBodies;
        }

        /// <summary>
        /// Get Events on the first page of results
        /// </summary>
        /// <param name="bucketKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventNotification>> GetRecentEventNotifications(string bucketKey)
        {
            if (string.IsNullOrEmpty(bucketKey))
                throw new ArgumentNullException("bucketKey");

            var baseLoginUri = new Uri(LoginUrl);
            var bucketPath = HttpUtility.UrlEncode("/stream/" + bucketKey);
            var dynamicBucketLoginUrl = new Uri(baseLoginUri, "?next=" + bucketPath).ToString();
            var userAgentList = new List<string>()
            {
                "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1700.107 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0"
            };
            var randomUserAgent = userAgentList.OrderBy(x => Guid.NewGuid()).Take(1).Single();

            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", randomUserAgent);
            
            var originalLoginResponse = await client.GetAsync(dynamicBucketLoginUrl);
            var originalLoginContent = await originalLoginResponse.Content.ReadAsStringAsync();

            var originalLoginDoc = new HtmlDocument();
            HtmlNode.ElementsFlags.Remove("form");
            originalLoginDoc.LoadHtml(originalLoginContent);

            string requestVerificationTokenValue = null;
            string nextValue = null;
            HtmlNode formNode = originalLoginDoc.DocumentNode.SelectNodes("//form")[0];
            foreach (var innode in formNode.Elements("input"))
            {
                if (!innode.HasAttributes) continue;
                if (string.Equals(innode.Attributes["name"].Value, RequestVerificationTokenElementName, StringComparison.OrdinalIgnoreCase))
                {
                    requestVerificationTokenValue = innode.Attributes["value"].Value;
                    continue;
                }
                if (string.Equals(innode.Attributes["name"].Value, NextElementName, StringComparison.OrdinalIgnoreCase))
                {
                    nextValue = innode.Attributes["value"].Value;
                }
            }

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("email", UserName));
            postData.Add(new KeyValuePair<string, string>("password", Password));
            if (!string.IsNullOrEmpty(requestVerificationTokenValue))
                postData.Add(new KeyValuePair<string, string>("_ct", requestVerificationTokenValue));
            if (!string.IsNullOrEmpty(nextValue))
                postData.Add(new KeyValuePair<string, string>("next", nextValue));

            var encodedContent = new FormUrlEncodedContent(postData);


            var response = await client.PostAsync(dynamicBucketLoginUrl, encodedContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(responseContent) || response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ArgumentException("Login was not successful.  UserName and Password combination may be incorrect.");

            var doc = new HtmlDocument();
            doc.LoadHtml(responseContent);

            var foundRequestBodies = doc.DocumentNode.SelectNodes("//div[contains(@class,'raw-request-body')]//pre").Select(x => HttpUtility.HtmlDecode(x.InnerHtml)).ToList();
            List<EventNotification> retVal = null;
            if (foundRequestBodies.Any())
            {
                retVal = new List<EventNotification>(foundRequestBodies.Count);
                retVal.AddRange(foundRequestBodies.Select(JsonConvert.DeserializeObject<EventNotification>));
            }

            return retVal;
        }

        public void Dispose()
        {

        }
        #endregion
    }
}


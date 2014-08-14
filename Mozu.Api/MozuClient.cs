using System;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Mozu.Api.Logging;
using Mozu.Api.Resources.Platform;
using Mozu.Api.Security;
using Mozu.Api.Utilities;
using Newtonsoft.Json;

namespace Mozu.Api
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class MozuClient<TResult> : MozuClient<object, TResult>
    {

        /*public virtual MozuClient<TResult> WithUserAuth(AuthTicket authTicket)
        {
            base.SetUserClaims(authTicket);
            return this;
        }*/

		public virtual MozuClient<TResult> WithContext(IApiContext apiContext)
		{
			base.SetContext(apiContext);
			return this;
		}

        public virtual MozuClient<TResult> WithBaseAddress(string baseAddress)
        {
            base.SetBaseAddress(baseAddress);
            return this;
        }

		public virtual MozuClient<TResult> WithHeader(string header, string value)
        {
            base.AddHeader(header, value);
            return this;
        }

		public virtual MozuClient<TResult> WithVerb(string verb)
        {
            base.SetVerb(verb);
            return this;
        }

		public virtual MozuClient<TResult> WithResourceUrl(MozuUrl resourceUrl)
        {
            base.SetResourceUrl(resourceUrl);
            return this;
        }

		public virtual MozuClient<TResult> WithBody<TBody>(TBody body)
        {
            SetBody(body);
            return this;
        }

		public virtual MozuClient<TResult> WithBody(string stringContent)
        {
            base.SetBody(stringContent);
            return this;
        }

        public virtual MozuClient<TResult> WithBody(Stream body)
        {
            base.SetBody(body);
            return this;
        }


		public virtual MozuClient<TResult> Execute()
        {
            base.ExecuteRequest();
            return this;
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    public class MozuClient : MozuClient<object, object>
    {

        /*public virtual MozuClient WithUserAuth(AuthTicket authTicket)
        {
            base.SetUserClaims(authTicket);
            return this;
        }*/

		public virtual MozuClient WithContext(IApiContext apiContext)
		{
			base.SetContext(apiContext);
			return this;
		}

		public virtual MozuClient WithBaseAddress(string baseAddress)
        {
            base.SetBaseAddress(baseAddress);
            return this;
        }

		public virtual MozuClient WithHeader(string header, string value)
        {
            base.AddHeader(header, value);
            return this;
        }

		public virtual MozuClient WithVerb(string verb)
        {
            base.SetVerb(verb);
            return this;
        }

		public virtual MozuClient WithResourceUrl(MozuUrl resourceUrl)
        {
            base.SetResourceUrl(resourceUrl);
            return this;
        }

		public virtual MozuClient WithBody<T>(T body)
        {
            var stringContent = JsonConvert.SerializeObject(body);
            base.SetBody(stringContent);
            return this;
        }

		public virtual MozuClient WithBody(string body)
        {
            base.SetBody(body);
            return this;
        }

        public virtual MozuClient WithBody(Stream body)
        {
            base.SetBody(body);
            return this;
        }

		public virtual MozuClient Execute()
        {
            base.ExecuteRequest();
            return this;
        }

       
    }

    /// <summary>
    /// 
    /// </summary>
    public class MozuClient<TBody,TResult>
    {
		private IApiContext _apiContext ;
        private string _baseAddress = string.Empty;
        private HttpResponseMessage _httpResponseMessage;
        private StringContent _httpContent;
        private StreamContent _streamContent;
        private string _verb = string.Empty;
		private MozuUrl _resourceUrl;
        private NameValueCollection _headers = new NameValueCollection();
        private static ConcurrentDictionary<string, HttpClient> _clientsByHostName;
        private ILogger _log = LogManager.GetLogger(typeof(MozuClient));
        private string _contentType = null;

        static MozuClient()
        {
            _clientsByHostName = new ConcurrentDictionary<string, HttpClient>();
        }


        public virtual void AddHeader(string header, string value)
        {
            if (header == Headers.CONTENT_TYPE)
                _contentType = value;
            else
                _headers.Add(header, value);
        }

        public virtual HttpResponseMessage HttpResponse
        {
            get { return _httpResponseMessage; }
        }

        public MozuUrl ResourceUrl { get { return _resourceUrl; } }

        public virtual HttpClient HttpClient
        {
            get
            {
                // ValidateContext();
                var client = GetHttpClient();

                if (String.IsNullOrEmpty(_baseAddress))
                    throw new Exception("Base Address is not set");

                client.BaseAddress = new Uri(_baseAddress);

                
                SetUserClaims();
                
                if (_headers[Headers.X_VOL_APP_CLAIMS] == null)
                {
                    if (_apiContext == null || string.IsNullOrEmpty(_apiContext.AppAuthClaim))
                        AppAuthenticator.AddHeader(client);
                    else
                        _headers.Add(Headers.X_VOL_APP_CLAIMS, _apiContext.AppAuthClaim);
                }

                AddHeader(Headers.X_VOL_VERSION, Version.ApiVersion);

                if (_apiContext != null && !String.IsNullOrEmpty(_apiContext.CorrelationId))
                    AddHeader(Headers.X_VOL_CORRELATION, _apiContext.CorrelationId);

                foreach (var key in _headers.AllKeys)
                {
                    client.DefaultRequestHeaders.Add(key, _headers[key]);
                }

                return client;
            }
        }

        public virtual HttpRequestMessage RequestMessage
        {
            get { return GetRequestMessage(); }
        }

        //public virtual ApiException ApiException { get; set; }

        public virtual TResult Result()
        {
            if (typeof(TResult) == typeof(Stream))
                return (TResult)(object)HttpResponse.Content.ReadAsStreamAsync().Result;

            var stringContent = HttpResponse.Content.ReadAsStringAsync().Result;

            if (_log.IsDebugEnabled)
                _log.Debug(string.Format("{0} {1}", GetCorrelationId(), stringContent));

            return JsonConvert.DeserializeObject<TResult>(stringContent, new JsonSerializerSettings{DateTimeZoneHandling = DateTimeZoneHandling.Utc});
        }

        

		protected virtual void SetContext(IApiContext apiContext)
		{
			_apiContext = apiContext;

		    if (_apiContext == null) return;
			if (_apiContext.TenantId > 0)
			{
				AddHeader(Headers.X_VOL_TENANT, _apiContext.TenantId.ToString());
			}

			if (_apiContext.SiteId.HasValue && _apiContext.SiteId.Value > 0)
			{
				AddHeader(Headers.X_VOL_SITE, _apiContext.SiteId.Value.ToString());
			}

            if (_apiContext.MasterCatalogId.HasValue && _apiContext.MasterCatalogId.Value > 0)
			{
				AddHeader(Headers.X_VOL_MASTER_CATALOG, _apiContext.MasterCatalogId.Value.ToString());
			}

            if (_apiContext.CatalogId.HasValue && _apiContext.CatalogId.Value > 0)
			{
				AddHeader(Headers.X_VOL_CATALOG, _apiContext.CatalogId.Value.ToString());
			}
		}

        protected void SetBaseAddress(string baseAddress)
        {
            
            _baseAddress =  HttpHelper.GetUrl(baseAddress);
        }

        protected void SetVerb(string verb)
        {
            _verb = verb.ToLower();
        }

        protected void SetResourceUrl(MozuUrl resourceUrl)
        {
            _resourceUrl = resourceUrl;
        }

        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore};
        protected void SetBody(TBody body)
        {
            var stringContent = JsonConvert.SerializeObject(body, _jsonSerializerSettings);
            SetBody(stringContent);
            
        }

        protected void SetBody(Stream stream)
        {
            _streamContent = new StreamContent(stream);

        }

        protected void SetBody(string body)
        {
            _httpContent = new StringContent(body, Encoding.UTF8, "application/json");
        }

        protected void ValidateContext()
		{
			if (_resourceUrl.Location == MozuUrl.UrlLocation.TENANT_POD)
			{
				if (_apiContext == null)
				{
					_log.Info("API context not provided", new ApiException("API context not provided") { ApiContext = _apiContext });
					throw new ApiException("API context not provided");
				}

				if (_apiContext.TenantId < 0)
				{
                    _log.Info("TenantId is missing", new ApiException("TenantId is missing"){ApiContext = _apiContext});
                    throw new ApiException("TenantId is missing");
				}
					

				if (string.IsNullOrEmpty(_apiContext.TenantUrl))
				{
                    _log.Info( String.Format("Tenant {0} URL is empty. Getting tenant info.", _apiContext.TenantId));
					var tenantResource = new TenantResource();
					var tenant = tenantResource.GetTenant(_apiContext.TenantId);

					if (tenant == null)
					{
					    var apiException = new ApiException("Tenant " + _apiContext.TenantId + " Not found") {ApiContext = _apiContext};
                        _log.Error(apiException.Message, apiException);
                        throw apiException;
					}
						
                    _baseAddress = HttpHelper.GetUrl(tenant.Domain);
				}
                else
                    _baseAddress = HttpHelper.GetUrl(_apiContext.TenantUrl);

                
			}
			else
			{
				if (String.IsNullOrEmpty(_baseAddress) && string.IsNullOrEmpty(AppAuthenticator.Instance.BaseUrl))
				{
                    var apiException = new ApiException("Authentication.Instance.BaseUrl is missing");
                    _log.Error(apiException.Message, apiException);
				    throw apiException;
				}
					
                if (string.IsNullOrEmpty(_baseAddress))
    			    _baseAddress =   AppAuthenticator.Instance.BaseUrl;
			}

		}

        protected void ExecuteRequest()
        {
			ValidateContext();
            var client = GetHttpClient();
            _httpResponseMessage = client.SendAsync(GetRequestMessage(), HttpCompletionOption.ResponseContentRead).Result;
            ResponseHelper.EnsureSuccess(_httpResponseMessage,_apiContext);
        }
        
        private HttpRequestMessage GetRequestMessage()
        {
            var requestMessage = new HttpRequestMessage { RequestUri = new Uri(_baseAddress+_resourceUrl.Url) };
            requestMessage.Method = GetMethod();

            if ( (requestMessage.Method == HttpMethod.Post || requestMessage.Method == HttpMethod.Put) && (_httpContent != null || _streamContent != null))
            {
                if (_httpContent != null)
                {
                    if (_log.IsDebugEnabled)
                        _log.Debug(string.Format("{0} {1}", GetCorrelationId(), _httpContent.ReadAsStringAsync().Result));
                    requestMessage.Content = _httpContent;
                }
                else
                {
                    requestMessage.Content = _streamContent;
                    if (_contentType != null)
                        requestMessage.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue(_contentType);
                }
            }

            SetUserClaims();

            if (_headers[Headers.X_VOL_APP_CLAIMS] == null)
            {
                if (_apiContext == null || string.IsNullOrEmpty(_apiContext.AppAuthClaim))
                    AppAuthenticator.AddHeader(requestMessage);
                else
                    _headers.Add(Headers.X_VOL_APP_CLAIMS, _apiContext.AppAuthClaim);
            }
            
            AddHeader(Headers.X_VOL_VERSION, Version.ApiVersion);

            if (_apiContext != null && !String.IsNullOrEmpty(_apiContext.CorrelationId))
                AddHeader(Headers.X_VOL_CORRELATION, _apiContext.CorrelationId);

            foreach (var key in _headers.AllKeys)
            {
                requestMessage.Headers.Add(key, _headers[key]);
            }


            return requestMessage;
        }

        private void SetUserClaims()
        {
            if (_apiContext == null || _apiContext.UserAuthTicket == null) return;
            AuthTicket newAuthTicket = null;
            if (_apiContext.UserAuthTicket.AuthenticationScope == AuthenticationScope.Customer)
                newAuthTicket = CustomerAuthenticator.EnsureAuthTicket(_apiContext.UserAuthTicket);
            else
                newAuthTicket = UserAuthenticator.EnsureAuthTicket(_apiContext.UserAuthTicket);
            if (newAuthTicket != null)
            {
                _apiContext.UserAuthTicket.AccessToken = newAuthTicket.AccessToken;
                _apiContext.UserAuthTicket.AccessTokenExpiration = newAuthTicket.AccessTokenExpiration;
            }

            _headers.Add(Headers.X_VOL_USER_CLAIMS, _apiContext.UserAuthTicket.AccessToken);
        }

        private HttpMethod GetMethod()
        {
            switch (_verb.ToUpper())
            {
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "DELETE":
                    return HttpMethod.Delete;
                case "HEAD":
                    return HttpMethod.Head;
            }

            return HttpMethod.Get;
        }
 
        private HttpClient GetHttpClient()
        {
            Uri uri = new Uri(_baseAddress);
            var client = GetActualClient(uri);
            return client;
        }

        private HttpClient GetActualClient(Uri u)
        {
            string key = u.Host;
            if (!u.IsDefaultPort)
            {
                key = string.Format("{0}:{1}", key, u.Port.ToString());
            }

            if (!_clientsByHostName.ContainsKey(key))
            {
                var client = new HttpClient(new HttpClientHandler
                {
                    AllowAutoRedirect = false,
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip
                        | DecompressionMethods.Deflate
                });



                client.MaxResponseContentBufferSize = int.MaxValue;
                _clientsByHostName[key] = client;
            }

            return _clientsByHostName[key];
        }

        private string GetCorrelationId()
        {
            return _apiContext != null ? _apiContext.CorrelationId : string.Empty;
        }
    }
}

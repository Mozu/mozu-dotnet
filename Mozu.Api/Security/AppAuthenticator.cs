using System;
using System.Net.Http;
using System.Text;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Logging;
using Mozu.Api.Resources.Platform.Applications;
using Mozu.Api.Urls.Platform.Applications;
using Mozu.Api.Utilities;
using Newtonsoft.Json;
using AuthTicket = Mozu.Api.Contracts.AppDev.AuthTicket;

namespace Mozu.Api.Security
{
    /// <summary>
    /// This class handles Mozu application authentication.
    /// </summary>
    public sealed class AppAuthenticator
    {

        private static AppAuthenticator _auth = null;

        private static object _lockObj = new Object();

        private AppAuthInfo _appAuthInfo;

        private RefreshInterval _refreshInterval = null;

        private static ILogger _log = LogManager.GetLogger(typeof(AppAuthenticator));

		/// <summary>
		/// The application auth ticket
		/// </summary>
        public AuthTicket AppAuthTicket { get; protected set; }

		/// <summary>
		/// The baseUrl for App Auth.  Once an app auths with this base url, all subsequent MOZU API calls will go to this base url.
		/// </summary>
        public string BaseUrl { get; private set; }

        

		public static AppAuthenticator Instance
		{
			get { return _auth; }
		}

        public static bool UseSSL { get; protected set; }

        internal AppAuthInfo AppAuthInfo
        {
            get { return _appAuthInfo; }
        }

        public static AppAuthenticator Initialize(AppAuthInfo appAuthInfo, string baseAppAuthUrl, RefreshInterval refreshInterval = null)
        {
            


            if (appAuthInfo == null || string.IsNullOrEmpty(baseAppAuthUrl))
                throw new Exception("AppAuthInfo or Base App auth Url cannot be null or empty");

            if (String.IsNullOrEmpty(appAuthInfo.ApplicationId) || String.IsNullOrEmpty(appAuthInfo.SharedSecret))
                throw new Exception("ApplicationId or Shared Secret is missing");

            if (_auth == null || (_auth != null && _auth.AppAuthInfo.ApplicationId != appAuthInfo.ApplicationId))
            {
                lock (_lockObj)
                {
                    try
                    {
                        _log.Info("Initializing App");
                        var uri = new Uri(baseAppAuthUrl);
                        HttpHelper.UrlScheme = uri.Scheme;
                        _auth = new AppAuthenticator(appAuthInfo, baseAppAuthUrl, refreshInterval);
                        _auth.AuthenticateApp();
                        _log.Info("Initializing App..Done");

                    }
                    catch (ApiException exc)
                    {
                        _log.Error(exc.Message, exc);
                        _auth = null;
                        throw exc;
                    }
                }
            }

            return _auth;
        }

        /// <summary>
        /// This contructor does application authentication and setups up the necessary timers to keep the app auth ticket valid.
        /// </summary>
        /// <param name="appId">The application version's app id</param>
        /// <param name="sharedSecret">The application version's shared secret</param>
        /// <param name="baseAppAuthUrl">The base URL of the Mozu application authentication service</param>
        private AppAuthenticator(AppAuthInfo appAuthInfo, string baseAppAuthUrl, RefreshInterval refreshInterval = null)
        {
            BaseUrl = baseAppAuthUrl;
            _appAuthInfo = appAuthInfo;
            _refreshInterval = refreshInterval;

            MozuConfig.SharedSecret = appAuthInfo.SharedSecret;
            MozuConfig.ApplicationId = appAuthInfo.ApplicationId;
        }

        public static void DeleteAuth()
        {
            if (_auth != null)
            {
                var resourceUrl = AuthTicketUrl.DeleteAppAuthTicketUrl(_auth.AppAuthTicket.RefreshToken);
                var client = new HttpClient { BaseAddress = new Uri(_auth.BaseUrl) };
                var response = client.DeleteAsync(resourceUrl.Url).Result;
                ResponseHelper.EnsureSuccess(response);
            }
        }

        /// <summary>
        /// Do application authentication
        /// </summary>
        private void AuthenticateApp()
        {
            var resourceUrl = AuthTicketUrl.AuthenticateAppUrl();
            _log.Info(String.Format("App authentication Url : {0}{1}", BaseUrl, resourceUrl.Url) );
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            var stringContent = JsonConvert.SerializeObject(_appAuthInfo);
            var response = client.PostAsync(resourceUrl.Url, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            ResponseHelper.EnsureSuccess(response);

            AppAuthTicket = response.Content.ReadAsAsync<AuthTicket>().Result;

            SetRefreshIntervals(true);

           
        }
        
        /// <summary>
        /// Refresh the application auth ticket using the refresh token
        /// </summary>
        private void RefreshAppAuthTicket()
        {

            var resourceUrl = AuthTicketUrl.RefreshAppAuthTicketUrl();
            _log.Info(String.Format("App authentication refresh Url : {0}{1}", BaseUrl, resourceUrl.Url));
			var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            var authTicketRequest = new AuthTicketRequest { RefreshToken = AppAuthTicket.RefreshToken };
            var stringContent = JsonConvert.SerializeObject(authTicketRequest);

            var response = client.PutAsync(resourceUrl.Url, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            
            ResponseHelper.EnsureSuccess(response);

            AppAuthTicket = response.Content.ReadAsAsync<AuthTicket>().Result;

            SetRefreshIntervals(false);

        }
        
        
        
        private void SetRefreshIntervals(bool updateRefreshTokenInterval)
        {
            if (_refreshInterval == null)
            {
                _log.Info(String.Format("Access token expires at : {0}", AppAuthTicket.AccessTokenExpiration ));
                _log.Info(String.Format("Refresh token expires at : {0}", AppAuthTicket.RefreshTokenExpiration ));

                _refreshInterval =
                    new RefreshInterval((long) (AppAuthTicket.AccessTokenExpiration - DateTime.Now).TotalSeconds - 180,
                                        (long)(AppAuthTicket.RefreshTokenExpiration - DateTime.Now).TotalSeconds - 180);
            }

            _refreshInterval.UpdateExpirationDates(updateRefreshTokenInterval);
        }

        /// <summary>
        /// Ensure that the auth ticket is valid.  If not, then make it so.  Will be used when not using timers to keep the auth ticket alive (i.e. "on demand" mode).
        /// </summary>
        public void EnsureAuthTicket()
        {
            lock (_lockObj)
            {
                if (AppAuthTicket == null || DateTime.UtcNow >= _refreshInterval.RefreshTokenExpiration)
                {
                    _log.Info("Refresh token Expired");
                    AuthenticateApp();
                }
                else if (DateTime.UtcNow >= _refreshInterval.AccessTokenExpiration)
                {
                    _log.Info("Access token expored");
                    RefreshAppAuthTicket();
                }
            }
        }
        
        /// <summary>
        /// This method adds the necessary app claims header to a http client to allow authorized calls to Mozu services
        /// </summary>
        /// <param name="client">The http client for which to add the header</param>
        public static void AddHeader(HttpClient client)
        {
            if (_auth == null)
            {
                _log.Error("App is not initialized");
                throw new ApplicationException("AppAuthTicketKeepAlive Not Initialized");
            }

            _auth.EnsureAuthTicket();
            client.DefaultRequestHeaders.Add(Headers.X_VOL_APP_CLAIMS, _auth.AppAuthTicket.AccessToken);
        }

        public static void AddHeader(HttpRequestMessage requestMsg)
        {
            if (_auth == null)
            {
                _log.Error("App is not initialized");
                throw new ApplicationException("AppAuthTicketKeepAlive Not Initialized");
            }

            _auth.EnsureAuthTicket();
            requestMsg.Headers.Add(Headers.X_VOL_APP_CLAIMS, _auth.AppAuthTicket.AccessToken);
        }

    }
}

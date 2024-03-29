using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Logging;
using Mozu.Api.Urls.Platform.Applications;
using Mozu.Api.Utilities;
using Newtonsoft.Json;

namespace Mozu.Api.Security
{
    /// <summary>
    /// This class handles Mozu application authentication.
    /// </summary>
    public sealed class AppAuthenticator
    {
        private static ConcurrentDictionary<string, HttpClient> _clientsByHostName = new ConcurrentDictionary<string, HttpClient>();
        private static AppAuthenticator _auth = null;

        private static object _lockObj = new Object();

        private AppAuthInfo _appAuthInfo;

        private RefreshInterval _refreshInterval = null;

        private static ILogger _log = LogManager.GetLogger(typeof(AppAuthenticator));
        private static SemaphoreSlim _semaphoreWaiter = new SemaphoreSlim(1);

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

        public static bool UseSSL { get; set; }

        internal AppAuthInfo AppAuthInfo
        {
            get { return _appAuthInfo; }
        }

        public static AppAuthenticator Initialize(AppAuthInfo appAuthInfo, RefreshInterval refreshInterval = null)
        {

			var baseAppAuthUrl = MozuConfig.BaseAppAuthUrl;

            if (appAuthInfo == null || string.IsNullOrEmpty(baseAppAuthUrl))
                throw new Exception("AppAuthInfo or Base App auth Url cannot be null or empty");

            if (String.IsNullOrEmpty(appAuthInfo.ApplicationId) || String.IsNullOrEmpty(appAuthInfo.SharedSecret))
                throw new Exception("ApplicationId or Shared Secret is missing");

            if (_auth == null || (_auth != null && _auth.AppAuthInfo.ApplicationId != appAuthInfo.ApplicationId))
            {
                _semaphoreWaiter.Wait();
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
                    finally
                    {
                        _semaphoreWaiter.Release();
                    }
                }
            }

            return _auth;
        }

		public static async Task<AppAuthenticator> InitializeAsync(AppAuthInfo appAuthInfo,  RefreshInterval refreshInterval = null)
		{
            var baseAppAuthUrl = MozuConfig.BaseAppAuthUrl;
			if (appAuthInfo == null || string.IsNullOrEmpty(baseAppAuthUrl))
				throw new Exception("AppAuthInfo or Base App auth Url cannot be null or empty");

			if (String.IsNullOrEmpty(appAuthInfo.ApplicationId) || String.IsNullOrEmpty(appAuthInfo.SharedSecret))
				throw new Exception("ApplicationId or Shared Secret is missing");

		    if (_auth != null && _auth.AppAuthInfo.ApplicationId == appAuthInfo.ApplicationId)
		        return _auth;
		    try
		    {
                await _semaphoreWaiter.WaitAsync();
                // Double check to make sure that someone else didn't already initialize it while we were waiting
                if (_auth == null || (_auth != null && _auth.AppAuthInfo.ApplicationId != appAuthInfo.ApplicationId))
                {
                    try
		            {
		                _log.Info("Initializing App");
		                var uri = new Uri(baseAppAuthUrl);
		                HttpHelper.UrlScheme = uri.Scheme;
		                var tmp = new AppAuthenticator(appAuthInfo, baseAppAuthUrl, refreshInterval);
		                await tmp.AuthenticateAppAsync();
		                _auth = tmp;
		                
		            }
		            finally
		            {
		                _semaphoreWaiter.Release();
                    }
                    _log.Info("Initializing App..Done");
                }
            }
		    catch (ApiException exc)
		    {
		        _log.Error(exc.Message, exc);
		        _auth = null;
		        throw exc;
		    }

		    return _auth;
		}

        private static HttpClient GetActualClient(Uri u)
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
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip
                        | DecompressionMethods.Deflate,

                });

                client.BaseAddress = u;
                client.Timeout = TimeSpan.FromSeconds(MozuConfig.ClientTimeoutInSeconds);
                client.MaxResponseContentBufferSize = int.MaxValue;
                _clientsByHostName[key] = client;
            }

            return _clientsByHostName[key];
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
                var client = GetActualClient(new Uri(_auth.BaseUrl));
                var response = client.DeleteAsync(resourceUrl.Url).Result;
                ResponseHelper.EnsureSuccess(response);
            }
        }

		public static async Task DeleteAuthAsync()
		{
			if (_auth != null)
			{
				var resourceUrl = AuthTicketUrl.DeleteAppAuthTicketUrl(_auth.AppAuthTicket.RefreshToken);
                var client = GetActualClient(new Uri(_auth.BaseUrl));
                var response = await client.DeleteAsync(resourceUrl.Url);
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
            var client =  GetActualClient(new Uri(BaseUrl));
            var stringContent = JsonConvert.SerializeObject(_appAuthInfo);
            var response = client.PostAsync(resourceUrl.Url, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            ResponseHelper.EnsureSuccess(response);

            AppAuthTicket = response.Content.ReadAsAsync<AuthTicket>().Result;

            SetRefreshIntervals(true);


		}
		private async Task AuthenticateAppAsync()
		{
			var resourceUrl = AuthTicketUrl.AuthenticateAppUrl();
			_log.Info(String.Format("App authentication Url : {0}{1}", BaseUrl, resourceUrl.Url));
			var client = GetActualClient(new Uri(BaseUrl));
            var stringContent = JsonConvert.SerializeObject(_appAuthInfo);
			var response = await client.PostAsync(resourceUrl.Url, new StringContent(stringContent, Encoding.UTF8, "application/json"));
			ResponseHelper.EnsureSuccess(response);

			AppAuthTicket = await response.Content.ReadAsAsync<AuthTicket>();

			SetRefreshIntervals(true);
		}
        
        /// <summary>
        /// Refresh the application auth ticket using the refresh token
        /// </summary>
        private void RefreshAppAuthTicket()
        {

            var resourceUrl = AuthTicketUrl.RefreshAppAuthTicketUrl();
            _log.Info(String.Format("App authentication refresh Url : {0}{1}", BaseUrl, resourceUrl.Url));
			var client = GetActualClient(new Uri(BaseUrl));
            var authTicketRequest = new AuthTicketRequest { RefreshToken = AppAuthTicket.RefreshToken };
            var stringContent = JsonConvert.SerializeObject(authTicketRequest);

            var response = client.PutAsync(resourceUrl.Url, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            
            ResponseHelper.EnsureSuccess(response);

            AppAuthTicket = response.Content.ReadAsAsync<AuthTicket>().Result;

            SetRefreshIntervals(false);

		}

		private async Task RefreshAppAuthTicketAsync()
		{

			var resourceUrl = AuthTicketUrl.RefreshAppAuthTicketUrl();
			_log.Info(String.Format("App authentication refresh Url : {0}{1}", BaseUrl, resourceUrl.Url));
			var client = GetActualClient(new Uri(BaseUrl));
            var authTicketRequest = new AuthTicketRequest { RefreshToken = AppAuthTicket.RefreshToken };
			var stringContent = JsonConvert.SerializeObject(authTicketRequest);

			var response = await client.PutAsync(resourceUrl.Url, new StringContent(stringContent, Encoding.UTF8, "application/json"));

			ResponseHelper.EnsureSuccess(response);

			AppAuthTicket = await response.Content.ReadAsAsync<AuthTicket>();

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
        Task _authenticateAppAsyncTask;
        Task _refreshAppAuthTicketAsyncTask;
        Task _completeTask = Task.FromResult<bool>(true);

        /// <summary>
        /// Ensure that the auth ticket is valid.  If not, then make it so.  Will be used when not using timers to keep the auth ticket alive (i.e. "on demand" mode).
        /// </summary>
        /// <returns>Waitable Task</returns>
        public Task EnsureAuthTicketAsync()
		{
			
			if (AppAuthTicket == null || DateTime.UtcNow >= _refreshInterval.RefreshTokenExpiration)
			{
                if (_authenticateAppAsyncTask != null && 
                    !_authenticateAppAsyncTask.IsCanceled &&
                    !_authenticateAppAsyncTask.IsFaulted &&
                    !_authenticateAppAsyncTask.IsCompleted)
                {
                    return _authenticateAppAsyncTask;
                }
				_log.Info("Refresh token Expired");
                return _authenticateAppAsyncTask =  AuthenticateAppAsync();
			}
			else if (DateTime.UtcNow >= _refreshInterval.AccessTokenExpiration)
			{
                //return inflight task
                if (_refreshAppAuthTicketAsyncTask != null &&
                    !_refreshAppAuthTicketAsyncTask.IsCanceled &&
                    !_refreshAppAuthTicketAsyncTask.IsFaulted &&
                    !_refreshAppAuthTicketAsyncTask.IsCompleted)
                {
                    return _refreshAppAuthTicketAsyncTask;
                }
                _log.Info("Access token expored");
                return _refreshAppAuthTicketAsyncTask= RefreshAppAuthTicketAsync();
			}
            return _completeTask;


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

        public static async Task AddHeaderAsync(HttpRequestMessage requestMsg)
        {
            if (_auth == null)
            {
                _log.Error("App is not initialized");
                throw new ApplicationException("AppAuthTicketKeepAlive Not Initialized");
            }

            await _auth.EnsureAuthTicketAsync();
            requestMsg.Headers.Add(Headers.X_VOL_APP_CLAIMS, _auth.AppAuthTicket.AccessToken);
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

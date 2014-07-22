using System;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Security;
using Newtonsoft.Json;

namespace Mozu.Api.Test.Helpers
{
    public class BaseDataFactory
    {
        // Fields for every Test Factory
        #region Fields
            public static string AppId = "";
            public static string SharedSecret = "";
            public static string BaseAuthAppUrl = "";
            public static Environments Environment;
            public static bool IsIntialized = false;
        #endregion
        /// <summary>
        /// Constructor for Every Test Factory
        /// </summary>
        static BaseDataFactory() 
        {
            if (!IsIntialized)
            {
                Environment = Helpers.Environment.GetConfigEnvironment();
                SetSdKparameters();
            }
        }

        /// <summary>
        /// Using the Configuration File set the SDK Test Parameters  
        /// Custom config FilePath comes from: ConfigurationManager.AppSettings["SDKConfig"] in the App.Config
        /// </summary>
        public static void SetSdKparameters()
        {
            if (!IsIntialized)
            {
                if (AppId.Length == 0) // hasn't been set yet.
                {
                    AppId = Helpers.Environment.GetConfigValueByEnvironment(Environment, "AppId");
                }
                if (SharedSecret.Length == 0) // hasn't been set yet.
                {
                    SharedSecret = Helpers.Environment.GetConfigValueByEnvironment(Environment, "SharedSecret");
                }
                if (BaseAuthAppUrl.Length == 0) // hasn't been set yet.
                {
                    BaseAuthAppUrl = Helpers.Environment.GetConfigValueByEnvironment(Environment, "BaseAuthAppUrl");
                }
                if (SharedSecret.Length > 0 && BaseAuthAppUrl.Length > 0 && AppId.Length > 0)
                {
                    AuthenticateSdk(appId: AppId, sharedSecret: SharedSecret, baseAuthAppUrl: BaseAuthAppUrl);
                }
            }
        }
        /// <summary>
        /// Authenticate The Application (SDK Tests)
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="sharedSecret"></param>
        /// <param name="baseAuthAppUrl"></param>
        public static void AuthenticateSdk(string appId, string sharedSecret, string baseAuthAppUrl)
        {
            try
            {
                AppAuthenticator.Initialize(
                    appAuthInfo: new AppAuthInfo()
                    {
                        ApplicationId = AppId,
                        SharedSecret = SharedSecret
                    },
                    baseAppAuthUrl: BaseAuthAppUrl);
                IsIntialized = true;
            }
            catch (Exception ex)
            {
                throw new Exception("App Authentication did not work. " + ex.Message);
            }
        }


        /// <summary>
        /// Reset the SDK Parameters from the config file.
        /// </summary>
        public static void ResetSdKparameters()
        {
            AppId = Helpers.Environment.GetConfigValueByEnvironment(Environment, "AppId");
            SharedSecret = Helpers.Environment.GetConfigValueByEnvironment(Environment, "SharedSecret");
            BaseAuthAppUrl = Helpers.Environment.GetConfigValueByEnvironment(Environment, "BaseAuthAppUrl");
        }
    }
}

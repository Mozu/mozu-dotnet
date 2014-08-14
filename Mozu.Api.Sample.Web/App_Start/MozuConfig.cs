using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Logging;
using Mozu.Api.Security;
using Autofac;

namespace Mozu.Api.Sample.Web
{
    public class MozuConfig
    {
        public static void Register()
        {
            var configFile = ConfigurationManager.AppSettings["MozuConfig"];

            if (!File.Exists(configFile))
                throw new IOException("MozuConfig File not found");
            var configFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = configFile
            };

            var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            var environment = config.AppSettings.Settings["Environment"].Value;
            var appId = config.AppSettings.Settings["AppId_" + environment].Value;
            var sharedSecret = config.AppSettings.Settings["SharedSecret_" + environment].Value;
            var baseUrl  = config.AppSettings.Settings["BaseAuthAppUrl_" + environment].Value;


            LogManager.LoggingService =  DependencyResolver.Current.GetService<ILoggingService>();
            AppAuthenticator.Initialize(new AppAuthInfo { ApplicationId = appId, SharedSecret = sharedSecret},baseUrl);
        }
    }
}
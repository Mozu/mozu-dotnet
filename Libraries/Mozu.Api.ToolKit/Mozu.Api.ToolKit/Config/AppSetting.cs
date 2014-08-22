using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Mozu.Api.ToolKit.Config
{

    public class AppSetting : IAppSetting
    {
        public string AppName { get; private set; }
        public string ApplicationId { get; private set; }
        public string SharedSecret { get; private set; }
        public string SMTPServerUrl { get; private set; }
        public string BaseUrl { get; private set; }
        public string Log4NetConfig { get; private set; }
        public IDictionary<string, Object> Settings { get; private set; }

        public AppSetting()
        {
            InitAppConfig();
        }

        public AppSetting(string configPath, string appName, string environment)
        {
            Init(configPath, appName, environment);
        }

        private void InitAppConfig()
        {
            Settings = new Dictionary<string, object>();

            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                Settings.Add(key, ConfigurationManager.AppSettings[key]);
            }

            if (Settings.ContainsKey("SmptServer"))
                SMTPServerUrl = Settings["SmptServer"].ToString();

            //if (!Settings.ContainsKey("MozuAuthUrl"))
            //    throw new Exception("MozuAuthUrl is not set in config file");

            //BaseUrl = Settings["BaseUrl"].ToString();


            if (Settings.ContainsKey("AppName"))
                AppName = Settings["AppName"].ToString();

            SetProperties();

            if (String.IsNullOrEmpty(ApplicationId))
                throw new Exception("ApplicationID not set in config file");

            if (String.IsNullOrEmpty(SharedSecret))
                throw new Exception("SharedSecret not set in config file");
        }


        private void SetProperties()
        {
           
            if (Settings.ContainsKey("ApplicationId"))
                ApplicationId = Settings["ApplicationId"].ToString();

            if (Settings.ContainsKey("SharedSecret"))
                SharedSecret = Settings["SharedSecret"].ToString();
        }

        private void Init(string configPath, string appName, string environment)
        {
            AppName = appName;
            var appConfig = Path.Combine(configPath, appName, "App.config");
            Log4NetConfig = Path.Combine(configPath, appName, "log4net.config");
            var commonConfig = Path.Combine(configPath, "Common.config");

            if (!File.Exists(appConfig))
                throw new IOException("Settings File not found");

            if (!File.Exists(commonConfig))
                throw new IOException("Url setting File not found");


            var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = appConfig };
            var commonFileMap = new ExeConfigurationFileMap { ExeConfigFilename = commonConfig };

            var configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            var commonConfiguration = ConfigurationManager.OpenMappedExeConfiguration(commonFileMap, ConfigurationUserLevel.None);

            BaseUrl = commonConfiguration.AppSettings.Settings[environment].Value;

            if (environment.Equals("PROD"))
                SMTPServerUrl = commonConfiguration.AppSettings.Settings["SmtpServer_" + environment].Value;
            else
                SMTPServerUrl = commonConfiguration.AppSettings.Settings["SmtpServer"].Value;

           
            
            Settings = new Dictionary<string, object>();

            foreach (var key in configuration.AppSettings.Settings.AllKeys)
            {
                if (key.EndsWith("_"+environment))
                    Settings.Add(key.Replace("_"+environment, ""), configuration.AppSettings.Settings[key].Value);
                else
                    Settings.Add(key, configuration.AppSettings.Settings[key].Value);
            }


            foreach (var key in ConfigurationManager.AppSettings.AllKeys.Where(key => !Settings.ContainsKey(key)))
            {
                Settings.Add(key, ConfigurationManager.AppSettings[key]);
            }

            SetProperties();
        }

    }
}

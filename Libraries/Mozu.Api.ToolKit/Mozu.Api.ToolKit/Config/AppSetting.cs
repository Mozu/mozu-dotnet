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
        public string Namespace { get; private set; }
        public string Version { get; private set; }
        public string PackageName { get; private set; }

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

            if (Settings.ContainsKey("SmtpServer"))
                SMTPServerUrl = Settings["SmtpServer"].ToString();


            if (Settings.ContainsKey("MozuAuthUrl"))
                BaseUrl = Settings["MozuAuthUrl"].ToString();

            if (Settings.ContainsKey("AppName"))
                AppName = Settings["AppName"].ToString();

            SetProperties();
           
        }


        private void SetProperties()
        {

            if (Settings.ContainsKey("ApplicationId"))
            {
                ApplicationId = Settings["ApplicationId"].ToString();
                ParseAppKey();
               
            }


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
                Settings.Add(key.EndsWith("_" + environment) ? key.Replace("_" + environment, "") : key,
                    configuration.AppSettings.Settings[key].Value);
            }


            foreach (var key in ConfigurationManager.AppSettings.AllKeys.Where(key => !Settings.ContainsKey(key)))
            {
                Settings.Add(key, ConfigurationManager.AppSettings[key]);
            }

            SetProperties();
        }
        
        private void ParseAppKey()
        {
            var parts = ApplicationId.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 4) return;

            Namespace = parts[0];

            PackageName = "Release";
            var packageNameOffset = 0;
            var lastPart = parts[parts.Length - 1];
            int testInt;
            bool cc = int.TryParse(lastPart, out testInt);
            if (!cc)
            {
                // check if the last part is an int, then it is the revision of the version
                // otherwise, it is the package name
                PackageName = parts[parts.Length - 1];
                packageNameOffset = 1;
            }
     
     
            // parse version
            var versionStartIndex = parts.Length - (3 + packageNameOffset);
            Version = String.Join(".", parts, versionStartIndex, 3);
        }

    }
}

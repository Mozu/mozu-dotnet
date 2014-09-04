using System.Configuration;
using System.IO;

namespace Mozu.Api.Test.Helpers
{
    using System;

    /// <summary>
    /// Enum Environments
    /// </summary>
    [Flags]
    public enum Environments
    {
        Dev,
        CI,
        QA,
        Prod,
        SI,
        Demo
    }

    [Flags]
    public enum ScaleUnitId
    {
        None,
        HP1,
        TP1,
        TP2,
        SB,
        PC1,
        PCI,
        Su1
    }

    public static class Environment
    {
        public static void HardRefreshConfigs()
        {
            var exeMap = new ExeConfigurationFileMap();
            exeMap.ExeConfigFilename = "app.config";
            var exeConfig = ConfigurationManager.OpenMappedExeConfiguration(exeMap, ConfigurationUserLevel.None);

            string configFile = "app.config";
            exeConfig.SaveAs(configFile, ConfigurationSaveMode.Full);

            //exeConfig.AppSettings["appSettings"];
            //ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");
        }
       
        public static Environments GetConfigEnvironment()
        {
            //ConfigurationManager.RefreshSection("appSettings");
           // var envir = ConfigurationManager.AppSettings["Environment"];
            // Create configuration reader that reads the files once
            var sdkConfigFile = ConfigurationManager.AppSettings["SDKConfig"];
            if (!File.Exists(sdkConfigFile))
                throw new FileNotFoundException(sdkConfigFile);
            var configFileReader = new CustomConfigurationFileReader(sdkConfigFile);
            var config = configFileReader.Config;

            var envir = config.AppSettings.Settings["Environment"].Value;

            if (string.IsNullOrEmpty(envir))
            {
                envir = "SI";
            }
            switch (envir.ToUpper())
            {
                case "DEV":
                    return Environments.Dev;
                case "CI":
                    return Environments.CI;
                case "SI":
                    return Environments.SI;
                case "QA":
                    return Environments.QA;
                case "DEMO":
                    return Environments.Demo;
                case "PROD":
                    return Environments.Prod;
                default:
                    return Environments.SI;
            }
        }
        
        public static void SetConfigEnvironment(Environments environmentId)
        {
            UpdateConfigSetting("Environment", environmentId.ToString());
        }
        
        public static void UpdateConfigSetting(string key, string value)
        {
            try
            {
                var sdkConfigFile = ConfigurationManager.AppSettings["SDKConfig"];
                var configFileReader = new CustomConfigurationFileReader(sdkConfigFile);
                var config = configFileReader.Config;

                config.AppSettings.Settings.Remove(key);
                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                // just means the test cases do not have the same App.config as was setup by the default SDK test.
            }

        } 

        public static void SetConfigAppId(Environments environment, string AppId)
        {
            UpdateConfigSetting("AppId_" + environment.ToString(), AppId);
        }

        public static string GetConfigValueByEnvironment(Environments environment, string keyPart)
        {
            try
            {
                var sdkConfigFile = ConfigurationManager.AppSettings["SDKConfig"];
                var configFileReader = new CustomConfigurationFileReader(sdkConfigFile);
                var config = configFileReader.Config;
                var setting = config.AppSettings.Settings[keyPart + "_" + environment.ToString()].Value;
                return setting;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static string GetConfigValueByEnvironment(string keyPart)
        {
            try
            {
                var environment = GetConfigEnvironment();
                var sdkConfigFile = ConfigurationManager.AppSettings["SDKConfig"];
                var configFileReader = new CustomConfigurationFileReader(sdkConfigFile);
                var config = configFileReader.Config;
                var setting = config.AppSettings.Settings[keyPart + "_" + environment.ToString()].Value;
                return setting;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static void UpdateConfigValueByEnvironment(string keyPart, string value)
        {
            try
            {
                var environment = GetConfigEnvironment();
                var sdkConfigFile = ConfigurationManager.AppSettings["SDKConfig"];
                var configFileReader = new CustomConfigurationFileReader(sdkConfigFile);
                var config = configFileReader.Config;
                config.AppSettings.Settings.Remove(keyPart + "_" + environment.ToString());
                config.AppSettings.Settings.Add(keyPart + "_" + environment.ToString(), value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

            }
            catch (Exception)
            {
                //
            }

        }
        public static void UpdateConfigValueByEnvironment(Environments environment, string keyPart, string value)
        {
            try
            {
                var sdkConfigFile = ConfigurationManager.AppSettings["SDKConfig"];
                var configFileReader = new CustomConfigurationFileReader(sdkConfigFile);
                var config = configFileReader.Config;
                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove(keyPart + "_" + environment.ToString());
                config.AppSettings.Settings.Add(keyPart + "_" + environment.ToString(), value);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception)
            {
                //
            }

        }
    }
}
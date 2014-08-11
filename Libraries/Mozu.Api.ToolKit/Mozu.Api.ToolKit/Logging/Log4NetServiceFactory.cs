using System;
using System.IO;
using log4net.Config;
using Mozu.Api.Logging;
using Mozu.Api.ToolKit.Config;

namespace Mozu.Api.ToolKit.Logging
{
    public class Log4NetServiceFactory : ILoggingServiceFactory
    {
        protected static readonly Object Lock = new Object();
        protected static bool IsInitialized;

        public ILoggingService GetLoggingService()
        {
            return new Log4NetService();
        }

        public Log4NetServiceFactory(IAppSetting appSetting)
		{
			LoadLog4NetConfigFile(appSetting.Log4NetConfig);
		}

	
		private void LoadLog4NetConfigFile(string configFile)
		{
			lock (Lock)
			{
				if (IsInitialized) return;

                var configFileNameIsAFullPath = File.Exists(configFile);
				if (configFileNameIsAFullPath)
				{
					XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
				}
				
				IsInitialized = true;
			}
		}
    }
}

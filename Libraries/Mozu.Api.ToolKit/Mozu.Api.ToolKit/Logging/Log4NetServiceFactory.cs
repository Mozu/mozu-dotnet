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
        private readonly IAppSetting _appSetting;

        public ILoggingService GetLoggingService()
        {
            return new Log4NetService();
        }

        public Log4NetServiceFactory(IAppSetting appSetting)
        {
            _appSetting = appSetting;
			LoadLog4NetConfigFile();
		}

	
		private void LoadLog4NetConfigFile()
		{
            if (IsInitialized) return;
		    lock (Lock)
		    {

		        if (_appSetting.Settings.ContainsKey("log4net.config"))
		        {
                    XmlConfigurator.ConfigureAndWatch(new FileInfo(_appSetting.Settings["log4net.config"].ToString()));
    	        }
		        else if (File.Exists(_appSetting.Log4NetConfig))
		        {
		            XmlConfigurator.ConfigureAndWatch(new FileInfo(_appSetting.Log4NetConfig));
		        }
		        else
		        {
		            BasicConfigurator.Configure();
		        }
                IsInitialized = true;
		    }
		}
    }
}

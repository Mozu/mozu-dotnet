using System;
using System.Collections.Generic;

namespace Mozu.Api.ToolKit.Config
{
    public interface IAppSetting
    {
        string AppName { get; }
        string ApplicationId { get; }
        string SharedSecret { get; }
        string BaseUrl { get; }
        string SMTPServerUrl { get; }
        IDictionary<string, Object> Settings { get; }
        string Log4NetConfig { get; }
        string Namespace { get;  }
        string Version { get;  }
        string PackageName { get; }
    }
}

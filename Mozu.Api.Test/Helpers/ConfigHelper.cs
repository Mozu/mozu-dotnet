using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Mozu.Api.Test.Helpers
{
    public static class ConfigHelper
    {
        public static IConfigurationRoot GetConfigBuilder(string config, string location = null)
        {
            if (string.IsNullOrEmpty(location))
            {
                location = Directory.GetCurrentDirectory();
            }
            return new ConfigurationBuilder()
                       .SetBasePath(location)
                       .AddJsonFile(config, optional: true, reloadOnChange: true)
                       .Build();
        }

        public static string GetValueFromAppSettings(this IConfigurationRoot configuration, string key)
        {
            var section = configuration.GetSection("appSettings").GetChildren();
            foreach (var item in section)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return string.Empty;
        }

        public static NameValueCollection GetKeyValuePairsFromAppSettings(this IConfigurationRoot configuration)
        {
            var collection = new NameValueCollection();
            foreach(var item in configuration.GetSection("appSettings").GetChildren())
            {
                collection.Add(item.Key, item.Value);
            }
            return collection;
        }
    }
}

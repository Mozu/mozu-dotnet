using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mozu.Api.WebToolKit
{
    public class Helper
    {
        

        public static Models.Version GetVersions()
        {
            var sdkVersion = Assembly.GetAssembly(typeof(MozuClient)).GetName();
            var appVersion = Assembly.GetCallingAssembly().GetName();

            var version = new Models.Version
            {
                APIVersion = Version.ApiVersion,
                SDKVersion = GetVersionStr(sdkVersion.Version),
                AppVersion = GetVersionStr(appVersion.Version),
                Assemblies = new List<Models.AssemblyInfo>()
            };


            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                version.Assemblies.Add(new Models.AssemblyInfo { Name = assembly.GetName().Name, Version = GetVersionStr(assembly.GetName().Version) });
            }

            return version;
        }

        private static string GetVersionStr(System.Version version)
        {
            return string.Format("v{0}.{1}.{2}", version.Major, version.Minor, version.MinorRevision);
        }
    }
}

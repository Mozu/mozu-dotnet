using System.Collections.Generic;

namespace Mozu.Api.WebToolKit.Models
{
    public class Version
    {
        public string AppVersion { get; set; }
        public string SDKVersion { get; set; }
        public string APIVersion { get; set; }

        public List<AssemblyInfo> Assemblies { get; set; } 
    }

    public class AssemblyInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}

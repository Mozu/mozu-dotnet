using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api
{
    public class MozuConfig
    {
        private static bool _enableCache = true;
        private static int _capabilityTimeoutInSeconds = 180;
        private static int _eventTimeoutInSeconds = 180;

        public static string SharedSecret { get; internal set; }
        public static string ApplicationId { get; internal set; }

        public static bool EnableCache { 
            get { return _enableCache; }
            set { _enableCache = value; }
        }


        public static int CapabilityTimeoutInSeconds
        {
            get { return _capabilityTimeoutInSeconds; }
            set { _capabilityTimeoutInSeconds = value; } 
        }

        public static int EventTimeoutInSeconds
        {
            get { return _eventTimeoutInSeconds; }
            set { _eventTimeoutInSeconds = value; } 
        }
    }
}

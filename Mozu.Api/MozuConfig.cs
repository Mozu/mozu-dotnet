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
		private static string _baseAppAuthUrl = "https://home.mozu.com";

        /// <summary>
        /// Payment service url
        /// use https://payments-sb.mozu.com for sandbox tenants
        /// use the default https://pmts.mozu.com for production tenants.
        /// </summary>
		private static string _basePciUrl = "https://pmts.mozu.com";

		private static bool _throwExceptionOn404 = false;

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

		public static string BaseAppAuthUrl
		{
			get { return _baseAppAuthUrl; }
			set { _baseAppAuthUrl = value; }
		}

		public static string BasePciUrl
		{
			get { return _basePciUrl; }
			set { _basePciUrl = value; }
		}

		public static bool ThrowExceptionOn404
		{
            get { return _throwExceptionOn404; }
            set { _throwExceptionOn404 = value; }
        }
    }
}

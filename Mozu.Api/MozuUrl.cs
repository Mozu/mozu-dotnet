using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api
{
	public class MozuUrl
	{
		public enum UrlLocation
		{
			HOME_POD,
			TENANT_POD
		}

		public string Url { get; set; }
		public UrlLocation Location { get; set; }
        public bool UseSSL { get; set; }

		public MozuUrl(string url, UrlLocation location, bool useSSL)
		{
			Url = url.ToLower();
			Location = location;
            UseSSL = useSSL;
		}

		public void FormatUrl(string paramName, object value)
		{
		    paramName = paramName.ToLower();
            Url = Url.Replace("{" + paramName + "}", value == null ? "" : value.ToString());
            Url = Url.Replace("{*" + paramName + "}", value == null ? "" : value.ToString());
			var removeString = "&" + paramName + "=";
            if (value == null && Url.Contains(removeString)) Url = Url.Replace(removeString, "");

			removeString = paramName + "=";
            if (value == null && Url.Contains(removeString)) Url = Url.Replace(removeString, "");

			removeString = "/?";
            if (Url.EndsWith(removeString)) Url = Url.Replace(removeString, "");
            if (Url.EndsWith(removeString + "&")) Url = Url.Replace(removeString + "&", "");
            if (Url.EndsWith("&")) Url = Url.Substring(0, Url.Length - 1);

            if (Url.Contains("/?&")) Url = Url.Replace("/?&", "/?");

            if (Url.EndsWith("?")) Url = Url.Replace("?", "");
		}
	}
}

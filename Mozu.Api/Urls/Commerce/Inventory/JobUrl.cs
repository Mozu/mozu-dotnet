using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Urls.Commerce.Inventory
{
	/// <summary>
	/// 
	/// </summary>
    public partial class JobUrl
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="jobID"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl GetJobUrl(long? jobID, string responseFields = null)
		{
			var url = "/api/commerce/inventory/v1/queue/{jobID}/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("jobID", jobID);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationCode"></param>
		/// <param name="limit"></param>
		/// <param name="owner"></param>
		/// <param name="types"></param>
		/// <param name="originalFilename"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl GetJobsUrl(string locationCode, int? limit, string owner, List<string> types, string originalFilename, string responseFields = null)
		{
			var url = "/api/commerce/inventory/v1/queue?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("locationCode", locationCode);
			mozuUrl.FormatUrl("limit", limit);
			mozuUrl.FormatUrl("owner", owner);
			mozuUrl.FormatUrl("types", types);
			mozuUrl.FormatUrl("originalFilename", originalFilename);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}
	}
}

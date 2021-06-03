using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Urls.Commerce.Inventory
{
    public partial class FetchFileConfigUrl
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl GetFetchConfigUrl(string responseFields = null)
		{
			var url = "/api/commerce/inventory/v1/config/fetchfile/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fetchFileConfigRequest"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl SaveFetchConfigUrl(FetchFileConfigRequest fetchFileConfigRequest, string responseFields = null)
		{
			var url = "/api/commerce/inventory/v1/config/fetchfile/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fetchFileConfigID"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl DeleteFetchConfigUrl(long? fetchFileConfigID, string responseFields = null)
		{
			var url = "/api/commerce/inventory/v1/config/fetchfile/{fetchFileConfigID}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("fetchFileConfigID", fetchFileConfigID);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}
	}
}

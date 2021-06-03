using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Urls.Commerce.Inventory
{
    public partial class InventoryUrl
    {
		public static MozuUrl AggregateUrl(AggregateRequest aggregateRequest, string responseFields = null)
		{
			var url = "/api/commerce/inventory/v5/inventory/aggregate/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);			
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		public static MozuUrl PostQueryInventoryUrl(InventoryRequest inventoryRequest, string responseFields = null)
		{
			var url = "/api/commerce/inventory/v5/inventory/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}
	}
}

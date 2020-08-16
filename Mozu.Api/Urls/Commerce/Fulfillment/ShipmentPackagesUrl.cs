using Mozu.Api.Contracts.Fulfillment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Urls.Commerce.Fulfillment
{
    public partial class ShipmentPackagesUrl
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="package"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl NewPackageUrl(Package package, int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipment/{shipmentNumber}/packages?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="package"></param>
		/// <param name="packageId"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl UpdatePackageUrl(Package package, string packageId, int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipment/{shipmentNumber}/packages/{packageId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("packageId", packageId);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}
	}
}

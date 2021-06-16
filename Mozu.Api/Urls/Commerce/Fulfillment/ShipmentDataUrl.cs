using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Urls.Commerce.Fulfillment
{
	/// <summary>
	/// 
	/// </summary>
    public partial class ShipmentDataUrl
    {
		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>		
		/// <returns></returns>
		public static MozuUrl GetShipmentDataUrl(int shipmentNumber)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/data";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);			
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>		
		/// <returns></returns>
		public static MozuUrl ReplaceShipmentDataUrl(int shipmentNumber)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/data";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			return mozuUrl;
		}


		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>		
		/// <returns></returns>
		public static MozuUrl DeleteShipmentDataUrl(int shipmentNumber)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/data";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>
		/// <param name="key"></param>		
		/// <returns></returns>
		public static MozuUrl DeleteShipmentDataByKeyUrl(int shipmentNumber, string key)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/data/{key}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("key", key);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>		
		/// <returns></returns>
		public static MozuUrl GetShipmentItemDataUrl(int shipmentNumber, int lineId)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/items/{lineId}/data";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("lineId", lineId);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>		
		/// <returns></returns>
		public static MozuUrl ReplaceShipmentItemDataUrl(int shipmentNumber, int lineId)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/items/{lineId}/data";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("lineId", lineId);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>		
		/// <returns></returns>
		public static MozuUrl DeleteShipmentItemDataUrl(int shipmentNumber, int lineId)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/items/{lineId}/data";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("lineId", lineId);
			return mozuUrl;
		}

		/// <summary>
		/// 
		/// </summary>		
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="key"></param>		
		/// <returns></returns>
		public static MozuUrl DeleteShipmentItemDataByKeyUrl(int shipmentNumber, int lineId, string key)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/items/{lineId}/data/{key}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("lineId", lineId);
			mozuUrl.FormatUrl("key", key);
			return mozuUrl;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Clients.Commerce.Fulfillment
{
	/// <summary>
	/// 
	/// </summary>
    public partial class ShipmentDataClient
    {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>		
		/// <returns></returns>
		public static MozuClient<Dictionary<string, object>> GetShipmentDataClient(int shipmentNumber)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.GetShipmentDataUrl(shipmentNumber);
			const string verb = "GET";
			var mozuClient = new MozuClient<Dictionary<string, object>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public static MozuClient<Dictionary<string, object>> ReplaceShipmentDataClient(int shipmentNumber, Dictionary<string, object> data)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.ReplaceShipmentDataUrl(shipmentNumber);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Dictionary<string, object>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(data);
			;
			return mozuClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <returns></returns>
		public static MozuClient<System.IO.Stream> DeleteShipmentDataClient(int shipmentNumber)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.DeleteShipmentDataUrl(shipmentNumber);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static MozuClient<System.IO.Stream> DeleteShipmentDataByKeyClient(int shipmentNumber, string key)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.DeleteShipmentDataByKeyUrl(shipmentNumber, key);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>		
		/// <returns></returns>
		public static MozuClient<Dictionary<string, object>> GetShipmentItemDataClient(int shipmentNumber, int lineId)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.GetShipmentItemDataUrl(shipmentNumber, lineId);
			const string verb = "GET";
			var mozuClient = new MozuClient<Dictionary<string, object>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public static MozuClient<Dictionary<string, object>> ReplaceShipmentItemDataClient(int shipmentNumber, int lineId, Dictionary<string, object> data)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.ReplaceShipmentItemDataUrl(shipmentNumber, lineId);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Dictionary<string, object>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(data);
			;
			return mozuClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <returns></returns>
		public static MozuClient<System.IO.Stream> DeleteShipmentItemDataClient(int shipmentNumber, int lineId)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.DeleteShipmentItemDataUrl(shipmentNumber, lineId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static MozuClient<System.IO.Stream> DeleteShipmentItemDataByKeyClient(int shipmentNumber,int lineId, string key)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentDataUrl.DeleteShipmentItemDataByKeyUrl(shipmentNumber, lineId, key);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}
	}
}

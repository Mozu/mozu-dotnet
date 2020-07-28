
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Mozu.Api.Security;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Mozu.Api.Clients.Commerce.Orders
{
	/// <summary>
	/// Use the shipments resource to manage shipments of collections of packages for an order.
	/// </summary>
	public partial class ShipmentClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="shipmentId">Unique identifier of the shipment to retrieve.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetShipment( orderId,  shipmentId,  responseFields);
		///   var shipmentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment> GetShipmentClient(string orderId, string shipmentId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.GetShipmentUrl(orderId, shipmentId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="draft">If true, retrieve the draft version of the order, which might include uncommitted changes to the order or its components.</param>
		/// <param name="orderId">Unique identifier of the order.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShippingRate"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAvailableShipmentMethods( orderId,  draft);
		///   var shippingRateClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShippingRate>> GetAvailableShipmentMethodsClient(string orderId, bool? draft =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.GetAvailableShipmentMethodsUrl(orderId, draft);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShippingRate>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order.</param>
		/// <param name="packageIds">List of unique identifiers for each package associated with this shipment. Not all packages must belong to the same shipment.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreatePackageShipments( packageIds,  orderId);
		///   var packageClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package>> CreatePackageShipmentsClient(List<string> packageIds, string orderId)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.CreatePackageShipmentsUrl(orderId);
			const string verb = "POST";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(packageIds);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="responseFields"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="shipmentAdjustment"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateShipmentAdjustments( shipmentAdjustment,  orderId,  shipmentNumber,  responseFields);
		///   var shipmentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment> UpdateShipmentAdjustmentsClient(Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShipmentAdjustment shipmentAdjustment, string orderId, int shipmentNumber, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.UpdateShipmentAdjustmentsUrl(orderId, shipmentNumber, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShipmentAdjustment>(shipmentAdjustment);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="responseFields"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="shipmentItemAdjustment"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateShipmentItem( shipmentItemAdjustment,  shipmentNumber,  itemId,  responseFields);
		///   var shipmentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment> UpdateShipmentItemClient(Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShipmentItemAdjustment shipmentItemAdjustment, int shipmentNumber, int itemId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.UpdateShipmentItemUrl(shipmentNumber, itemId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.ShipmentItemAdjustment>(shipmentItemAdjustment);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="repriceShipment"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RepriceShipment( repriceShipment,  shipmentNumber,  responseFields);
		///   var shipmentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment> RepriceShipmentClient(Mozu.Api.Contracts.CommerceRuntime.Fulfillment.RepriceShipmentObject repriceShipment, int shipmentNumber, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.RepriceShipmentUrl(shipmentNumber, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.RepriceShipmentObject>(repriceShipment);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="splitShipments"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=SplitShipments( splitShipments);
		///   var shipmentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment>> SplitShipmentsClient(Mozu.Api.Contracts.CommerceRuntime.Fulfillment.SplitShipmentsObject splitShipments)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.SplitShipmentsUrl();
			const string verb = "POST";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.SplitShipmentsObject>(splitShipments);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order.</param>
		/// <param name="shipmentId">Unique identifier of the shipment to retrieve.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteShipment( orderId,  shipmentId);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteShipmentClient(string orderId, string shipmentId)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.ShipmentUrl.DeleteShipmentUrl(orderId, shipmentId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



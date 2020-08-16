﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Mozu.Api.Contracts.Fulfillment;
using System.Collections.Generic;

namespace Mozu.Api.Urls.Commerce.Fulfillment
{
	public partial class ShipmentUrl
	{

		/// <summary>
		/// Get Resource Url for GetShipments
		/// </summary>

		/// <param name="filter"></param>
		/// <param name="isLate"></param>
		/// <param name="page">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="quickSearch"></param>
		/// <param name="sort">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="workflowTaskName"></param>		
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// String - Resource Url
		/// </returns>
		public static MozuUrl GetShipmentsUrl(string filter = null, bool? isLate = null, int? page = null, int? pageSize = null, string quickSearch = null, string sort = null, string workflowTaskName = null,	string responseFields = null)
		{
			var url = "/api/commerce/shipments/?page={page}&pageSize={pageSize}&sort={sort}&filter={filter}&isLate={isLate}&quickSearch={quickSearch}&responseFields={responseFields}&workflowTaskName={workflowTaskName}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("filter", filter);
			mozuUrl.FormatUrl("page", page);
			mozuUrl.FormatUrl("pageSize", pageSize);
			mozuUrl.FormatUrl("responseFields", responseFields);
			mozuUrl.FormatUrl("sort", sort);
			mozuUrl.FormatUrl("isLate", isLate);
			mozuUrl.FormatUrl("quickSearch", quickSearch);
			mozuUrl.FormatUrl("workflowTaskName", workflowTaskName);

			return mozuUrl;
		}

		/// <summary>
		/// Get Resource Url for GetShipment
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl GetShipmentUrl(int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipment/{shipmentNumber}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// Get Resource Url for FulfillShipment
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl FulfillShipmentUrl(int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipment/{shipmentNumber}/fulfilled?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// Get Resource Url for NewShipment
		/// </summary>
		/// <param name="shipment"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl NewShipmentUrl(Shipment shipment, string responseFields = null)
		{
			var url = "/api/commerce/shipments?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// Get Resource Url for CancelItems on shipment
		/// </summary>
		/// <param name="cancelItemsRequest"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl CancelItemsUrl(CancelItemsRequest cancelItemsRequest, int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/canceledItems?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
		/// Get Resource Url for CancelShipment 
		/// </summary>
		/// <param name="cancelShipment"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuUrl CancelShipmentUrl(CancelShipment cancelShipment, int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/canceled?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		public static MozuUrl DeleteShipmentUrl(int shipmentNumber)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			return mozuUrl;
		}

		public static MozuUrl DestinationUpdateUrl(Destination body, int shipmentNumber, string responseFields = null)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}/destination?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}

		public static MozuUrl ReplaceShipmentUrl(Shipment body, int shipmentNumber, List<string> updateFields, string responseFields = null)
		{
			var url = "/api/commerce/shipments/{shipmentNumber}?updateFields={updateFields}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);
			mozuUrl.FormatUrl("shipmentNumber", shipmentNumber);
			mozuUrl.FormatUrl("updateFields", updateFields);
			mozuUrl.FormatUrl("responseFields", responseFields);
			return mozuUrl;
		}
	}
}


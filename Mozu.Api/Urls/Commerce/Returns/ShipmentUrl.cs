
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mozu.Api.Urls.Commerce.Returns
{
	public partial class ShipmentUrl 
	{

		/// <summary>
        /// Get Resource Url for GetShipment
        /// </summary>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="returnId">Unique identifier of the return whose items you want to get.</param>
        /// <param name="shipmentId">Unique identifier of the shipment to retrieve.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetShipmentUrl(string returnId, string shipmentId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/shipments/{shipmentId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			mozuUrl.FormatUrl( "shipmentId", shipmentId);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for CreatePackageShipments
        /// </summary>
        /// <param name="returnId">Unique identifier of the return whose items you want to get.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreatePackageShipmentsUrl(string returnId)
		{
			var url = "/api/commerce/returns/{returnId}/shipments";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

						/// <summary>
        /// Get Resource Url for DeleteShipment
        /// </summary>
        /// <param name="returnId">Unique identifier of the return whose items you want to get.</param>
        /// <param name="shipmentId">Unique identifier of the shipment to retrieve.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteShipmentUrl(string returnId, string shipmentId)
		{
			var url = "/api/commerce/returns/{returnId}/shipments/{shipmentId}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "returnId", returnId);
			mozuUrl.FormatUrl( "shipmentId", shipmentId);
			return mozuUrl;
		}

		
	}
}


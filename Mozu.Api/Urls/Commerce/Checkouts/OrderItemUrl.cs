
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

namespace Mozu.Api.Urls.Commerce.Checkouts
{
	public partial class OrderItemUrl 
	{

				/// <summary>
        /// Get Resource Url for SplitItem
        /// </summary>
        /// <param name="checkoutId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl SplitItemUrl(string checkoutId, string itemId, int? quantity =  null, string responseFields =  null)
		{
			var url = "/api/commerce/checkouts/{checkoutId}/items/{itemId}/split?quantity={quantity}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "checkoutId", checkoutId);
			mozuUrl.FormatUrl( "itemId", itemId);
			mozuUrl.FormatUrl( "quantity", quantity);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for BulkUpdateItemDestinations
        /// </summary>
        /// <param name="checkoutId"></param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl BulkUpdateItemDestinationsUrl(string checkoutId, string responseFields =  null)
		{
			var url = "/api/commerce/checkouts/{checkoutId}/items/destinations?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "checkoutId", checkoutId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateItemDestination
        /// </summary>
        /// <param name="checkoutId"></param>
        /// <param name="destinationId"></param>
        /// <param name="itemId"></param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateItemDestinationUrl(string checkoutId, string itemId, string destinationId, string responseFields =  null)
		{
			var url = "/api/commerce/checkouts/{checkoutId}/items/{itemId}/destination/{destinationId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "checkoutId", checkoutId);
			mozuUrl.FormatUrl( "destinationId", destinationId);
			mozuUrl.FormatUrl( "itemId", itemId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				
	}
}

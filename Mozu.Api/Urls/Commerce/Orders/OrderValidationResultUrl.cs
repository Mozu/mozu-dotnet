
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

namespace Mozu.Api.Urls.Commerce.Orders
{
	public partial class OrderValidationResultUrl 
	{

		/// <summary>
        /// Get Resource Url for GetValidationResults
        /// </summary>
        /// <param name="orderId">Unique identifier of the order.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetValidationResultsUrl(string orderId)
		{
			var url = "/api/commerce/orders/{orderId}/validationresults";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			return mozuUrl;
		}

						/// <summary>
        /// Get Resource Url for AddValidationResult
        /// </summary>
        /// <param name="orderId">Unique identifier of the order.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddValidationResultUrl(string orderId, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/validationresults?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				
	}
}


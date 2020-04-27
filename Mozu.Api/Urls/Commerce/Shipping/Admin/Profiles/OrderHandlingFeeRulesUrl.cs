
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

namespace Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles
{
	public partial class OrderHandlingFeeRulesUrl 
	{

		/// <summary>
        /// Get Resource Url for GetOrderHandlingFeeRule
        /// </summary>
        /// <param name="id">Unique identifier of the customer segment to retrieve.</param>
        /// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetOrderHandlingFeeRuleUrl(string profilecode, string id, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/profiles/{profilecode}/rules/orderhandlingfees/{id}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "id", id);
			mozuUrl.FormatUrl( "profilecode", profilecode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetOrderHandlingFeeRules
        /// </summary>
        /// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetOrderHandlingFeeRulesUrl(string profilecode, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/profiles/{profilecode}/rules/orderhandlingfees?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "profilecode", profilecode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for CreateOrderHandlingFeeRule
        /// </summary>
        /// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateOrderHandlingFeeRuleUrl(string profilecode, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/profiles/{profilecode}/rules/orderhandlingfees?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "profilecode", profilecode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateOrderHandlingFeeRule
        /// </summary>
        /// <param name="id">Unique identifier of the customer segment to retrieve.</param>
        /// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateOrderHandlingFeeRuleUrl(string profilecode, string id, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/profiles/{profilecode}/rules/orderhandlingfees/{id}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "id", id);
			mozuUrl.FormatUrl( "profilecode", profilecode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteOrderHandlingFeeRule
        /// </summary>
        /// <param name="id">Unique identifier of the customer segment to retrieve.</param>
        /// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteOrderHandlingFeeRuleUrl(string profilecode, string id)
		{
			var url = "/api/commerce/shipping/admin/profiles/{profilecode}/rules/orderhandlingfees/{id}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "id", id);
			mozuUrl.FormatUrl( "profilecode", profilecode);
			return mozuUrl;
		}

		
	}
}


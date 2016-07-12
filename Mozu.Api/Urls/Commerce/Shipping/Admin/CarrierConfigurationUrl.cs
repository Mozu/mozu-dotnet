
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

namespace Mozu.Api.Urls.Commerce.Shipping.Admin
{
	public partial class CarrierConfigurationUrl 
	{

		/// <summary>
        /// Get Resource Url for GetConfigurations
        /// </summary>
        /// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for a list of supported filters.</param>
        /// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for more information.</param>
        /// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetConfigurationsUrl(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/carriers/?startIndex={startIndex}&pageSize={pageSize}&sortBy={sortBy}&filter={filter}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "filter", filter);
			mozuUrl.FormatUrl( "pageSize", pageSize);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "sortBy", sortBy);
			mozuUrl.FormatUrl( "startIndex", startIndex);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetConfiguration
        /// </summary>
        /// <param name="carrierId">The unique identifier of the carrier.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetConfigurationUrl(string carrierId, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/carriers/{carrierId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "carrierId", carrierId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for CreateConfiguration
        /// </summary>
        /// <param name="carrierId">The unique identifier of the carrier.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateConfigurationUrl(string carrierId, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/carriers/{carrierId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "carrierId", carrierId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateConfiguration
        /// </summary>
        /// <param name="carrierId">The unique identifier of the carrier.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateConfigurationUrl(string carrierId, string responseFields =  null)
		{
			var url = "/api/commerce/shipping/admin/carriers/{carrierId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "carrierId", carrierId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteConfiguration
        /// </summary>
        /// <param name="carrierId">The unique identifier of the carrier configuration.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteConfigurationUrl(string carrierId)
		{
			var url = "/api/commerce/shipping/admin/carriers/{carrierId}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "carrierId", carrierId);
			return mozuUrl;
		}

		
	}
}

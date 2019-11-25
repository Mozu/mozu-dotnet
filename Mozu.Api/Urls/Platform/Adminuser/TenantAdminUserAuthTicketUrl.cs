
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

namespace Mozu.Api.Urls.Platform.Adminuser
{
	public partial class TenantAdminUserAuthTicketUrl 
	{

				/// <summary>
        /// Get Resource Url for CreateUserAuthTicket
        /// </summary>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="tenantId">Unique identifier of the development or production tenant for which to generate the user authentication ticket.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateUserAuthTicketUrl(int? tenantId =  null, string responseFields =  null)
		{
			var url = "/api/platform/adminuser/authtickets/tenants?tenantId={tenantId}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.HOME_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "tenantId", tenantId);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for RefreshAuthTicket
        /// </summary>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="tenantId">Unique identifier of the development or production tenant for which to generate the user authentication ticket.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl RefreshAuthTicketUrl(int? tenantId =  null, string responseFields =  null)
		{
			var url = "/api/platform/adminuser/authtickets/tenants?tenantId={tenantId}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.HOME_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "tenantId", tenantId);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteUserAuthTicket
        /// </summary>
        /// <param name="refreshToken">Alphanumeric string used for access tokens. This token refreshes access for accounts by generating a new developer or application account authentication ticket after an access token expires.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteUserAuthTicketUrl(string refreshToken)
		{
			var url = "/api/platform/adminuser/authtickets/?refreshToken={refreshToken}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.HOME_POD, false) ;
			mozuUrl.FormatUrl( "refreshToken", refreshToken);
			return mozuUrl;
		}

		
	}
}



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

namespace Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes
{
	public partial class AttributeLocalizedContentUrl 
	{

		/// <summary>
        /// Get Resource Url for GetAttributeLocalizedContents
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAttributeLocalizedContentsUrl(string attributeFQN)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/LocalizedContent";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAttributeLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAttributeLocalizedContentUrl(string attributeFQN, string localeCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/LocalizedContent/{localeCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "localeCode", localeCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddLocalizedContentUrl(string attributeFQN, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/LocalizedContent?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateLocalizedContents
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateLocalizedContentsUrl(string attributeFQN)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/LocalizedContent";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateLocalizedContentUrl(string attributeFQN, string localeCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/LocalizedContent/{localeCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "localeCode", localeCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteLocalizedContentUrl(string attributeFQN, string localeCode)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/LocalizedContent/{localeCode}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "localeCode", localeCode);
			return mozuUrl;
		}

		
	}
}


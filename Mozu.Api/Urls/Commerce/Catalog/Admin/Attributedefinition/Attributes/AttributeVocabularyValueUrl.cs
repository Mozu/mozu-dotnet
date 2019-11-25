
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
	public partial class AttributeVocabularyValueUrl 
	{

		/// <summary>
        /// Get Resource Url for GetAttributeVocabularyValues
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAttributeVocabularyValuesUrl(string attributeFQN)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAttributeVocabularyValueLocalizedContents
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAttributeVocabularyValueLocalizedContentsUrl(string attributeFQN, string value)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}/LocalizedContent";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAttributeVocabularyValueLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAttributeVocabularyValueLocalizedContentUrl(string attributeFQN, string value, string localeCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}/LocalizedContent/{localeCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "localeCode", localeCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAttributeVocabularyValue
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAttributeVocabularyValueUrl(string attributeFQN, string value, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddAttributeVocabularyValueLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddAttributeVocabularyValueLocalizedContentUrl(string attributeFQN, string value, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}/localizedContent?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for AddAttributeVocabularyValue
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddAttributeVocabularyValueUrl(string attributeFQN, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateAttributeVocabularyValues
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateAttributeVocabularyValuesUrl(string attributeFQN)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateAttributeVocabularyValueLocalizedContents
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateAttributeVocabularyValueLocalizedContentsUrl(string attributeFQN, string value)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}/LocalizedContent";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateAttributeVocabularyValueLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateAttributeVocabularyValueLocalizedContentUrl(string attributeFQN, string value, string localeCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}/LocalizedContent/{localeCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "localeCode", localeCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateAttributeVocabularyValue
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateAttributeVocabularyValueUrl(string attributeFQN, string value, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteAttributeVocabularyValue
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteAttributeVocabularyValueUrl(string attributeFQN, string value)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for DeleteAttributeVocabularyValueLocalizedContent
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
        /// <param name="value">The value string to create.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteAttributeVocabularyValueLocalizedContentUrl(string attributeFQN, string value, string localeCode)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/attributes/{attributeFQN}/VocabularyValues/{value}/LocalizedContent/{localeCode}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "localeCode", localeCode);
			mozuUrl.FormatUrl( "value", value);
			return mozuUrl;
		}

		
	}
}


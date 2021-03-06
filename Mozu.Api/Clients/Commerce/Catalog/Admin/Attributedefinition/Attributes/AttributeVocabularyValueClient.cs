
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.Attributes
{
	/// <summary>
	/// Vocabulary values are predefined for an attribute.
	/// </summary>
	public partial class AttributeVocabularyValueClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttributeVocabularyValues( attributeFQN);
		///   var attributeVocabularyValueClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>> GetAttributeVocabularyValuesClient(string attributeFQN)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.GetAttributeVocabularyValuesUrl(attributeFQN);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttributeVocabularyValueLocalizedContents( attributeFQN,  value);
		///   var attributeVocabularyValueLocalizedContentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>> GetAttributeVocabularyValueLocalizedContentsClient(string attributeFQN, string value)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.GetAttributeVocabularyValueLocalizedContentsUrl(attributeFQN, value);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttributeVocabularyValueLocalizedContent( attributeFQN,  value,  localeCode,  responseFields);
		///   var attributeVocabularyValueLocalizedContentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent> GetAttributeVocabularyValueLocalizedContentClient(string attributeFQN, string value, string localeCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.GetAttributeVocabularyValueLocalizedContentUrl(attributeFQN, value, localeCode, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttributeVocabularyValue( attributeFQN,  value,  responseFields);
		///   var attributeVocabularyValueClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue> GetAttributeVocabularyValueClient(string attributeFQN, string value, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.GetAttributeVocabularyValueUrl(attributeFQN, value, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="localizedContent">The localized text for the string value of a product attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddAttributeVocabularyValueLocalizedContent( localizedContent,  attributeFQN,  value,  responseFields);
		///   var attributeVocabularyValueLocalizedContentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent> AddAttributeVocabularyValueLocalizedContentClient(Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent localizedContent, string attributeFQN, string value, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.AddAttributeVocabularyValueLocalizedContentUrl(attributeFQN, value, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>(localizedContent);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="attributeVocabularyValue">Properties of a vocabulary value defined for an extensible attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddAttributeVocabularyValue( attributeVocabularyValue,  attributeFQN,  responseFields);
		///   var attributeVocabularyValueClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue> AddAttributeVocabularyValueClient(Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue attributeVocabularyValue, string attributeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.AddAttributeVocabularyValueUrl(attributeFQN, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>(attributeVocabularyValue);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="vocabularyValues">Properties of a vocabulary value defined for an extensible attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateAttributeVocabularyValues( vocabularyValues,  attributeFQN);
		///   var attributeVocabularyValueClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>> UpdateAttributeVocabularyValuesClient(List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue> vocabularyValues, string attributeFQN)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.UpdateAttributeVocabularyValuesUrl(attributeFQN);
			const string verb = "PUT";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>>(vocabularyValues);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="localizedContent">The localized text for the string value of a product attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateAttributeVocabularyValueLocalizedContents( localizedContent,  attributeFQN,  value);
		///   var attributeVocabularyValueLocalizedContentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>> UpdateAttributeVocabularyValueLocalizedContentsClient(List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent> localizedContent, string attributeFQN, string value)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.UpdateAttributeVocabularyValueLocalizedContentsUrl(attributeFQN, value);
			const string verb = "PUT";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<List<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>>(localizedContent);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="localizedContent">The localized text for the string value of a product attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateAttributeVocabularyValueLocalizedContent( localizedContent,  attributeFQN,  value,  localeCode,  responseFields);
		///   var attributeVocabularyValueLocalizedContentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent> UpdateAttributeVocabularyValueLocalizedContentClient(Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent localizedContent, string attributeFQN, string value, string localeCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.UpdateAttributeVocabularyValueLocalizedContentUrl(attributeFQN, value, localeCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent>(localizedContent);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="attributeVocabularyValue">Properties of a vocabulary value defined for an extensible attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateAttributeVocabularyValue( attributeVocabularyValue,  attributeFQN,  value,  responseFields);
		///   var attributeVocabularyValueClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue> UpdateAttributeVocabularyValueClient(Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue attributeVocabularyValue, string attributeFQN, string value, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.UpdateAttributeVocabularyValueUrl(attributeFQN, value, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.AttributeVocabularyValue>(attributeVocabularyValue);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteAttributeVocabularyValue( attributeFQN,  value);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteAttributeVocabularyValueClient(string attributeFQN, string value)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.DeleteAttributeVocabularyValueUrl(attributeFQN, value);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="localeCode">The two character country code that sets the locale, such as US for United States. Sites, tenants, and catalogs use locale codes for localizing content, such as translated product text per supported country.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteAttributeVocabularyValueLocalizedContent( attributeFQN,  value,  localeCode);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteAttributeVocabularyValueLocalizedContentClient(string attributeFQN, string value, string localeCode)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Attributes.AttributeVocabularyValueUrl.DeleteAttributeVocabularyValueLocalizedContentUrl(attributeFQN, value, localeCode);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



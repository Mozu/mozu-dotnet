
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

namespace Mozu.Api.Clients.Commerce.Customer.Attributedefinition
{
	/// <summary>
	/// Attributes are used to add custom definitions and characteristics to the following objects:
/// -  â€” are attributes that define the characteristics of products, enabling you to uniquely describe a product. They consist of options, properties, and extras. Refer to [Product Attributes](https://www.mozu.com/docs/guides/catalog/product-attributes.htm) in the Guides section for more information.

/// -  â€” are custom attributes that you can apply to customer accounts to add further definition for special uses, such as marketing campaigns, or discounts. Refer to [Customer Attributes](https://www.mozu.com/docs/guides/customers/customers.htm#customer_attributes) in the Guides section for more information.

/// -  â€” are custom attributes that enable you to uniquely describe an aspect of an order. Depending on the attribute definition, either you or a shopper can enter values for the order attribute. Refer to [Order Attributes](https://www.mozu.com/docs/guides/orders/order-attributes.htm) in the Guides section for more information.

	/// </summary>
	public partial class AttributeClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Core.Extensible.AttributeCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttributes( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var attributeCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Core.Extensible.AttributeCollection> GetAttributesClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.Attributedefinition.AttributeUrl.GetAttributesUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Core.Extensible.AttributeCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.Core.Extensible.AttributeVocabularyValue"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttributeVocabularyValues( attributeFQN);
		///   var attributeVocabularyValueClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.Core.Extensible.AttributeVocabularyValue>> GetAttributeVocabularyValuesClient(string attributeFQN)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.Attributedefinition.AttributeUrl.GetAttributeVocabularyValuesUrl(attributeFQN);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.Core.Extensible.AttributeVocabularyValue>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Core.Extensible.Attribute"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAttribute( attributeFQN,  responseFields);
		///   var attributeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Core.Extensible.Attribute> GetAttributeClient(string attributeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.Attributedefinition.AttributeUrl.GetAttributeUrl(attributeFQN, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Core.Extensible.Attribute>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="attribute">Properties of an attribute used to describe customers or orders.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Core.Extensible.Attribute"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateAttribute( attribute,  responseFields);
		///   var attributeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Core.Extensible.Attribute> CreateAttributeClient(Mozu.Api.Contracts.Core.Extensible.Attribute attribute, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.Attributedefinition.AttributeUrl.CreateAttributeUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Core.Extensible.Attribute>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Core.Extensible.Attribute>(attribute);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="attribute">Properties of an attribute used to describe customers or orders.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Core.Extensible.Attribute"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateAttribute( attribute,  attributeFQN,  responseFields);
		///   var attributeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Core.Extensible.Attribute> UpdateAttributeClient(Mozu.Api.Contracts.Core.Extensible.Attribute attribute, string attributeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.Attributedefinition.AttributeUrl.UpdateAttributeUrl(attributeFQN, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Core.Extensible.Attribute>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Core.Extensible.Attribute>(attribute);
			return mozuClient;

		}


	}

}



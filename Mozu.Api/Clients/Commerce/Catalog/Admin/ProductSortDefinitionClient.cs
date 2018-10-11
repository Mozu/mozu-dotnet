
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin
{
	/// <summary>
	/// Use the Product Sort Definition resource to create, update, and delete sort order definitions used in visual merchandising.You can use these definitions to apply organization rules to a category defined by a product property or custom attribute. The sort order determines the order that products are displayed in, such as newest to oldest, so that they can be rearranged.
	/// </summary>
	public partial class ProductSortDefinitionClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinitionPagedCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetProductSortDefinitions(dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var productSortDefinitionPagedCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinitionPagedCollection> GetProductSortDefinitionsClient(DataViewMode dataViewMode, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.ProductSortDefinitionUrl.GetProductSortDefinitionsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinitionPagedCollection>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="productSortDefinitionId">Unique identifier of the product sort definition.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetProductSortDefinition(dataViewMode,  productSortDefinitionId,  responseFields);
		///   var productSortDefinitionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> GetProductSortDefinitionClient(DataViewMode dataViewMode, int productSortDefinitionId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.ProductSortDefinitionUrl.GetProductSortDefinitionUrl(productSortDefinitionId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="useProvidedId">If true, the provided Id value will be used as the ProductSortDefinitionId. If omitted or false, the system will generate a ProductSortDefinitionId</param>
		/// <param name="definition">Properties of the new product sort definition. Required properties of StartDate and Name.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddProductSortDefinition(dataViewMode,  definition,  useProvidedId,  responseFields);
		///   var productSortDefinitionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> AddProductSortDefinitionClient(DataViewMode dataViewMode, Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition definition, bool? useProvidedId =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.ProductSortDefinitionUrl.AddProductSortDefinitionUrl(useProvidedId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition>(definition)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="productSortDefinitionId">Unique identifier of the product sort definition.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="definition">The details of the product sort definition to update.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateProductSortDefinition(dataViewMode,  definition,  productSortDefinitionId,  responseFields);
		///   var productSortDefinitionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> UpdateProductSortDefinitionClient(DataViewMode dataViewMode, Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition definition, int productSortDefinitionId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.ProductSortDefinitionUrl.UpdateProductSortDefinitionUrl(productSortDefinitionId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition>(definition)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="productSortDefinitionId">Unique identifier of the product sort definition.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteProductSortDefinition(dataViewMode,  productSortDefinitionId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteProductSortDefinitionClient(DataViewMode dataViewMode, int productSortDefinitionId)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.ProductSortDefinitionUrl.DeleteProductSortDefinitionUrl(productSortDefinitionId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}


	}

}


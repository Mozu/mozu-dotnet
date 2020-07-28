
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin
{
	/// <summary>
	/// Use the Product Sort Definition resource to create, update, and delete sort order definitions used in visual merchandising.You can use these definitions to apply organization rules to a category defined by a product property or custom attribute. The sort order determines the order that products are displayed in, such as newest to oldest, so that they can be rearranged.
	/// </summary>
	public partial class ProductSortDefinitionResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		private readonly DataViewMode _dataViewMode;
		
		public ProductSortDefinitionResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
			_dataViewMode = DataViewMode.Live;
		}

		public ProductSortDefinitionResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ProductSortDefinitionResource(_apiContext.CloneWith(contextModification), _dataViewMode);
		}

		public ProductSortDefinitionResource(IApiContext apiContext, DataViewMode dataViewMode) 
		{
			_apiContext = apiContext;
			_dataViewMode = dataViewMode;
		}
				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinitionPagedCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var productsortdefinition = new ProductSortDefinition();
		///   var productSortDefinitionPagedCollection = await productsortdefinition.GetProductSortDefinitionsAsync(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinitionPagedCollection> GetProductSortDefinitionsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinitionPagedCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.ProductSortDefinitionClient.GetProductSortDefinitionsClient(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productSortDefinitionId">Unique identifier of the product sort definition.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var productsortdefinition = new ProductSortDefinition();
		///   var productSortDefinition = await productsortdefinition.GetProductSortDefinitionAsync(_dataViewMode,  productSortDefinitionId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> GetProductSortDefinitionAsync(int productSortDefinitionId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.ProductSortDefinitionClient.GetProductSortDefinitionClient(_dataViewMode,  productSortDefinitionId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="useProvidedId">If true, the provided Id value will be used as the ProductSortDefinitionId. If omitted or false, the system will generate a ProductSortDefinitionId</param>
		/// <param name="definition">Properties of the new product sort definition. Required properties of StartDate and Name.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var productsortdefinition = new ProductSortDefinition();
		///   var productSortDefinition = await productsortdefinition.AddProductSortDefinitionAsync(_dataViewMode,  definition,  useProvidedId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> AddProductSortDefinitionAsync(Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition definition, bool? useProvidedId =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.ProductSortDefinitionClient.AddProductSortDefinitionClient(_dataViewMode,  definition,  useProvidedId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productSortDefinitionId">Unique identifier of the product sort definition.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="definition">The details of the product sort definition to update.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var productsortdefinition = new ProductSortDefinition();
		///   var productSortDefinition = await productsortdefinition.UpdateProductSortDefinitionAsync(_dataViewMode,  definition,  productSortDefinitionId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> UpdateProductSortDefinitionAsync(Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition definition, int productSortDefinitionId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductSortDefinition> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.ProductSortDefinitionClient.UpdateProductSortDefinitionClient(_dataViewMode,  definition,  productSortDefinitionId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productSortDefinitionId">Unique identifier of the product sort definition.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var productsortdefinition = new ProductSortDefinition();
		///   var stream = await productsortdefinition.DeleteProductSortDefinitionAsync(_dataViewMode,  productSortDefinitionId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteProductSortDefinitionAsync(int productSortDefinitionId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.ProductSortDefinitionClient.DeleteProductSortDefinitionClient(_dataViewMode,  productSortDefinitionId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



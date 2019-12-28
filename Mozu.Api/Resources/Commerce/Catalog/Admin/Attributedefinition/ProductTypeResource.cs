
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin.Attributedefinition
{
	/// <summary>
	/// Use the Product Types resource to manage the types for your product catalog. Product types act as configuration templates, which store a set of attributes common to all products associated with that type. Unlike categories, products can only be associated with a single product type.
	/// </summary>
	public partial class ProductTypeResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		private readonly DataViewMode _dataViewMode;
		
		public ProductTypeResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
			_dataViewMode = DataViewMode.Live;
		}

		public ProductTypeResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ProductTypeResource(_apiContext.CloneWith(contextModification), _dataViewMode);
		}

		public ProductTypeResource(IApiContext apiContext, DataViewMode dataViewMode) 
		{
			_apiContext = apiContext;
			_dataViewMode = dataViewMode;
		}
				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. You can filter product type search results by any of its properties. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=Name+cont+shoes"</param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductTypeCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var producttype = new ProductType();
		///   var productTypeCollection = await producttype.GetProductTypesAsync(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductTypeCollection> GetProductTypesAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductTypeCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.ProductTypeClient.GetProductTypesClient(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productTypeId">Identifier of the product type to retrieve.</param>
		/// <param name="responseFields"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductType"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var producttype = new ProductType();
		///   var productType = await producttype.GetProductTypeAsync(_dataViewMode,  productTypeId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductType> GetProductTypeAsync(int productTypeId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductType> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.ProductTypeClient.GetProductTypeClient(_dataViewMode,  productTypeId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="productType">Properties of the product type to create.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductType"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var producttype = new ProductType();
		///   var productType = await producttype.AddProductTypeAsync(_dataViewMode,  productType,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductType> AddProductTypeAsync(Mozu.Api.Contracts.ProductAdmin.ProductType productType, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductType> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.ProductTypeClient.AddProductTypeClient(_dataViewMode,  productType,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productTypeId">Identifier of the product type to update.</param>
		/// <param name="responseFields"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="productType">The details of the product type to update.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.ProductType"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var producttype = new ProductType();
		///   var productType = await producttype.UpdateProductTypeAsync(_dataViewMode,  productType,  productTypeId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.ProductType> UpdateProductTypeAsync(Mozu.Api.Contracts.ProductAdmin.ProductType productType, int productTypeId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductType> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.ProductTypeClient.UpdateProductTypeClient(_dataViewMode,  productType,  productTypeId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productTypeId">Identifier of the product type to delete.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var producttype = new ProductType();
		///   await producttype.DeleteProductTypeAsync(_dataViewMode,  productTypeId);
		/// </code>
		/// </example>
		public virtual async Task DeleteProductTypeAsync(int productTypeId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.ProductTypeClient.DeleteProductTypeClient(_dataViewMode,  productTypeId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



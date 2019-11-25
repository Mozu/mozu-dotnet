
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

namespace Mozu.Api.Resources.Commerce.Catalog.Storefront
{
	/// <summary>
	/// Use the Storefront Products resource to manage the shopper product selection process during a visit to the web storefront. You can update product options as shoppers pick and choose their product choices. A shopper cannot add a product to a cart until all of its required options have been selected.
	/// </summary>
	public partial class ProductResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		private readonly DataViewMode _dataViewMode;
		
		public ProductResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
			_dataViewMode = DataViewMode.Live;
		}

		public ProductResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ProductResource(_apiContext.CloneWith(contextModification), _dataViewMode);
		}

		public ProductResource(IApiContext apiContext, DataViewMode dataViewMode) 
		{
			_apiContext = apiContext;
			_dataViewMode = dataViewMode;
		}
				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cursorMark">In your first deep paged request, set this parameter to . Then, in all subsequent requests, set this parameter to the subsequent values of  that's returned in each response to continue paging through the results. Continue this pattern until  is null, which signifies the end of the paged results.</param>
		/// <param name="defaultSort">Sets the default sorting for content. Sort does not use AND in determining the order</param>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="responseOptions">Options you can specify for the response. This parameter is null by default.You can primarily use this parameter to return volume price band information in product details, which you can then display on category pages and search results depanding on your theme configuration. To return volume price band information, set this parameter to .</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productCollection = await product.GetProductsAsync(_dataViewMode,  filter,  startIndex,  pageSize,  sortBy,  responseOptions,  cursorMark,  defaultSort,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ProductCollection> GetProductsAsync(string filter =  null, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string responseOptions =  null, string cursorMark =  null, string defaultSort =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductsClient(_dataViewMode,  filter,  startIndex,  pageSize,  sortBy,  responseOptions,  cursorMark,  defaultSort,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationCodes">Array of location codes for which to retrieve product inventory information.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var locationInventoryCollection = await product.GetProductInventoryAsync(_dataViewMode,  productCode,  locationCodes,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> GetProductInventoryAsync(string productCode, string locationCodes =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductInventoryClient(_dataViewMode,  productCode,  locationCodes,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="acceptVariantProductCode">Specifies whether to accept a product variant's code as the .When you set this parameter to , you can pass in a product variant's code in the GetProduct call to retrieve the product variant details that are associated with the base product.</param>
		/// <param name="allowInactive">If true, allow inactive categories to be retrieved in the category list response. If false, the categories retrieved will not include ones marked inactive.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="purchaseLocation">The location where the order item(s) was purchased.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="supressOutOfStock404">Specifies whether to supress the 404 error when the product is out of stock.</param>
		/// <param name="variationProductCode">Merchant-created code associated with a specific product variation. Variation product codes maintain an association with the base product code.</param>
		/// <param name="variationProductCodeFilter">Provides support for [Variant Discounts](https://www.mozu.com/docs/guides/marketing/variant-discounts.htm) by indicating single and multiple variant codes. When this data is provided then only the option values for the specified product variants will display under the â€œOptionsâ€ list for the product. If a product has multiple options, then each option and the specified value for that variant will be displayed.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.Product"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var product = await product.GetProductAsync(_dataViewMode,  productCode,  variationProductCode,  allowInactive,  skipInventoryCheck,  supressOutOfStock404,  quantity,  acceptVariantProductCode,  purchaseLocation,  variationProductCodeFilter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.Product> GetProductAsync(string productCode, string variationProductCode =  null, bool? allowInactive =  null, bool? skipInventoryCheck =  null, bool? supressOutOfStock404 =  null, int? quantity =  null, bool? acceptVariantProductCode =  null, string purchaseLocation =  null, string variationProductCodeFilter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.Product> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductClient(_dataViewMode,  productCode,  variationProductCode,  allowInactive,  skipInventoryCheck,  supressOutOfStock404,  quantity,  acceptVariantProductCode,  purchaseLocation,  variationProductCodeFilter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="lastModifiedDate">The date when the product was last updated.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="productVersion">The product version.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.Product"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var product = await product.GetProductForIndexingAsync(_dataViewMode,  productCode,  productVersion,  lastModifiedDate,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.Product> GetProductForIndexingAsync(string productCode, long? productVersion =  null, DateTime? lastModifiedDate =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.Product> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductForIndexingClient(_dataViewMode,  productCode,  productVersion,  lastModifiedDate,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeOptionDetails">If true, the response returns details about the product. If false, returns a product summary such as the product name, price, and sale price.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="purchaseLocation">The location where the order item(s) was purchased.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="variationProductCodeFilter">Provides support for [Variant Discounts](https://www.mozu.com/docs/guides/marketing/variant-discounts.htm) by indicating single and multiple variant codes. When this data is provided then only the option values for the specified product variants will display under the â€œOptionsâ€ list for the product. If a product has multiple options, then each option and the specified value for that variant will be displayed.</param>
		/// <param name="productOptionSelections">For a product with shopper-configurable options, the properties of the product options selected by the shopper.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var configuredProduct = await product.ConfiguredProductAsync( productOptionSelections,  productCode,  includeOptionDetails,  skipInventoryCheck,  quantity,  purchaseLocation,  variationProductCodeFilter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct> ConfiguredProductAsync(Mozu.Api.Contracts.ProductRuntime.ProductOptionSelections productOptionSelections, string productCode, bool? includeOptionDetails =  null, bool? skipInventoryCheck =  null, int? quantity =  null, string purchaseLocation =  null, string variationProductCodeFilter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ConfiguredProductClient( productOptionSelections,  productCode,  includeOptionDetails,  skipInventoryCheck,  quantity,  purchaseLocation,  variationProductCodeFilter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="purchaseLocation">The location where the order item(s) was purchased.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipDefaults">Normally, product validation applies default extras to products that do not have options specified. If , product validation does not apply default extras to products.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="productOptionSelections">For a product with shopper-configurable options, the properties of the product options selected by the shopper.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productValidationSummary = await product.ValidateProductAsync( productOptionSelections,  productCode,  skipInventoryCheck,  quantity,  skipDefaults,  purchaseLocation,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary> ValidateProductAsync(Mozu.Api.Contracts.ProductRuntime.ProductOptionSelections productOptionSelections, string productCode, bool? skipInventoryCheck =  null, int? quantity =  null, bool? skipDefaults =  null, string purchaseLocation =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ValidateProductClient( productOptionSelections,  productCode,  skipInventoryCheck,  quantity,  skipDefaults,  purchaseLocation,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="allowInactive">If true, allow inactive categories to be retrieved in the category list response. If false, the categories retrieved will not include ones marked inactive.</param>
		/// <param name="customerAccountId">The unique identifier of the customer account for which to retrieve wish lists.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="variationProductCode">Merchant-created code associated with a specific product variation. Variation product codes maintain an association with the base product code.</param>
		/// <param name="discountSelections">The discounts to evaluate for a specified product code at the time of purchase.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var discountValidationSummary = await product.ValidateDiscountsAsync( discountSelections,  productCode,  variationProductCode,  customerAccountId,  allowInactive,  skipInventoryCheck,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary> ValidateDiscountsAsync(Mozu.Api.Contracts.ProductRuntime.DiscountSelections discountSelections, string productCode, string variationProductCode =  null, int? customerAccountId =  null, bool? allowInactive =  null, bool? skipInventoryCheck =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ValidateDiscountsClient( discountSelections,  productCode,  variationProductCode,  customerAccountId,  allowInactive,  skipInventoryCheck,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="query">Properties for the product location inventory provided for queries to locate products by their location.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductCostCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productCostCollection = await product.GetProductCostsAsync(_dataViewMode,  query,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ProductCostCollection> GetProductCostsAsync(Mozu.Api.Contracts.ProductRuntime.ProductCostQuery query, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductCostCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductCostsClient(_dataViewMode,  query,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="query">Properties for the product location inventory provided for queries to locate products by their location.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var locationInventoryCollection = await product.GetProductInventoriesAsync(_dataViewMode,  query,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> GetProductInventoriesAsync(Mozu.Api.Contracts.ProductRuntime.LocationInventoryQuery query, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductInventoriesClient(_dataViewMode,  query,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}




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

namespace Mozu.Api.Resources.Commerce.Catalog.Storefront
{
	/// <summary>
	/// Use the Storefront Products  resource to manage the shopper product selection process during a visit to the web storefront. You can update product options as shoppers pick and choose their product choices. A shopper cannot add a product to a cart until all of its required options have been selected.
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
		/// Retrieves a list of products that appear on the web storefront according to any specified filter criteria and sort options.
		/// </summary>
		/// <param name="filter">A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=IsDisplayed+eq+true"</param>
		/// <param name="pageSize">The number of results to display on each page when creating paged results from a query. The maximum value is 200.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="responseOptions"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productCollection = product.GetProducts(_dataViewMode,  filter,  startIndex,  pageSize,  sortBy,  responseOptions,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.ProductCollection GetProducts(string filter =  null, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string responseOptions =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductsClient(_dataViewMode,  filter,  startIndex,  pageSize,  sortBy,  responseOptions,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves a list of products that appear on the web storefront according to any specified filter criteria and sort options.
		/// </summary>
		/// <param name="filter">A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=IsDisplayed+eq+true"</param>
		/// <param name="pageSize">The number of results to display on each page when creating paged results from a query. The maximum value is 200.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="responseOptions"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productCollection = await product.GetProductsAsync(_dataViewMode,  filter,  startIndex,  pageSize,  sortBy,  responseOptions,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ProductCollection> GetProductsAsync(string filter =  null, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string responseOptions =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductsClient(_dataViewMode,  filter,  startIndex,  pageSize,  sortBy,  responseOptions,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves the active inventory level information associated with the product or location specified in the request.
		/// </summary>
		/// <param name="locationCodes">Array of location codes for which to retrieve product inventory information.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var locationInventoryCollection = product.GetProductInventory(_dataViewMode,  productCode,  locationCodes,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection GetProductInventory(string productCode, string locationCodes =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductInventoryClient(_dataViewMode,  productCode,  locationCodes,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves the active inventory level information associated with the product or location specified in the request.
		/// </summary>
		/// <param name="locationCodes">Array of location codes for which to retrieve product inventory information.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
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
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> GetProductInventoryAsync(string productCode, string locationCodes =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductInventoryClient(_dataViewMode,  productCode,  locationCodes,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves information about a single product given its product code.
		/// </summary>
		/// <param name="allowInactive">If true, allow inactive categories to be retrieved in the category list response. If false, the categories retrieved will not include ones marked inactive.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="supressOutOfStock404">Specifies whether to supress the 404 error when the product is out of stock.</param>
		/// <param name="variationProductCode">Merchant-created code associated with a specific product variation. Variation product codes maintain an association with the base product code.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.Product"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var product = product.GetProduct(_dataViewMode,  productCode,  variationProductCode,  allowInactive,  skipInventoryCheck,  supressOutOfStock404,  quantity,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.Product GetProduct(string productCode, string variationProductCode =  null, bool? allowInactive =  null, bool? skipInventoryCheck =  null, bool? supressOutOfStock404 =  null, int? quantity =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.Product> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductClient(_dataViewMode,  productCode,  variationProductCode,  allowInactive,  skipInventoryCheck,  supressOutOfStock404,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves information about a single product given its product code.
		/// </summary>
		/// <param name="allowInactive">If true, allow inactive categories to be retrieved in the category list response. If false, the categories retrieved will not include ones marked inactive.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="supressOutOfStock404">Specifies whether to supress the 404 error when the product is out of stock.</param>
		/// <param name="variationProductCode">Merchant-created code associated with a specific product variation. Variation product codes maintain an association with the base product code.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.Product"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var product = await product.GetProductAsync(_dataViewMode,  productCode,  variationProductCode,  allowInactive,  skipInventoryCheck,  supressOutOfStock404,  quantity,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.Product> GetProductAsync(string productCode, string variationProductCode =  null, bool? allowInactive =  null, bool? skipInventoryCheck =  null, bool? supressOutOfStock404 =  null, int? quantity =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.Product> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductClient(_dataViewMode,  productCode,  variationProductCode,  allowInactive,  skipInventoryCheck,  supressOutOfStock404,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves information about a single product given its product code for Mozu to index in the search engine
		/// </summary>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout Mozu to reference and associate to a product.</param>
		/// <param name="productVersion"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.Product"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var product = product.GetProductForIndexing(_dataViewMode,  productCode,  productVersion,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.Product GetProductForIndexing(string productCode, long? productVersion =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.Product> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductForIndexingClient(_dataViewMode,  productCode,  productVersion,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves information about a single product given its product code for Mozu to index in the search engine
		/// </summary>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout Mozu to reference and associate to a product.</param>
		/// <param name="productVersion"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.Product"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var product = await product.GetProductForIndexingAsync(_dataViewMode,  productCode,  productVersion,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.Product> GetProductForIndexingAsync(string productCode, long? productVersion =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.Product> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductForIndexingClient(_dataViewMode,  productCode,  productVersion,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Creates a new product configuration each time a shopper selects a product option value. After the shopper defines values for all required product options, the shopper can add the product configuration to a cart.
		/// </summary>
		/// <param name="includeOptionDetails">If true, the response returns details about the product. If false, returns a product summary such as the product name, price, and sale price.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="productOptionSelections">For a product with shopper-configurable options, the properties of the product options selected by the shopper.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var configuredProduct = product.ConfiguredProduct( productOptionSelections,  productCode,  includeOptionDetails,  skipInventoryCheck,  quantity,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct ConfiguredProduct(Mozu.Api.Contracts.ProductRuntime.ProductOptionSelections productOptionSelections, string productCode, bool? includeOptionDetails =  null, bool? skipInventoryCheck =  null, int? quantity =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ConfiguredProductClient( productOptionSelections,  productCode,  includeOptionDetails,  skipInventoryCheck,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Creates a new product configuration each time a shopper selects a product option value. After the shopper defines values for all required product options, the shopper can add the product configuration to a cart.
		/// </summary>
		/// <param name="includeOptionDetails">If true, the response returns details about the product. If false, returns a product summary such as the product name, price, and sale price.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="productOptionSelections">For a product with shopper-configurable options, the properties of the product options selected by the shopper.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var configuredProduct = await product.ConfiguredProductAsync( productOptionSelections,  productCode,  includeOptionDetails,  skipInventoryCheck,  quantity,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct> ConfiguredProductAsync(Mozu.Api.Contracts.ProductRuntime.ProductOptionSelections productOptionSelections, string productCode, bool? includeOptionDetails =  null, bool? skipInventoryCheck =  null, int? quantity =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ConfiguredProduct> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ConfiguredProductClient( productOptionSelections,  productCode,  includeOptionDetails,  skipInventoryCheck,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Validate the final state of shopper-selected options.
		/// </summary>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="productOptionSelections">For a product with shopper-configurable options, the properties of the product options selected by the shopper.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productValidationSummary = product.ValidateProduct( productOptionSelections,  productCode,  skipInventoryCheck,  quantity,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary ValidateProduct(Mozu.Api.Contracts.ProductRuntime.ProductOptionSelections productOptionSelections, string productCode, bool? skipInventoryCheck =  null, int? quantity =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ValidateProductClient( productOptionSelections,  productCode,  skipInventoryCheck,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Validate the final state of shopper-selected options.
		/// </summary>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="skipInventoryCheck">If true, skip the process to validate inventory when creating this product reservation.</param>
		/// <param name="productOptionSelections">For a product with shopper-configurable options, the properties of the product options selected by the shopper.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var productValidationSummary = await product.ValidateProductAsync( productOptionSelections,  productCode,  skipInventoryCheck,  quantity,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary> ValidateProductAsync(Mozu.Api.Contracts.ProductRuntime.ProductOptionSelections productOptionSelections, string productCode, bool? skipInventoryCheck =  null, int? quantity =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.ProductValidationSummary> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ValidateProductClient( productOptionSelections,  productCode,  skipInventoryCheck,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Evaluates whether a collection of discounts specified in the request can be redeemed for the supplied product code.
		/// </summary>
		/// <param name="allowInactive">If true, allow inactive categories to be retrieved in the category list response. If false, the categories retrieved will not include ones marked inactive.</param>
		/// <param name="customerAccountId">The unique identifier of the customer account for which to retrieve wish lists.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
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
		///   var discountValidationSummary = product.ValidateDiscounts( discountSelections,  productCode,  variationProductCode,  customerAccountId,  allowInactive,  skipInventoryCheck,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary ValidateDiscounts(Mozu.Api.Contracts.ProductRuntime.DiscountSelections discountSelections, string productCode, string variationProductCode =  null, int? customerAccountId =  null, bool? allowInactive =  null, bool? skipInventoryCheck =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ValidateDiscountsClient( discountSelections,  productCode,  variationProductCode,  customerAccountId,  allowInactive,  skipInventoryCheck,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Evaluates whether a collection of discounts specified in the request can be redeemed for the supplied product code.
		/// </summary>
		/// <param name="allowInactive">If true, allow inactive categories to be retrieved in the category list response. If false, the categories retrieved will not include ones marked inactive.</param>
		/// <param name="customerAccountId">The unique identifier of the customer account for which to retrieve wish lists.</param>
		/// <param name="productCode">Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.</param>
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
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary> ValidateDiscountsAsync(Mozu.Api.Contracts.ProductRuntime.DiscountSelections discountSelections, string productCode, string variationProductCode =  null, int? customerAccountId =  null, bool? allowInactive =  null, bool? skipInventoryCheck =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.DiscountValidationSummary> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.ValidateDiscountsClient( discountSelections,  productCode,  variationProductCode,  customerAccountId,  allowInactive,  skipInventoryCheck,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves product inventories for the storefront displayed products.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="query">Properties for the product location inventory provided for queries to locate products by their location.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var product = new Product();
		///   var locationInventoryCollection = product.GetProductInventories(_dataViewMode,  query,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection GetProductInventories(Mozu.Api.Contracts.ProductRuntime.LocationInventoryQuery query, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductInventoriesClient(_dataViewMode,  query,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves product inventories for the storefront displayed products.
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
		public virtual async Task<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> GetProductInventoriesAsync(Mozu.Api.Contracts.ProductRuntime.LocationInventoryQuery query, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductRuntime.LocationInventoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Storefront.ProductClient.GetProductInventoriesClient(_dataViewMode,  query,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}


	}

}



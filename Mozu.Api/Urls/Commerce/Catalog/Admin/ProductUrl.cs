
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

namespace Mozu.Api.Urls.Commerce.Catalog.Admin
{
	public partial class ProductUrl 
	{

		/// <summary>
        /// Get Resource Url for GetProducts
        /// </summary>
        /// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
        /// <param name="noCount">If true, the operation does not return the TotalCount number of results.</param>
        /// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
        /// <param name="q">A list of order search terms (not phrases) to use in the query when searching across order number and the name or email of the billing contact. When entering, separate multiple search terms with a space character.</param>
        /// <param name="qLimit">The maximum number of search results to return in the response. You can limit any range between 1-100.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
        /// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetProductsUrl(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string q =  null, int? qLimit =  null, bool? noCount =  null, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/?startIndex={startIndex}&pageSize={pageSize}&sortBy={sortBy}&filter={filter}&q={q}&qLimit={qLimit}&noCount={noCount}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "filter", filter);
			mozuUrl.FormatUrl( "noCount", noCount);
			mozuUrl.FormatUrl( "pageSize", pageSize);
			mozuUrl.FormatUrl( "q", q);
			mozuUrl.FormatUrl( "qLimit", qLimit);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "sortBy", sortBy);
			mozuUrl.FormatUrl( "startIndex", startIndex);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetProductInCatalogs
        /// </summary>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetProductInCatalogsUrl(string productCode)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}/ProductInCatalogs";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productCode", productCode);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetProductInCatalog
        /// </summary>
        /// <param name="catalogId">Unique identifier for a catalog.</param>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetProductInCatalogUrl(string productCode, int catalogId, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}/ProductInCatalogs/{catalogId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "catalogId", catalogId);
			mozuUrl.FormatUrl( "productCode", productCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetProduct
        /// </summary>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetProductUrl(string productCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productCode", productCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddProduct
        /// </summary>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddProductUrl(string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for AddProductInCatalog
        /// </summary>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddProductInCatalogUrl(string productCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}/ProductInCatalogs?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productCode", productCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for RenameProductCodes
        /// </summary>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl RenameProductCodesUrl()
		{
			var url = "/api/commerce/catalog/admin/products/Actions/RenameProductCodes";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateProductInCatalogs
        /// </summary>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateProductInCatalogsUrl(string productCode)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}/ProductInCatalogs";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productCode", productCode);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateProductInCatalog
        /// </summary>
        /// <param name="catalogId">Unique identifier for a catalog.</param>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateProductInCatalogUrl(string productCode, int catalogId, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}/ProductInCatalogs/{catalogId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "catalogId", catalogId);
			mozuUrl.FormatUrl( "productCode", productCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateProduct
        /// </summary>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateProductUrl(string productCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productCode", productCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteProduct
        /// </summary>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteProductUrl(string productCode)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productCode", productCode);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for DeleteProductInCatalog
        /// </summary>
        /// <param name="catalogId">Unique identifier for a catalog.</param>
        /// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteProductInCatalogUrl(string productCode, int catalogId)
		{
			var url = "/api/commerce/catalog/admin/products/{productCode}/ProductInCatalogs/{catalogId}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "catalogId", catalogId);
			mozuUrl.FormatUrl( "productCode", productCode);
			return mozuUrl;
		}

		
	}
}


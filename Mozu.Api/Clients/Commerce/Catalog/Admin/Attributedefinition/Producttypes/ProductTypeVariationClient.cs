
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin.Attributedefinition.Producttypes
{
	/// <summary>
	/// Use the variations resource to preview possible product variations for a specific product type based on the option attributes defined for the product type, such as size or color.
	/// </summary>
	public partial class ProductTypeVariationClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="productTypeId">Identifier of the product type.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="productOptionsIn">Properties of the product option to create such as attribute detail, fully qualified name, and list of product option values.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductVariationPagedCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GenerateProductVariations( productOptionsIn,  productTypeId,  productCode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var productVariationPagedCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductVariationPagedCollection> GenerateProductVariationsClient(List<Mozu.Api.Contracts.ProductAdmin.ProductOption> productOptionsIn, int productTypeId, string productCode =  null, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Producttypes.ProductTypeVariationUrl.GenerateProductVariationsUrl(productTypeId, productCode, startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductVariationPagedCollection>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<List<Mozu.Api.Contracts.ProductAdmin.ProductOption>>(productOptionsIn);
			return mozuClient;

		}


	}

}



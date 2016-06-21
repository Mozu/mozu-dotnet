
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin
{
	/// <summary>
	/// Allows you to create and manage products that you will offer on your storefront. You can create products with options that a shopper configures (such as a T-shirt color and size). You can set discounts and sale prices for your products, manage product inventory, and more.
	/// </summary>
	public partial class PriceListClient 	{
		
		/// <summary>
		/// admin-pricelists Get GetPriceLists description DOCUMENT_HERE 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.PriceListCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetPriceLists( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var priceListCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceListCollection> GetPriceListsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.PriceListUrl.GetPriceListsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceListCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// admin-pricelists Get GetPriceList description DOCUMENT_HERE 
		/// </summary>
		/// <param name="priceListCode">The unique, user-defined code of the price list.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.PriceList"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetPriceList( priceListCode,  responseFields);
		///   var priceListClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceList> GetPriceListClient(string priceListCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.PriceListUrl.GetPriceListUrl(priceListCode, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceList>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// admin-pricelists Post AddPriceList description DOCUMENT_HERE 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="priceList">Mozu.ProductAdmin.Contracts.PriceList ApiType DOCUMENT_HERE </param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.PriceList"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddPriceList( priceList,  responseFields);
		///   var priceListClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceList> AddPriceListClient(Mozu.Api.Contracts.ProductAdmin.PriceList priceList, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.PriceListUrl.AddPriceListUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceList>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.PriceList>(priceList);
			return mozuClient;

		}

		/// <summary>
		/// admin-pricelists Put UpdatePriceList description DOCUMENT_HERE 
		/// </summary>
		/// <param name="priceListCode">The unique, user-defined code of the price list.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="priceList">Mozu.ProductAdmin.Contracts.PriceList ApiType DOCUMENT_HERE </param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.PriceList"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdatePriceList( priceList,  priceListCode,  responseFields);
		///   var priceListClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceList> UpdatePriceListClient(Mozu.Api.Contracts.ProductAdmin.PriceList priceList, string priceListCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.PriceListUrl.UpdatePriceListUrl(priceListCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceList>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.PriceList>(priceList);
			return mozuClient;

		}

		/// <summary>
		/// admin-pricelists Delete DeletePriceList description DOCUMENT_HERE 
		/// </summary>
		/// <param name="cascadeDeleteEntries">Specifies whether to deletes all price list entries associated with the price list.</param>
		/// <param name="priceListCode">The unique, user-defined code of the price list.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeletePriceList( priceListCode,  cascadeDeleteEntries);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeletePriceListClient(string priceListCode, bool? cascadeDeleteEntries =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.PriceListUrl.DeletePriceListUrl(priceListCode, cascadeDeleteEntries);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



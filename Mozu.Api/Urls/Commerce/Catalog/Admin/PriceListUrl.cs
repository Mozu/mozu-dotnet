
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
	public partial class PriceListUrl 
	{

		/// <summary>
        /// Get Resource Url for GetPriceLists
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <param name="responseFields"></param>
        /// <param name="sortBy"></param>
        /// <param name="startIndex"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetPriceListsUrl(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/pricelists/?startIndex={startIndex}&pageSize={pageSize}&sortBy={sortBy}&filter={filter}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "filter", filter);
			mozuUrl.FormatUrl( "pageSize", pageSize);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "sortBy", sortBy);
			mozuUrl.FormatUrl( "startIndex", startIndex);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetPriceList
        /// </summary>
        /// <param name="priceListCode"></param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetPriceListUrl(string priceListCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/pricelists/{priceListCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "priceListCode", priceListCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddPriceList
        /// </summary>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddPriceListUrl(string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/pricelists/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdatePriceList
        /// </summary>
        /// <param name="priceListCode"></param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdatePriceListUrl(string priceListCode, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/pricelists/{priceListCode}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "priceListCode", priceListCode);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeletePriceList
        /// </summary>
        /// <param name="cascadeDeleteEntries"></param>
        /// <param name="priceListCode"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeletePriceListUrl(string priceListCode, bool? cascadeDeleteEntries =  null)
		{
			var url = "/api/commerce/catalog/admin/pricelists/{priceListCode}?cascadeDeleteEntries={cascadeDeleteEntries}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "cascadeDeleteEntries", cascadeDeleteEntries);
			mozuUrl.FormatUrl( "priceListCode", priceListCode);
			return mozuUrl;
		}

		
	}
}


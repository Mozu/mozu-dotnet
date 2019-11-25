
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

namespace Mozu.Api.Urls.Commerce.Catalog.Admin.Attributedefinition.Producttypes
{
	public partial class ProductTypeExtraUrl 
	{

		/// <summary>
        /// Get Resource Url for GetExtras
        /// </summary>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetExtrasUrl(int productTypeId)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Extras";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetExtra
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetExtraUrl(int productTypeId, string attributeFQN, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Extras/{attributeFQN}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddExtra
        /// </summary>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddExtraUrl(int productTypeId, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Extras?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateExtra
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateExtraUrl(int productTypeId, string attributeFQN, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Extras/{attributeFQN}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteExtra
        /// </summary>
        /// <param name="attributeFQN">Fully qualified name for an attribute.</param>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteExtraUrl(int productTypeId, string attributeFQN)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Extras/{attributeFQN}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			return mozuUrl;
		}

		
	}
}


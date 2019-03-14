
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
	public partial class ProductTypePropertyUrl 
	{

		/// <summary>
        /// Get Resource Url for GetProperties
        /// </summary>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetPropertiesUrl(int productTypeId)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Properties";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetProperty
        /// </summary>
        /// <param name="attributeFQN"></param>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetPropertyUrl(int productTypeId, string attributeFQN, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Properties/{attributeFQN}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddProperty
        /// </summary>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddPropertyUrl(int productTypeId, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Properties?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateProperty
        /// </summary>
        /// <param name="attributeFQN"></param>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdatePropertyUrl(int productTypeId, string attributeFQN, string responseFields =  null)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Properties/{attributeFQN}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteProperty
        /// </summary>
        /// <param name="attributeFQN"></param>
        /// <param name="productTypeId">Identifier of the product type.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeletePropertyUrl(int productTypeId, string attributeFQN)
		{
			var url = "/api/commerce/catalog/admin/attributedefinition/producttypes/{productTypeId}/Properties/{attributeFQN}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "attributeFQN", attributeFQN);
			mozuUrl.FormatUrl( "productTypeId", productTypeId);
			return mozuUrl;
		}

		
	}
}


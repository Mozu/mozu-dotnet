
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin.Products
{
	/// <summary>
	/// Use the Extras resource to configure an extra product attribute for products associated with the product type that uses the extra attribute.
	/// </summary>
	public partial class ProductExtraClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtra"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetExtras(dataViewMode,  productCode);
		///   var productExtraClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductExtra>> GetExtrasClient(DataViewMode dataViewMode, string productCode)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.GetExtrasUrl(productCode);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductExtra>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetExtraValueLocalizedDeltaPrices(dataViewMode,  productCode,  attributeFQN,  value);
		///   var productExtraValueDeltaPriceClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>> GetExtraValueLocalizedDeltaPricesClient(DataViewMode dataViewMode, string productCode, string attributeFQN, string value)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.GetExtraValueLocalizedDeltaPricesUrl(productCode, attributeFQN, value);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="currencyCode">The three character ISOÂ currency code, such as USDÂ for US Dollars.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetExtraValueLocalizedDeltaPrice(dataViewMode,  productCode,  attributeFQN,  value,  currencyCode,  responseFields);
		///   var productExtraValueDeltaPriceClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice> GetExtraValueLocalizedDeltaPriceClient(DataViewMode dataViewMode, string productCode, string attributeFQN, string value, string currencyCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.GetExtraValueLocalizedDeltaPriceUrl(productCode, attributeFQN, value, currencyCode, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtra"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetExtra(dataViewMode,  productCode,  attributeFQN,  responseFields);
		///   var productExtraClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtra> GetExtraClient(DataViewMode dataViewMode, string productCode, string attributeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.GetExtraUrl(productCode, attributeFQN, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtra>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="localizedDeltaPrice">The properties of the price difference between the product extra and the base product.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddExtraValueLocalizedDeltaPrice(dataViewMode,  localizedDeltaPrice,  productCode,  attributeFQN,  value,  responseFields);
		///   var productExtraValueDeltaPriceClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice> AddExtraValueLocalizedDeltaPriceClient(DataViewMode dataViewMode, Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice localizedDeltaPrice, string productCode, string attributeFQN, string value, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.AddExtraValueLocalizedDeltaPriceUrl(productCode, attributeFQN, value, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>(localizedDeltaPrice)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="productExtra">Properties of an extra attribute to defined for a product that is associated with a product type that uses the extra. Setting up extras for a product enables shopper-entered information, such as initials for a monogram.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtra"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddExtra(dataViewMode,  productExtra,  productCode,  responseFields);
		///   var productExtraClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtra> AddExtraClient(DataViewMode dataViewMode, Mozu.Api.Contracts.ProductAdmin.ProductExtra productExtra, string productCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.AddExtraUrl(productCode, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtra>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.ProductExtra>(productExtra)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="localizedDeltaPrice">The properties of the price difference between the product extra and the base product.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateExtraValueLocalizedDeltaPrices(dataViewMode,  localizedDeltaPrice,  productCode,  attributeFQN,  value);
		///   var productExtraValueDeltaPriceClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>> UpdateExtraValueLocalizedDeltaPricesClient(DataViewMode dataViewMode, List<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice> localizedDeltaPrice, string productCode, string attributeFQN, string value)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.UpdateExtraValueLocalizedDeltaPricesUrl(productCode, attributeFQN, value);
			const string verb = "PUT";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<List<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>>(localizedDeltaPrice)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="currencyCode">The three character ISOÂ currency code, such as USDÂ for US Dollars.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="value">The value string to create.</param>
		/// <param name="localizedDeltaPrice">The properties of the price difference between the product extra and the base product.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateExtraValueLocalizedDeltaPrice(dataViewMode,  localizedDeltaPrice,  productCode,  attributeFQN,  value,  currencyCode,  responseFields);
		///   var productExtraValueDeltaPriceClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice> UpdateExtraValueLocalizedDeltaPriceClient(DataViewMode dataViewMode, Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice localizedDeltaPrice, string productCode, string attributeFQN, string value, string currencyCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.UpdateExtraValueLocalizedDeltaPriceUrl(productCode, attributeFQN, value, currencyCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.ProductExtraValueDeltaPrice>(localizedDeltaPrice)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="productExtra">Properties of an extra attribute to defined for a product that is associated with a product type that uses the extra. Setting up extras for a product enables shopper-entered information, such as initials for a monogram.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductExtra"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateExtra(dataViewMode,  productExtra,  productCode,  attributeFQN,  responseFields);
		///   var productExtraClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtra> UpdateExtraClient(DataViewMode dataViewMode, Mozu.Api.Contracts.ProductAdmin.ProductExtra productExtra, string productCode, string attributeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.UpdateExtraUrl(productCode, attributeFQN, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.ProductExtra>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.ProductExtra>(productExtra)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteExtra(dataViewMode,  productCode,  attributeFQN);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteExtraClient(DataViewMode dataViewMode, string productCode, string attributeFQN)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.DeleteExtraUrl(productCode, attributeFQN);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="currencyCode">The three character ISOÂ currency code, such as USDÂ for US Dollars.</param>
		/// <param name="productCode">The unique, user-defined product code of a product, used throughout  to reference and associate to a product.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteExtraValueLocalizedDeltaPrice(dataViewMode,  productCode,  attributeFQN,  value,  currencyCode);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteExtraValueLocalizedDeltaPriceClient(DataViewMode dataViewMode, string productCode, string attributeFQN, string value, string currencyCode)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Products.ProductExtraUrl.DeleteExtraValueLocalizedDeltaPriceUrl(productCode, attributeFQN, value, currencyCode);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}


	}

}




//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Products
{
		///
		///	The price of a product that appears on a storefront after any applied discounts.
		///
		public class ProductPrice
		{
			///
			///The credit value of the product or bundled product. When the `goodsType `is `DigitalCredit`, this value is populated to indicate the value of the credit. This is used to create store credit in the fulfillment of gift cards.
			///
			public decimal? CreditValue { get; set; }

			///
			///The manufacturer's suggested retail price (MSRP) for the product. This content may be defined by the supplier.
			///
			public decimal? Msrp { get; set; }

			public decimal? Price { get; set; }

			///
			///If the product's price comes from a price list, this property is the code of the price list with which the product is associated.
			///
			public string PriceListCode { get; set; }

			///
			///The price list entry mode of the product. This property is for future funtionality and currently should only be .
			///
			public string PriceListEntryMode { get; set; }

			public decimal? SalePrice { get; set; }

			public decimal? TenantOverridePrice { get; set; }

		}

}
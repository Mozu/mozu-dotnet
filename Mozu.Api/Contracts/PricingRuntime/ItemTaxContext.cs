
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.PricingRuntime
{
		///
		///	Properties of the tax context applicable for line items in an order.
		///
		public class ItemTaxContext
		{
			public string Id { get; set; }

			public string ProductCode { get; set; }

			public int Quantity { get; set; }

			public decimal ShippingTax { get; set; }

			public decimal Tax { get; set; }

			///
			///Leverage this property within a [tax Arc.js action](https://www.mozu.com/docs/arcjs/commerce-catalog-storefront-tax/commerce-catalog-storefront-tax.htm) to supplement the tax information for this item or object with custom JSON data.
			///
			public JObject TaxData { get; set; }

		}

}
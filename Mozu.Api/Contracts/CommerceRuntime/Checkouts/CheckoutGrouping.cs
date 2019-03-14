
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
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.CommerceRuntime.Discounts;
using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.CommerceRuntime.Checkouts
{
		public class CheckoutGrouping
		{
			public string DestinationId { get; set; }

			public decimal? DutyAmount { get; set; }

			public decimal DutyTotal { get; set; }

			public string FulfillmentMethod { get; set; }

			public decimal? HandlingAmount { get; set; }

			public List<AppliedDiscount> HandlingDiscounts { get; set; }

			public decimal HandlingSubTotal { get; set; }

			public decimal? HandlingTax { get; set; }

			public decimal HandlingTaxTotal { get; set; }

			public decimal HandlingTotal { get; set; }

			public string Id { get; set; }

			public decimal ItemLevelHandlingDiscountTotal { get; set; }

			public decimal ItemLevelShippingDiscountTotal { get; set; }

			public List<string> OrderItemIds { get; set; }

			public decimal OrderLevelHandlingDiscountTotal { get; set; }

			public decimal OrderLevelShippingDiscountTotal { get; set; }

			public decimal? ShippingAmount { get; set; }

			public List<ShippingDiscount> ShippingDiscounts { get; set; }

			public string ShippingMethodCode { get; set; }

			public string ShippingMethodName { get; set; }

			public decimal ShippingSubTotal { get; set; }

			public decimal? ShippingTax { get; set; }

			public decimal ShippingTaxTotal { get; set; }

			public decimal ShippingTotal { get; set; }

			public bool StandaloneGroup { get; set; }

			public JObject TaxData { get; set; }

		}

}
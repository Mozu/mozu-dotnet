
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

using Mozu.Api.Contracts.CommerceRuntime.Commerce;
using Mozu.Api.Contracts.CommerceRuntime.Products;
using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.CommerceRuntime.Fulfillment
{
		public class ShipmentItem
		{
			public decimal ActualPrice { get; set; }

			public DateTime? BackorderReleaseDate { get; set; }

			public JObject Data { get; set; }

			public decimal Duty { get; set; }

			public string FulfillmentLocationCode { get; set; }

			public decimal Handling { get; set; }

			public decimal HandlingDiscount { get; set; }

			public decimal HandlingTax { get; set; }

			public string ImageUrl { get; set; }

			public bool? IsPackagedStandAlone { get; set; }

			public bool IsTaxable { get; set; }

			public decimal ItemDiscount { get; set; }

			public decimal ItemTax { get; set; }

			public int LineId { get; set; }

			public decimal LineItemCost { get; set; }

			public PackageMeasurements Measurements { get; set; }

			public string Name { get; set; }

			public string OptionAttributeFQN { get; set; }

			public List<ProductOption> Options { get; set; }

			public string OriginalOrderItemId { get; set; }

			public decimal? OverridePrice { get; set; }

			public string ParentId { get; set; }

			public string ProductCode { get; set; }

			public int Quantity { get; set; }

			public decimal Shipping { get; set; }

			public decimal ShippingDiscount { get; set; }

			public decimal ShippingTax { get; set; }

			public JObject TaxData { get; set; }

			public decimal UnitPrice { get; set; }

			public string VariationProductCode { get; set; }

		}

}
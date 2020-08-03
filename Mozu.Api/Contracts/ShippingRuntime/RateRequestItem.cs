
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

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.ShippingRuntime
{
		///
		///	Properties of an item for which to calculate a shipping rate.
		///
		public class RateRequestItem
		{
			///
			///Data unique to the shipping rate for the item.
			///
			public JObject Data { get; set; }

			public string ItemId { get; set; }

			///
			///If Product Summaries are populated, this information will be utilized in Product Rules (e.g. ProductCode eq "ABC" or (Weight.Unit eq "lbs" and Weight.Value ge 50)
			///
			public List<ProductSummary> ProductSummaries { get; set; }

			public int? Quantity { get; set; }

			public bool? ShipsByItself { get; set; }

			public ItemMeasurements UnitMeasurements { get; set; }

		}

}
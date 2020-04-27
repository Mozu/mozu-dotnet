
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


namespace Mozu.Api.Contracts.ProductRuntime
{
		///
		///	Mozu.ProductRuntime.Contracts.VariationSummary ApiType DOCUMENT_HERE 
		///
		public class VariationSummary
		{
			///
			///Properties and data of inventory information for configured and bundled products. If product stock is managed, the data specifies out of stock behavior.
			///
			public ProductInventoryInfo InventoryInfo { get; set; }

			///
			///List of option attributes configured for an object. These values are associated and used by products, product bundles, and product types.
			///
			public List<VariationOption> Options { get; set; }

			///
			///The unique, user-defined product code of a product, used throughout  to reference and associate to a product.
			///
			public string ProductCode { get; set; }

		}

}
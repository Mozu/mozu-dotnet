
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
		///	The value selected for a facet when indexing a product search.
		///
		public class FacetValue
		{
			public List<FacetValue> ChildrenFacetValues { get; set; }

			public int Count { get; set; }

			public string FilterValue { get; set; }

			public bool? IsApplied { get; set; }

			///
			///Indicates if the object is displayed on the storefront. If true, the admin product category is displayed in the store. If false, the category is not displayed.
			///
			public bool IsDisplayed { get; set; }

			public string Label { get; set; }

			public string ParentFacetValue { get; set; }

			public string RangeQueryValueEnd { get; set; }

			public string RangeQueryValueStart { get; set; }

			public string Value { get; set; }

		}

}
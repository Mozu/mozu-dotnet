
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


namespace Mozu.Api.Contracts.PricingRuntime
{
		///
		///	Properties of the target to which the discount applies, such as the type of discount and which products, categories, or shipping methods are eligible for the discount and the properties of this discount target.
		///
		public class DiscountTarget
		{
			///
			///The operator to use on the excludedCategories field. Valid values are: "All" and "Any".
			///
			public string ExcludedCategoriesOperator { get; set; }

			///
			///A list of categories to be excluded from the discount.
			///
			public List<int> ExcludedCategoryIds { get; set; }

			///
			///A list of product codes to be excluded from the discount.
			///
			public List<string> ExcludedProductCodes { get; set; }

			///
			///If true, the target discount applies to all products sold on the site, regardless of product category.
			///
			public bool IncludeAllProducts { get; set; }

			///
			///The operator of the includedCategories field.Valid values are: "All" and "Any".
			///
			public string IncludedCategoriesOperator { get; set; }

			///
			///A list of categories to be included with the discount.
			///
			public List<int> IncludedCategoryIds { get; set; }

			///
			///A list of product codes to be included in the discount.
			///
			public List<string> IncludedProductCodes { get; set; }

			///
			///The list of shipping method codes that represents the shipping service types to which the discount can apply.
			///
			public List<string> ShippingMethods { get; set; }

			///
			///The list of shipping zones that are applicable for this discount.
			///
			public List<string> ShippingZones { get; set; }

			public string Type { get; set; }

		}

}
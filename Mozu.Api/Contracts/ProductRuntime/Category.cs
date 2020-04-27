
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
		///	A descriptive container that groups products. A category is merchant defined with associated products and discounts as configured. GThe storefront displays products in a hierarchy of categories. As such, categories can include a nesting of sub-categories to organize products and product options per set guidelines such as color, brand, material, and size.
		///
		public class Category
		{
			///
			///External unique identifier of the category.
			///
			public string CategoryCode { get; set; }

			public int CategoryId { get; set; }

			public List<Category> ChildrenCategories { get; set; }

			public CategoryContent Content { get; set; }

			///
			///The total number of associated items.
			///
			public int? Count { get; set; }

			///
			///Indicates if the object is displayed on the storefront. If true, the admin product category is displayed in the store. If false, the category is not displayed.
			///
			public bool IsDisplayed { get; set; }

			public Category ParentCategory { get; set; }

			public int? Sequence { get; set; }

			public DateTime UpdateDate { get; set; }

		}

}
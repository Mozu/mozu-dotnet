
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.ProductAdmin
{
		///
		///	A descriptive container in a storefront hierarchy to organize collections of products.
		///
		public class Category
		{
			///
			///Identifier and datetime stamp information recorded when a user or application creates, updates, or deletes a resource entity. This value is system-supplied and read-only.
			///
			public AuditInfo AuditInfo { get; set; }

			public int? CatalogId { get; set; }

			public string CategoryCode { get; set; }

			///
			///The number of children (subcategories, for example) that stem from a parent (top-level category).
			///
			public int? ChildCount { get; set; }

			///
			///Complex type that contains content for a language specified by LocaleCode.
			///
			public CategoryLocalizedContent Content { get; set; }

			///
			///Identifier of the entity.
			///
			public int? Id { get; set; }

			///
			///If true, the admin product category is displayed in the store. If true, the category is not displayed.
			///
			public bool? IsDisplayed { get; set; }

			///
			///Identifier of the parent or top-level category.
			///
			public int? ParentCategoryId { get; set; }

			///
			///The number of products in a list.
			///
			public int? ProductCount { get; set; }

			///
			///The numeric value that denotes the place this entity occupies in the order of the entity list.
			///
			public int? Sequence { get; set; }

		}

}
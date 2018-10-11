
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Discounts
{
		public class SuggestedDiscount
		{
			///
			///Indicates whether the free BOGA item should automatically be added to cart. If the free item has been added before and the shopper removed the free item (rejected it), the value will be false.
			///
			public bool AutoAdd { get; set; }

			///
			///The unique identifier of the discount.
			///
			public int DiscountId { get; set; }

			///
			///The unique, user-defined product code of a product, used throughout  to reference and associate to a product.
			///
			public string ProductCode { get; set; }

		}

}
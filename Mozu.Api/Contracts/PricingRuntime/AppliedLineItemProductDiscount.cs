
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.PricingRuntime
{
		///
		///	The discount applied to the line item.
		///
		public class AppliedLineItemProductDiscount
		{
			///
			///Specifies whether the line item discount applies to items that are on sale.
			///
			public bool AppliesToSalePrice { get; set; }

			///
			///The coupon code that a shopper uses to redeem an associated discount  on a purchase. This is also the unique identifier of the coupon itself.
			///
			public string CouponCode { get; set; }

			///
			///The unique identifier of the coupon set for the discount applied to the line item.
			///
			public int? CouponSetId { get; set; }

			///
			///Name of the discount added and applied to a shopping cart and order for a shopper's purchase.
			///
			public Discount Discount { get; set; }

			///
			///The value of the discount applied to the cart or order, represented as a negative currency amount to apply to the original price.
			///
			public decimal Impact { get; set; }

			///
			///The impact of a discount for each discount quantity.
			///
			public decimal ImpactPerUnit { get; set; }

			///
			///Specifies whether to force the discount to apply to the line item.
			///
			public bool IsForced { get; set; }

			public decimal NormalizedImpact { get; set; }

			///
			///The specified quantity of objects and items. This property is used for numerous object types including products, options, components within a product bundle, cart and order items, returned items, shipping line items, items in a digital product. and items associated with types and reservations.
			///
			public int Quantity { get; set; }

		}

}

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
		///	Properties for the applied discounts to a cart, order, or product.
		///
		public class AppliedDiscount
		{
			public string CouponCode { get; set; }

			///
			///The unique identifier of the coupon set for the applied discount.
			///
			public int? CouponSetId { get; set; }

			public Discount Discount { get; set; }

			public decimal Impact { get; set; }

		}

}
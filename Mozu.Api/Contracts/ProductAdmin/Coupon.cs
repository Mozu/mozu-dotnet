
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
		///	Mozu.ProductAdmin.Contracts.Coupon ApiType DOCUMENT_HERE 
		///
		public class Coupon
		{
			///
			///Basic audit info about the object, including date, time, and user account. This data may be captured when creating, updating, and removing data.
			///
			public AuditInfo AuditInfo { get; set; }

			///
			///Specifies whether the coupon can be deleted and removed from a coupon set.
			///
			public bool CanBeDeleted { get; set; }

			///
			///The coupon code that a shopper uses to redeem an associated discount  on a purchase. This is also the unique identifier of the coupon itself.
			///
			public string CouponCode { get; set; }

			///
			///The unique identifier of the coupon set that the coupon belongs to.
			///
			public string CouponSetCode { get; set; }

			///
			///The unique, system generated id of the coupon set that contains the coupon.This value is read only.
			///
			public int CouponSetId { get; set; }

			///
			///The total number of times the coupon has been redeemed. When you perform a GetCoupon or GetCoupons operation, set the includeCounts operation parameter to true to view this field.This field is read only.
			///
			public int? RedemptionCount { get; set; }

		}

}

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
using Mozu.Api.Security;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mozu.Api.Clients.Commerce.Orders
{
	/// <summary>
	/// Use this subresource to apply coupons to or remove coupons from an order based on a supplied coupon code.
	/// </summary>
	public partial class AppliedDiscountClient 	{
		
		/// <summary>
		/// Apply a coupon to the order.
		/// </summary>
		/// <param name="couponCode">Alphanumeric code associated with the coupon or promotion that results in a discounted price.</param>
		/// <param name="orderId">Unique identifier of the order to associate the coupon. System-supplied and read-only.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="updateMode">Specifies whether to apply the coupon by updating the original order, updating the order in draft mode, or updating the order in draft mode and then commit the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ApplyCoupon( orderId,  couponCode,  updateMode,  version,  responseFields);
		///   var orderClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> ApplyCouponClient(string orderId, string couponCode, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.AppliedDiscountUrl.ApplyCouponUrl(orderId, couponCode, updateMode, version, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Removes a coupon previously applied to the order.
		/// </summary>
		/// <param name="couponCode">Alphanumeric code associated with the coupon or promotion that results in a discounted price.</param>
		/// <param name="orderId">Unique identifier of the order with the coupon to remove.</param>
		/// <param name="updateMode">Specifies whether to remove the coupon by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RemoveCoupon( orderId,  couponCode,  updateMode,  version);
		///   var orderClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveCouponClient(string orderId, string couponCode, string updateMode =  null, string version =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.AppliedDiscountUrl.RemoveCouponUrl(orderId, couponCode, updateMode, version);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Removes all coupons previously applied to the order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order with the coupons to remove.</param>
		/// <param name="updateMode">Specifies whether to remove coupons by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RemoveCoupons( orderId,  updateMode,  version);
		///   var orderClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveCouponsClient(string orderId, string updateMode =  null, string version =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.AppliedDiscountUrl.RemoveCouponsUrl(orderId, updateMode, version);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



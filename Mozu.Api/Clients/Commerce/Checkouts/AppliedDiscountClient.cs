
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
using System.Threading;

namespace Mozu.Api.Clients.Commerce.Checkouts
{
	/// <summary>
	/// 
	/// </summary>
	public partial class AppliedDiscountClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkoutId"></param>
		/// <param name="couponCode"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ApplyCoupon( checkoutId,  couponCode,  responseFields);
		///   var checkoutClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout> ApplyCouponClient(string checkoutId, string couponCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Checkouts.AppliedDiscountUrl.ApplyCouponUrl(checkoutId, couponCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkoutId"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RemoveCoupons( checkoutId);
		///   var checkoutClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout> RemoveCouponsClient(string checkoutId)
		{
			var url = Mozu.Api.Urls.Commerce.Checkouts.AppliedDiscountUrl.RemoveCouponsUrl(checkoutId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkoutId"></param>
		/// <param name="couponCode"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RemoveCoupon( checkoutId,  couponCode);
		///   var checkoutClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout> RemoveCouponClient(string checkoutId, string couponCode)
		{
			var url = Mozu.Api.Urls.Commerce.Checkouts.AppliedDiscountUrl.RemoveCouponUrl(checkoutId, couponCode);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Checkouts.Checkout>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



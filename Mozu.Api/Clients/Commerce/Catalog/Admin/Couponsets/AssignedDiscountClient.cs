
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin.Couponsets
{
	/// <summary>
	/// Use the AssignedDiscounts resource to manage the discounts assigned to coupon sets.
	/// </summary>
	public partial class AssignedDiscountClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="couponSetCode">The unique identifier of the coupon set.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ProductAdmin.AssignedDiscount"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAssignedDiscounts( couponSetCode);
		///   var assignedDiscountClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AssignedDiscount>> GetAssignedDiscountsClient(string couponSetCode)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Couponsets.AssignedDiscountUrl.GetAssignedDiscountsUrl(couponSetCode);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ProductAdmin.AssignedDiscount>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="couponSetCode">The unique identifier of the coupon set.</param>
		/// <param name="assignedDiscount">The details of the discount assigned to the coupon set.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AssignDiscount( assignedDiscount,  couponSetCode);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> AssignDiscountClient(Mozu.Api.Contracts.ProductAdmin.AssignedDiscount assignedDiscount, string couponSetCode)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Couponsets.AssignedDiscountUrl.AssignDiscountUrl(couponSetCode);
			const string verb = "POST";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.AssignedDiscount>(assignedDiscount);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="couponSetCode">The unique identifier of the coupon set.</param>
		/// <param name="discountId">discountId parameter description DOCUMENT_HERE </param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UnAssignDiscount( couponSetCode,  discountId);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> UnAssignDiscountClient(string couponSetCode, int discountId)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.Couponsets.AssignedDiscountUrl.UnAssignDiscountUrl(couponSetCode, discountId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



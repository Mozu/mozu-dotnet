
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

namespace Mozu.Api.Clients.Commerce.Catalog.Admin
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CouponSetClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includeCounts"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.CouponSetCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCouponSets( startIndex,  pageSize,  sortBy,  filter,  includeCounts,  responseFields);
		///   var couponSetCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSetCollection> GetCouponSetsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, bool? includeCounts =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.GetCouponSetsUrl(startIndex, pageSize, sortBy, filter, includeCounts, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSetCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="couponSetCode"></param>
		/// <param name="includeCounts"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.CouponSet"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCouponSet( couponSetCode,  includeCounts,  responseFields);
		///   var couponSetClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSet> GetCouponSetClient(string couponSetCode, bool? includeCounts =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.GetCouponSetUrl(couponSetCode, includeCounts, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSet>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{string}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetUniqueCouponSetCode( responseFields);
		///   var stringClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<string> GetUniqueCouponSetCodeClient(string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.GetUniqueCouponSetCodeUrl(responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<string>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="couponSet"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.CouponSet"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddCouponSet( couponSet,  responseFields);
		///   var couponSetClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSet> AddCouponSetClient(Mozu.Api.Contracts.ProductAdmin.CouponSet couponSet, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.AddCouponSetUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSet>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.CouponSet>(couponSet);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ValidateUniqueCouponSetCode( code);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient ValidateUniqueCouponSetCodeClient(string code)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.ValidateUniqueCouponSetCodeUrl(code);
			const string verb = "POST";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="couponSetCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="couponSet"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ProductAdmin.CouponSet"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateCouponSet( couponSet,  couponSetCode,  responseFields);
		///   var couponSetClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSet> UpdateCouponSetClient(Mozu.Api.Contracts.ProductAdmin.CouponSet couponSet, string couponSetCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.UpdateCouponSetUrl(couponSetCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ProductAdmin.CouponSet>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ProductAdmin.CouponSet>(couponSet);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="couponSetCode"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteCouponSet( couponSetCode);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteCouponSetClient(string couponSetCode)
		{
			var url = Mozu.Api.Urls.Commerce.Catalog.Admin.CouponSetUrl.DeleteCouponSetUrl(couponSetCode);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



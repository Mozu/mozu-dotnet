
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin
{
	/// <summary>
	/// Define and manage discounts to apply to products, product categories, or orders. The discounts can be a specified amount off the price, percentage off the price, or for free shipping. Create a coupon code that shoppers can use to redeem the discount.
	/// </summary>
	public partial class DiscountResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		private readonly DataViewMode _dataViewMode;
		
		public DiscountResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
			_dataViewMode = DataViewMode.Live;
		}

		public DiscountResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new DiscountResource(_apiContext.CloneWith(contextModification), _dataViewMode);
		}

		public DiscountResource(IApiContext apiContext, DataViewMode dataViewMode) 
		{
			_apiContext = apiContext;
			_dataViewMode = dataViewMode;
		}
				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DiscountCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var discountCollection = await discount.GetDiscountsAsync(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.DiscountCollection> GetDiscountsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DiscountCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.GetDiscountsClient(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="discountId">Unique identifier of the discount. System-supplied and read-only.</param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var discountLocalizedContent = await discount.GetDiscountContentAsync(_dataViewMode,  discountId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent> GetDiscountContentAsync(int discountId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.GetDiscountContentClient(_dataViewMode,  discountId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="discountId">Unique identifier of the discount. System-supplied and read-only.</param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Discount"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var discount = await discount.GetDiscountAsync(_dataViewMode,  discountId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.Discount> GetDiscountAsync(int discountId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Discount> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.GetDiscountClient(_dataViewMode,  discountId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <returns>
		/// string
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var string = await discount.GenerateRandomCouponAsync( responseFields);
		/// </code>
		/// </example>
		public virtual async Task<string> GenerateRandomCouponAsync(string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<string> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.GenerateRandomCouponClient( responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="discount">Properties of the discount to create. You must specify the discount name, amount type, start date, and target.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Discount"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var discount = await discount.CreateDiscountAsync( discount,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.Discount> CreateDiscountAsync(Mozu.Api.Contracts.ProductAdmin.Discount discount, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Discount> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.CreateDiscountClient( discount,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="discountId">Unique identifier of the discount. System-supplied and read-only.</param>
		/// <param name="responseFields"></param>
		/// <param name="content">The discount content to update, including the discount name.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var discountLocalizedContent = await discount.UpdateDiscountContentAsync( content,  discountId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent> UpdateDiscountContentAsync(Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent content, int discountId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.UpdateDiscountContentClient( content,  discountId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="discountId">Unique identifier of the discount to update.</param>
		/// <param name="responseFields"></param>
		/// <param name="discount">Properties of the discount to update.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Discount"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   var discount = await discount.UpdateDiscountAsync( discount,  discountId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.Discount> UpdateDiscountAsync(Mozu.Api.Contracts.ProductAdmin.Discount discount, int discountId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Discount> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.UpdateDiscountClient( discount,  discountId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="discountId">Unique identifier of the discount. System-supplied and read-only.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var discount = new Discount();
		///   await discount.DeleteDiscountAsync( discountId);
		/// </code>
		/// </example>
		public virtual async Task DeleteDiscountAsync(int discountId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.DiscountClient.DeleteDiscountClient( discountId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}




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

namespace Mozu.Api.Resources.Commerce.Wishlists
{
	/// <summary>
	/// Use the Wish List Items subresource to manage items in a shopper wish list. The same product can be defined as an item in any number of wish lists for the customer account. Use the Wish Lists resource to manage shopper wish lists.
	/// </summary>
	public partial class WishlistItemResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public WishlistItemResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public WishlistItemResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new WishlistItemResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <param name="wishlistItemId">Unique identifier of the item to remove from the shopper wish list.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlistItem = await wishlistitem.GetWishlistItemAsync( wishlistId,  wishlistItemId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> GetWishlistItemAsync(string wishlistId, string wishlistItemId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.GetWishlistItemClient( wishlistId,  wishlistItemId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItemCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlistItemCollection = await wishlistitem.GetWishlistItemsAsync( wishlistId,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItemCollection> GetWishlistItemsAsync(string wishlistId, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItemCollection> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.GetWishlistItemsClient( wishlistId,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="customerAccountId">The unique identifier of the customer account for which to retrieve wish lists.</param>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <param name="wishlistName">The name of the wish list to retrieve.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItemCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlistItemCollection = await wishlistitem.GetWishlistItemsByWishlistNameAsync( customerAccountId,  wishlistName,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItemCollection> GetWishlistItemsByWishlistNameAsync(int customerAccountId, string wishlistName, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItemCollection> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.GetWishlistItemsByWishlistNameClient( customerAccountId,  wishlistName,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <param name="wishlistItem">Properties of an item in a shopper wish list.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlistItem = await wishlistitem.AddItemToWishlistAsync( wishlistItem,  wishlistId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> AddItemToWishlistAsync(Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem wishlistItem, string wishlistId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.AddItemToWishlistClient( wishlistItem,  wishlistId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="quantity">The number of cart items in the shopper's active cart.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <param name="wishlistItemId">Unique identifier of the item to remove from the shopper wish list.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlistItem = await wishlistitem.UpdateWishlistItemQuantityAsync( wishlistId,  wishlistItemId,  quantity,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> UpdateWishlistItemQuantityAsync(string wishlistId, string wishlistItemId, int quantity, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.UpdateWishlistItemQuantityClient( wishlistId,  wishlistItemId,  quantity,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <param name="wishlistItemId">Unique identifier of the item to remove from the shopper wish list.</param>
		/// <param name="wishlistItem">Properties of an item in a shopper wish list.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlistItem = await wishlistitem.UpdateWishlistItemAsync( wishlistItem,  wishlistId,  wishlistItemId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> UpdateWishlistItemAsync(Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem wishlistItem, string wishlistId, string wishlistItemId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.WishlistItem> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.UpdateWishlistItemClient( wishlistItem,  wishlistId,  wishlistItemId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Wishlists.Wishlist"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var wishlist = await wishlistitem.RemoveAllWishlistItemsAsync( wishlistId);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Wishlists.Wishlist> RemoveAllWishlistItemsAsync(string wishlistId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Wishlists.Wishlist> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.RemoveAllWishlistItemsClient( wishlistId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="wishlistId">Unique identifier of the wish list.</param>
		/// <param name="wishlistItemId">Unique identifier of the item to remove from the shopper wish list.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var wishlistitem = new WishlistItem();
		///   var stream = await wishlistitem.DeleteWishlistItemAsync( wishlistId,  wishlistItemId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteWishlistItemAsync(string wishlistId, string wishlistItemId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Wishlists.WishlistItemClient.DeleteWishlistItemClient( wishlistId,  wishlistItemId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



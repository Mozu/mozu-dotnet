
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

namespace Mozu.Api.Clients.Commerce
{
	/// <summary>
	/// Use this resource to manage storefront shopping carts as shoppers add and remove items for purchase. Each time a shopper's cart is modified, the Carts resource updates the estimated total with any applicable discounts.
	/// </summary>
	public partial class CartClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cartId"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCartSummaryByCartId( cartId,  responseFields);
		///   var cartSummaryClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary> GetCartSummaryByCartIdClient(string cartId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetCartSummaryByCartIdUrl(cartId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cartId">Identifier of the cart to delete.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCart( cartId,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> GetCartClient(string cartId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetCartUrl(cartId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetOrCreateCart( responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> GetOrCreateCartClient(string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetOrCreateCartUrl(responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCartSummary( responseFields);
		///   var cartSummaryClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary> GetCartSummaryClient(string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetCartSummaryUrl(responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetUserCartSummary( userId,  responseFields);
		///   var cartSummaryClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary> GetUserCartSummaryClient(string userId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetUserCartSummaryUrl(userId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.CartSummary>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetUserCart( userId,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> GetUserCartClient(string userId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetUserCartUrl(userId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cartId">Identifier of the cart to delete.</param>
		/// <param name="discountId">discountId parameter description DOCUMENT_HERE </param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RejectSuggestedDiscount( cartId,  discountId,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> RejectSuggestedDiscountClient(string cartId, int discountId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.RejectSuggestedDiscountUrl(cartId, discountId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="userId"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetOrCreateUserCart( userId,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> GetOrCreateUserCartClient(string userId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.GetOrCreateUserCartUrl(userId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cartId"></param>
		/// <param name="responseFields"></param>
		/// <param name="cart"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateCartByCartId( cart,  cartId,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> UpdateCartByCartIdClient(Mozu.Api.Contracts.CommerceRuntime.Carts.Cart cart, string cartId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.UpdateCartByCartIdUrl(cartId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>(cart);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="cart">Properties of a shopping cart.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateCart( cart,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> UpdateCartClient(Mozu.Api.Contracts.CommerceRuntime.Carts.Cart cart, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.UpdateCartUrl(responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>(cart);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="userId"></param>
		/// <param name="cart"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Carts.Cart"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateUserCart( cart,  userId,  responseFields);
		///   var cartClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart> UpdateUserCartClient(Mozu.Api.Contracts.CommerceRuntime.Carts.Cart cart, string userId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.UpdateUserCartUrl(userId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Carts.Cart>(cart);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cartId">Identifier of the cart to delete.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteCart( cartId);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteCartClient(string cartId)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.DeleteCartUrl(cartId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteUserCart( userId);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteUserCartClient(string userId)
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.DeleteUserCartUrl(userId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteCurrentCart();
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteCurrentCartClient()
		{
			var url = Mozu.Api.Urls.Commerce.CartUrl.DeleteCurrentCartUrl();
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}




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

namespace Mozu.Api.Clients.Commerce.Orders
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CanceledReasonClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.CancelReasonCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetReasons( category,  responseFields);
		///   var cancelReasonCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.CancelReasonCollection> GetReasonsClient(string category =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.CanceledReasonUrl.GetReasonsUrl(category, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.CancelReasonCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="responseFields"></param>
		/// <param name="reason"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CancelOrder( reason,  orderId,  responseFields);
		///   var orderClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> CancelOrderClient(Mozu.Api.Contracts.CommerceRuntime.Orders.CanceledReason reason, string orderId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Orders.CanceledReasonUrl.CancelOrderUrl(orderId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Orders.CanceledReason>(reason);
			return mozuClient;

		}


	}

}



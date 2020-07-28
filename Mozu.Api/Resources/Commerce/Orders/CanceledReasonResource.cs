
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

namespace Mozu.Api.Resources.Commerce.Orders
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CanceledReasonResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CanceledReasonResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CanceledReasonResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CanceledReasonResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.CancelReasonCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var canceledreason = new CanceledReason();
		///   var cancelReasonCollection = await canceledreason.GetReasonsAsync( category,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.CancelReasonCollection> GetReasonsAsync(string category =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.CancelReasonCollection> response;
			var client = Mozu.Api.Clients.Commerce.Orders.CanceledReasonClient.GetReasonsClient( category,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="responseFields"></param>
		/// <param name="reason"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var canceledreason = new CanceledReason();
		///   var order = await canceledreason.CancelOrderAsync( reason,  orderId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> CancelOrderAsync(Mozu.Api.Contracts.CommerceRuntime.Orders.CanceledReason reason, string orderId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.CanceledReasonClient.CancelOrderClient( reason,  orderId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



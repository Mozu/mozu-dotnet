
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
	/// Use this subresource to manage ad-hoc order level price adjustments.
	/// </summary>
	public partial class AdjustmentResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public AdjustmentResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public AdjustmentResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new AdjustmentResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="responseFields"></param>
		/// <param name="updateMode"></param>
		/// <param name="version"></param>
		/// <param name="adjustment"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.ApplyHandlingAdjustmentAsync( adjustment,  orderId,  updateMode,  version,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> ApplyHandlingAdjustmentAsync(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyHandlingAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order associated with the shipping adjustment.</param>
		/// <param name="responseFields"></param>
		/// <param name="updateMode">Specifies whether to apply the shipping adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version"></param>
		/// <param name="adjustment">Properties of the shipping adjustment to apply to the order.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.ApplyShippingAdjustmentAsync( adjustment,  orderId,  updateMode,  version,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> ApplyShippingAdjustmentAsync(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyShippingAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order for which to apply the adjustment.</param>
		/// <param name="responseFields"></param>
		/// <param name="updateMode">Specifies whether to apply the adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version"></param>
		/// <param name="adjustment">Properties of the price adjustment to apply to the order.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.ApplyAdjustmentAsync( adjustment,  orderId,  updateMode,  version,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> ApplyAdjustmentAsync(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="updateMode"></param>
		/// <param name="version"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.RemoveHandlingAdjustmentAsync( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveHandlingAdjustmentAsync(string orderId, string updateMode =  null, string version =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveHandlingAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order with the applied shipping adjustment.</param>
		/// <param name="updateMode">Specifies whether to remove the shipping adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then commit the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.RemoveShippingAdjustmentAsync( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveShippingAdjustmentAsync(string orderId, string updateMode =  null, string version =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveShippingAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="orderId">Unique identifier of the order for which to delete the adjustment.</param>
		/// <param name="updateMode">Specifies whether to remove the adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.RemoveAdjustmentAsync( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveAdjustmentAsync(string orderId, string updateMode =  null, string version =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}




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
		/// Applies a shipping adjustment to the specified order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order associated with the shipping adjustment.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="updateMode">Specifies whether to apply the shipping adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <param name="adjustment">Properties of the shipping adjustment to apply to the order.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = adjustment.ApplyShippingAdjustment( adjustment,  orderId,  updateMode,  version,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.CommerceRuntime.Orders.Order ApplyShippingAdjustment(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyShippingAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Applies a shipping adjustment to the specified order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order associated with the shipping adjustment.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="updateMode">Specifies whether to apply the shipping adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
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
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> ApplyShippingAdjustmentAsync(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyShippingAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Applies a price adjustment to the specified order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order for which to apply the adjustment.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="updateMode">Specifies whether to apply the adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <param name="adjustment">Properties of the price adjustment to apply to the order.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = adjustment.ApplyAdjustment( adjustment,  orderId,  updateMode,  version,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.CommerceRuntime.Orders.Order ApplyAdjustment(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Applies a price adjustment to the specified order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order for which to apply the adjustment.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="updateMode">Specifies whether to apply the adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
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
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> ApplyAdjustmentAsync(Mozu.Api.Contracts.CommerceRuntime.Commerce.Adjustment adjustment, string orderId, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.ApplyAdjustmentClient( adjustment,  orderId,  updateMode,  version,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Removes a shipping adjustment previously applied to an order or draft.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order with the applied shipping adjustment.</param>
		/// <param name="updateMode">Specifies whether to remove the shipping adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then commit the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = adjustment.RemoveShippingAdjustment( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.CommerceRuntime.Orders.Order RemoveShippingAdjustment(string orderId, string updateMode =  null, string version =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveShippingAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Removes a shipping adjustment previously applied to an order or draft.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order with the applied shipping adjustment.</param>
		/// <param name="updateMode">Specifies whether to remove the shipping adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then commit the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.RemoveShippingAdjustmentAsync( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveShippingAdjustmentAsync(string orderId, string updateMode =  null, string version =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveShippingAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Removes a price adjustment from the specified order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order for which to delete the adjustment.</param>
		/// <param name="updateMode">Specifies whether to remove the adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = adjustment.RemoveAdjustment( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.CommerceRuntime.Orders.Order RemoveAdjustment(string orderId, string updateMode =  null, string version =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Removes a price adjustment from the specified order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order for which to delete the adjustment.</param>
		/// <param name="updateMode">Specifies whether to remove the adjustment by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
		/// <param name="version">System-supplied integer that represents the current version of the order, which prevents users from unintentionally overriding changes to the order. When a user performs an operation for a defined order, the system validates that the version of the updated order matches the version of the order on the server. After the operation completes successfully, the system increments the version number by one.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.Order"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adjustment = new Adjustment();
		///   var order = await adjustment.RemoveAdjustmentAsync( orderId,  updateMode,  version);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> RemoveAdjustmentAsync(string orderId, string updateMode =  null, string version =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.Order> response;
			var client = Mozu.Api.Clients.Commerce.Orders.AdjustmentClient.RemoveAdjustmentClient( orderId,  updateMode,  version);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}


	}

}



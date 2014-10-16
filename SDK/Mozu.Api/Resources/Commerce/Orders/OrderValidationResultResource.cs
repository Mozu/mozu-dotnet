
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
	/// Manage the results of order validation.
	/// </summary>
	public partial class OrderValidationResultResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public OrderValidationResultResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public OrderValidationResultResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new OrderValidationResultResource(_apiContext.CloneWith(contextModification));
		}

				
		/// <summary>
		/// Retrieves a list of the validation results associated with the order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order.</param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var ordervalidationresult = new OrderValidationResult();
		///   var orderValidationResult = ordervalidationresult.GetValidationResults( orderId);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult> GetValidationResults(string orderId)
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult>> response;
			var client = Mozu.Api.Clients.Commerce.Orders.OrderValidationResultClient.GetValidationResultsClient( orderId);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult>> GetValidationResultsAsync(string orderId)
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult>> response;
			var client = Mozu.Api.Clients.Commerce.Orders.OrderValidationResultClient.GetValidationResultsClient( orderId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Add a new order validation result to a submitted order.
		/// </summary>
		/// <param name="orderId">Unique identifier of the order.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="validationResult">Properties of the validation result to add for the order.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var ordervalidationresult = new OrderValidationResult();
		///   var orderValidationResult = ordervalidationresult.AddValidationResult( validationResult,  orderId,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult AddValidationResult(Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult validationResult, string orderId, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult> response;
			var client = Mozu.Api.Clients.Commerce.Orders.OrderValidationResultClient.AddValidationResultClient( validationResult,  orderId,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult> AddValidationResultAsync(Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult validationResult, string orderId, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderValidationResult> response;
			var client = Mozu.Api.Clients.Commerce.Orders.OrderValidationResultClient.AddValidationResultClient( validationResult,  orderId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}


	}

}



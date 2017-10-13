
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

namespace Mozu.Api.Resources.Commerce.Checkouts
{
	/// <summary>
	/// 
	/// </summary>
	public partial class OrderAttributeResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public OrderAttributeResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public OrderAttributeResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new OrderAttributeResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkoutId"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var orderattribute = new OrderAttribute();
		///   var orderAttribute = await orderattribute.GetCheckoutAttributesAsync( checkoutId);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute>> GetCheckoutAttributesAsync(string checkoutId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute>> response;
			var client = Mozu.Api.Clients.Commerce.Checkouts.OrderAttributeClient.GetCheckoutAttributesClient( checkoutId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkoutId"></param>
		/// <param name="checkoutAttributes"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var orderattribute = new OrderAttribute();
		///   var orderAttribute = await orderattribute.CreateCheckoutAttributesAsync( checkoutAttributes,  checkoutId);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute>> CreateCheckoutAttributesAsync(List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute> checkoutAttributes, string checkoutId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute>> response;
			var client = Mozu.Api.Clients.Commerce.Checkouts.OrderAttributeClient.CreateCheckoutAttributesClient( checkoutAttributes,  checkoutId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkoutId"></param>
		/// <param name="removeMissing"></param>
		/// <param name="checkoutAttributes"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var orderattribute = new OrderAttribute();
		///   var orderAttribute = await orderattribute.UpdateCheckoutAttributeAsync( checkoutAttributes,  checkoutId,  removeMissing);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute>> UpdateCheckoutAttributeAsync(List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute> checkoutAttributes, string checkoutId, bool? removeMissing =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderAttribute>> response;
			var client = Mozu.Api.Clients.Commerce.Checkouts.OrderAttributeClient.UpdateCheckoutAttributeClient( checkoutAttributes,  checkoutId,  removeMissing);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mozu.Api.Resources.Commerce.Inventory
{
	/// <summary>
	/// 
	/// </summary>
    public partial class InventoryResource
    {
		private readonly IApiContext _apiContext;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiContext"></param>
		public InventoryResource(IApiContext apiContext)
		{
			_apiContext = apiContext;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contextModification"></param>
		/// <returns></returns>
		public InventoryResource CloneWithApiContext(Action<IApiContext> contextModification)
		{
			return new InventoryResource(_apiContext.CloneWith(contextModification));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="aggregateRequest"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<List<Mozu.Api.Contracts.Inventory.AggregateResponse>> AggregateAsync(AggregateRequest aggregateRequest, string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.Inventory.AggregateResponse>> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.InventoryClient.AggregateClient(aggregateRequest, responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inventoryRequest"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<List<Mozu.Api.Contracts.Inventory.InventoryResponse>> PostQueryInventoryAsync(InventoryRequest inventoryRequest, string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.Inventory.InventoryResponse>> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.InventoryClient.PostQueryInventoryClient(inventoryRequest, responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}
	}
}

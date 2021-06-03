using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Clients.Commerce.Inventory
{
	/// <summary>
	/// 
	/// </summary>
    public partial class InventoryClient
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="aggregateRequest"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<List<Mozu.Api.Contracts.Inventory.AggregateResponse>> AggregateClient(AggregateRequest aggregateRequest, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.InventoryUrl.AggregateUrl(aggregateRequest, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.Inventory.AggregateResponse>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Inventory.AggregateRequest>(aggregateRequest);

			return mozuClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inventoryRequest"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<List<Mozu.Api.Contracts.Inventory.InventoryResponse>> PostQueryInventoryClient(InventoryRequest inventoryRequest, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.InventoryUrl.PostQueryInventoryUrl(inventoryRequest, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.Inventory.InventoryResponse>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Inventory.InventoryRequest>(inventoryRequest);

			return mozuClient;
		}
	}
}

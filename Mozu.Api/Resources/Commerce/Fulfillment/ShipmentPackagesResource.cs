using Mozu.Api.Contracts.Fulfillment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace Mozu.Api.Resources.Commerce.Fulfillment
{
    public partial class ShipmentPackagesResource
    {
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;


		public ShipmentPackagesResource(IApiContext apiContext)
		{
			_apiContext = apiContext;
		}

		public ShipmentPackagesResource CloneWithApiContext(Action<IApiContext> contextModification)
		{
			return new ShipmentPackagesResource(_apiContext.CloneWith(contextModification));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="package"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment> NewPackageAsync(int shipmentNumber, Package package, string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentPackagesClient.NewPackageClient(shipmentNumber, package, responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="package"></param>
		/// <param name="packageId"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment> UpdatePackageAsync(int shipmentNumber, string packageId, Package package, string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentPackagesClient.UpdatePackageClient(shipmentNumber, packageId, package, responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}
	}
}

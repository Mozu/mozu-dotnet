using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mozu.Api.Resources.Commerce.Fulfillment
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ShipmentDataResource
    {

		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;


		public ShipmentDataResource(IApiContext apiContext)
		{
			_apiContext = apiContext;
		}

		public ShipmentDataResource CloneWithApiContext(Action<IApiContext> contextModification)
		{
			return new ShipmentDataResource(_apiContext.CloneWith(contextModification));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Dictionary<string, object>> GetShipmentDataAsync(int shipmentNumber,  CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Dictionary<string, object>> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.GetShipmentDataClient(shipmentNumber);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Dictionary<string, object>> ReplaceShipmentDataAsync(int shipmentNumber, Dictionary<string, object> data, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Dictionary<string, object>> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.ReplaceShipmentDataClient(shipmentNumber, data);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<System.IO.Stream> DeleteShipmentDataAsync(int shipmentNumber, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.DeleteShipmentDataClient(shipmentNumber);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}




		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="key"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<System.IO.Stream> DeleteShipmentDataByKeyAsync(int shipmentNumber, string key, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.DeleteShipmentDataByKeyClient(shipmentNumber, key);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Dictionary<string, object>> GetShipmentItemDataAsync(int shipmentNumber, int lineId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Dictionary<string, object>> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.GetShipmentItemDataClient(shipmentNumber, lineId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="data"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Dictionary<string, object>> ReplaceShipmentItemDataAsync(int shipmentNumber,int lineId, Dictionary<string, object> data, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Dictionary<string, object>> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.ReplaceShipmentItemDataClient(shipmentNumber,lineId, data);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<System.IO.Stream> DeleteShipmentItemDataAsync(int shipmentNumber, int lineId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.DeleteShipmentItemDataClient(shipmentNumber, lineId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}




		/// <summary>
		/// 
		/// </summary>
		/// <param name="shipmentNumber"></param>
		/// <param name="lineId"></param>
		/// <param name="key"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<System.IO.Stream> DeleteShipmentItemDataByKeyAsync(int shipmentNumber,int lineId, string key, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Fulfillment.ShipmentDataClient.DeleteShipmentItemDataByKeyClient(shipmentNumber, lineId, key);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}
	}
}

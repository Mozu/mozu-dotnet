
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

namespace Mozu.Api.Resources.Commerce.Returns
{
	/// <summary>
	/// Use the Return Shipments subresource to manage shipments for a return replacement.
	/// </summary>
	public partial class ShipmentResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public ShipmentResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public ShipmentResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ShipmentResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="returnId">Unique identifier of the return whose items you want to get.</param>
		/// <param name="shipmentId">Unique identifier of the shipment to retrieve.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var shipment = new Shipment();
		///   var shipment = await shipment.GetShipmentAsync( returnId,  shipmentId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment> GetShipmentAsync(string returnId, string shipmentId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment> response;
			var client = Mozu.Api.Clients.Commerce.Returns.ShipmentClient.GetShipmentClient( returnId,  shipmentId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="returnId">Unique identifier of the return whose items you want to get.</param>
		/// <param name="packageIds">List of unique identifiers for each package associated with this shipment. Not all packages must belong to the same shipment.</param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var shipment = new Shipment();
		///   var package = await shipment.CreatePackageShipmentsAsync( packageIds,  returnId);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package>> CreatePackageShipmentsAsync(List<string> packageIds, string returnId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package>> response;
			var client = Mozu.Api.Clients.Commerce.Returns.ShipmentClient.CreatePackageShipmentsClient( packageIds,  returnId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="returnId">Unique identifier of the return whose items you want to get.</param>
		/// <param name="shipmentId">Unique identifier of the shipment to retrieve.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var shipment = new Shipment();
		///   await shipment.DeleteShipmentAsync( returnId,  shipmentId);
		/// </code>
		/// </example>
		public virtual async Task DeleteShipmentAsync(string returnId, string shipmentId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Returns.ShipmentClient.DeleteShipmentClient( returnId,  shipmentId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



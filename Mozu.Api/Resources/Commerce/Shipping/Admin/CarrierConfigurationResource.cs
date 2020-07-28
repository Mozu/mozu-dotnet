
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

namespace Mozu.Api.Resources.Commerce.Shipping.Admin
{
	/// <summary>
	/// Use the Carriers resource to configure and manage your supported shipping carrier configurations.
	/// </summary>
	public partial class CarrierConfigurationResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CarrierConfigurationResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CarrierConfigurationResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CarrierConfigurationResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfigurationCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var carrierconfiguration = new CarrierConfiguration();
		///   var carrierConfigurationCollection = await carrierconfiguration.GetConfigurationsAsync( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ShippingAdmin.CarrierConfigurationCollection> GetConfigurationsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfigurationCollection> response;
			var client = Mozu.Api.Clients.Commerce.Shipping.Admin.CarrierConfigurationClient.GetConfigurationsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var carrierconfiguration = new CarrierConfiguration();
		///   var carrierConfiguration = await carrierconfiguration.GetConfigurationAsync( carrierId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> GetConfigurationAsync(string carrierId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> response;
			var client = Mozu.Api.Clients.Commerce.Shipping.Admin.CarrierConfigurationClient.GetConfigurationClient( carrierId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="carrierConfiguration">Properties of a carrier configured in the shipping admin.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var carrierconfiguration = new CarrierConfiguration();
		///   var carrierConfiguration = await carrierconfiguration.CreateConfigurationAsync( carrierConfiguration,  carrierId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> CreateConfigurationAsync(Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration carrierConfiguration, string carrierId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> response;
			var client = Mozu.Api.Clients.Commerce.Shipping.Admin.CarrierConfigurationClient.CreateConfigurationClient( carrierConfiguration,  carrierId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="carrierConfiguration">Properties of a carrier configured in the shipping admin.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var carrierconfiguration = new CarrierConfiguration();
		///   var carrierConfiguration = await carrierconfiguration.UpdateConfigurationAsync( carrierConfiguration,  carrierId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> UpdateConfigurationAsync(Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration carrierConfiguration, string carrierId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> response;
			var client = Mozu.Api.Clients.Commerce.Shipping.Admin.CarrierConfigurationClient.UpdateConfigurationClient( carrierConfiguration,  carrierId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier configuration.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var carrierconfiguration = new CarrierConfiguration();
		///   var stream = await carrierconfiguration.DeleteConfigurationAsync( carrierId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteConfigurationAsync(string carrierId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Shipping.Admin.CarrierConfigurationClient.DeleteConfigurationClient( carrierId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}




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

namespace Mozu.Api.Resources.Commerce
{
	/// <summary>
	/// Use the Location resource to retrieve details about a location from a  hosted storefront.
	/// </summary>
	public partial class LocationResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public LocationResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public LocationResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new LocationResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeAttributeDefinition">True if you want to include the custom attribute defintion for the location.</param>
		/// <param name="locationCode">The unique, user-defined code that identifies a location.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.Location"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var location = await location.GetLocationAsync( locationCode,  includeAttributeDefinition,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.Location> GetLocationAsync(string locationCode, bool? includeAttributeDefinition =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.Location> response;
			var client = Mozu.Api.Clients.Commerce.LocationClient.GetLocationClient( locationCode,  includeAttributeDefinition,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="includeAttributeDefinition">True if you want to include the custom attribute defintion for the location.</param>
		/// <param name="locationUsageType">System-defined location usage type code, which is DS for direct ship, SP for in-store pickup, or storeFinder.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.LocationCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var locationCollection = await location.GetLocationsInUsageTypeAsync( locationUsageType,  startIndex,  pageSize,  sortBy,  filter,  includeAttributeDefinition,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationCollection> GetLocationsInUsageTypeAsync(string locationUsageType, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, bool? includeAttributeDefinition =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationCollection> response;
			var client = Mozu.Api.Clients.Commerce.LocationClient.GetLocationsInUsageTypeClient( locationUsageType,  startIndex,  pageSize,  sortBy,  filter,  includeAttributeDefinition,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeAttributeDefinition"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.Location"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var location = await location.GetDirectShipLocationAsync( includeAttributeDefinition,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.Location> GetDirectShipLocationAsync(bool? includeAttributeDefinition =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.Location> response;
			var client = Mozu.Api.Clients.Commerce.LocationClient.GetDirectShipLocationClient( includeAttributeDefinition,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeAttributeDefinition">True if you want to include the custom attribute definition for the location.</param>
		/// <param name="locationCode">The unique, user-defined code that identifies a location.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.Location"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var location = await location.GetInStorePickupLocationAsync( locationCode,  includeAttributeDefinition,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.Location> GetInStorePickupLocationAsync(string locationCode, bool? includeAttributeDefinition =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.Location> response;
			var client = Mozu.Api.Clients.Commerce.LocationClient.GetInStorePickupLocationClient( locationCode,  includeAttributeDefinition,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="includeAttributeDefinition">True if you want to include the custom attribute definition for the location.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.LocationCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var locationCollection = await location.GetInStorePickupLocationsAsync( startIndex,  pageSize,  sortBy,  filter,  includeAttributeDefinition,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationCollection> GetInStorePickupLocationsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, bool? includeAttributeDefinition =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationCollection> response;
			var client = Mozu.Api.Clients.Commerce.LocationClient.GetInStorePickupLocationsClient( startIndex,  pageSize,  sortBy,  filter,  includeAttributeDefinition,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



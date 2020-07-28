
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

namespace Mozu.Api.Resources.Commerce.Admin
{
	/// <summary>
	/// Use the Locations resource to manage each physical location associated with a tenant. Locations enable tenants to associate a physical address with product inventory, provide a store finder for in-store pickup, or both. Locations that support inventory can use both direct ship and in-store pickup fulfillment types.
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
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
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
		///   var locationCollection = await location.GetLocationsAsync( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationCollection> GetLocationsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationCollection> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationClient.GetLocationsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationCode">The unique, user-defined code that identifies a location. </param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.Location"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var location = await location.GetLocationAsync( locationCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.Location> GetLocationAsync(string locationCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.Location> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationClient.GetLocationClient( locationCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="location">Properties of a physical location a tenant uses to manage inventory and fulfills orders, provide store finder functionality, or both.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.Location"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var location = await location.AddLocationAsync( location,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.Location> AddLocationAsync(Mozu.Api.Contracts.Location.Location location, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.Location> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationClient.AddLocationClient( location,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationCode">The unique, user-defined code that identifies a location. </param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="location">Properties of a physical location a tenant uses to manage inventory and fulfills orders, provide store finder functionality, or both.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.Location"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var location = await location.UpdateLocationAsync( location,  locationCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.Location> UpdateLocationAsync(Mozu.Api.Contracts.Location.Location location, string locationCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.Location> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationClient.UpdateLocationClient( location,  locationCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationCode">The unique, user-defined code that identifies a location. </param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var location = new Location();
		///   var stream = await location.DeleteLocationAsync( locationCode);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteLocationAsync(string locationCode, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationClient.DeleteLocationClient( locationCode);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



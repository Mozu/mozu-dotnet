
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
	/// 
	/// </summary>
	public partial class LocationGroupResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public LocationGroupResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public LocationGroupResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new LocationGroupResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.LocationGroupCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var locationgroup = new LocationGroup();
		///   var locationGroupCollection = await locationgroup.GetLocationGroupsAsync( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationGroupCollection> GetLocationGroupsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationGroupCollection> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationGroupClient.GetLocationGroupsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationGroupCode"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.LocationGroup"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var locationgroup = new LocationGroup();
		///   var locationGroup = await locationgroup.GetLocationGroupAsync( locationGroupCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationGroup> GetLocationGroupAsync(string locationGroupCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationGroup> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationGroupClient.GetLocationGroupClient( locationGroupCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="group"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.LocationGroup"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var locationgroup = new LocationGroup();
		///   var locationGroup = await locationgroup.AddLocationGroupAsync( group,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationGroup> AddLocationGroupAsync(Mozu.Api.Contracts.Location.LocationGroup group, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationGroup> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationGroupClient.AddLocationGroupClient( group,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationGroupCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="locationGroup"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Location.LocationGroup"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var locationgroup = new LocationGroup();
		///   var locationGroup = await locationgroup.UpdateLocationGroupAsync( locationGroup,  locationGroupCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Location.LocationGroup> UpdateLocationGroupAsync(Mozu.Api.Contracts.Location.LocationGroup locationGroup, string locationGroupCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Location.LocationGroup> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationGroupClient.UpdateLocationGroupClient( locationGroup,  locationGroupCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationGroupCode"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var locationgroup = new LocationGroup();
		///   var stream = await locationgroup.DeleteLocationGroupAsync( locationGroupCode);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteLocationGroupAsync(string locationGroupCode, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Admin.LocationGroupClient.DeleteLocationGroupClient( locationGroupCode);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



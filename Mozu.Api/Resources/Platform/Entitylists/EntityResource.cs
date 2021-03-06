
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

namespace Mozu.Api.Resources.Platform.Entitylists
{
	/// <summary>
	/// Entities are JSON entries within the MZDBÂ ( Mongo DB) for handling large data sets to heavily filter (&gt;2,000 items). Each entity is associated to an EntityList with schema, rules, and formatting for storing the content. This content can be accessed via the  API and  Hypr tags.
	/// </summary>
	public partial class EntityResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public EntityResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public EntityResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new EntityResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// JObject
		/// </returns>
		/// <example>
		/// <code>
		///   var entity = new Entity();
		///   var json = await entity.GetEntityAsync( entityListFullName,  id,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<JObject> GetEntityAsync(string entityListFullName, string id, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<JObject> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.EntityClient.GetEntityClient( entityListFullName,  id,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.EntityCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var entity = new Entity();
		///   var entityCollection = await entity.GetEntitiesAsync( entityListFullName,  pageSize,  startIndex,  filter,  sortBy,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.EntityCollection> GetEntitiesAsync(string entityListFullName, int? pageSize =  null, int? startIndex =  null, string filter =  null, string sortBy =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.EntityCollection> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.EntityClient.GetEntitiesClient( entityListFullName,  pageSize,  startIndex,  filter,  sortBy,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="item">JSON code for objects.</param>
		/// <returns>
		/// JObject
		/// </returns>
		/// <example>
		/// <code>
		///   var entity = new Entity();
		///   var json = await entity.InsertEntityAsync( item,  entityListFullName,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<JObject> InsertEntityAsync(JObject item, string entityListFullName, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<JObject> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.EntityClient.InsertEntityClient( item,  entityListFullName,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="item">JSON code for objects.</param>
		/// <returns>
		/// JObject
		/// </returns>
		/// <example>
		/// <code>
		///   var entity = new Entity();
		///   var json = await entity.UpdateEntityAsync( item,  entityListFullName,  id,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<JObject> UpdateEntityAsync(JObject item, string entityListFullName, string id, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<JObject> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.EntityClient.UpdateEntityClient( item,  entityListFullName,  id,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var entity = new Entity();
		///   var stream = await entity.DeleteEntityAsync( entityListFullName,  id);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteEntityAsync(string entityListFullName, string id, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.EntityClient.DeleteEntityClient( entityListFullName,  id);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



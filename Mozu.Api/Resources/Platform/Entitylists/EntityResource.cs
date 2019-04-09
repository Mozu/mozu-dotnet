
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
	/// 
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
		/// <param name="entityListFullName"></param>
		/// <param name="id"></param>
		/// <param name="responseFields"></param>
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
		/// <param name="entityListFullName"></param>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
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
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="item"></param>
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
		/// <param name="entityListFullName"></param>
		/// <param name="id"></param>
		/// <param name="responseFields"></param>
		/// <param name="item"></param>
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
		/// <param name="entityListFullName"></param>
		/// <param name="id"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var entity = new Entity();
		///   await entity.DeleteEntityAsync( entityListFullName,  id);
		/// </code>
		/// </example>
		public virtual async Task DeleteEntityAsync(string entityListFullName, string id, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.Entitylists.EntityClient.DeleteEntityClient( entityListFullName,  id);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



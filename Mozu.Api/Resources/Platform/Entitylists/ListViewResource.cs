
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
	public partial class ListViewResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public ListViewResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public ListViewResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ListViewResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityId"></param>
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="viewName"></param>
		/// <returns>
		/// JObject
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var json = await listview.GetViewEntityAsync( entityListFullName,  viewName,  entityId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<JObject> GetViewEntityAsync(string entityListFullName, string viewName, string entityId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<JObject> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntityClient( entityListFullName,  viewName,  entityId,  responseFields);
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
		/// <param name="startIndex"></param>
		/// <param name="viewName"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.EntityCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var entityCollection = await listview.GetViewEntitiesAsync( entityListFullName,  viewName,  pageSize,  startIndex,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.EntityCollection> GetViewEntitiesAsync(string entityListFullName, string viewName, int? pageSize =  null, int? startIndex =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.EntityCollection> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntitiesClient( entityListFullName,  viewName,  pageSize,  startIndex,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityId"></param>
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="viewName"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.EntityContainer"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var entityContainer = await listview.GetViewEntityContainerAsync( entityListFullName,  viewName,  entityId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.EntityContainer> GetViewEntityContainerAsync(string entityListFullName, string viewName, string entityId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.EntityContainer> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntityContainerClient( entityListFullName,  viewName,  entityId,  responseFields);
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
		/// <param name="startIndex"></param>
		/// <param name="viewName"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.EntityContainerCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var entityContainerCollection = await listview.GetViewEntityContainersAsync( entityListFullName,  viewName,  pageSize,  startIndex,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.EntityContainerCollection> GetViewEntityContainersAsync(string entityListFullName, string viewName, int? pageSize =  null, int? startIndex =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.EntityContainerCollection> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntityContainersClient( entityListFullName,  viewName,  pageSize,  startIndex,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="viewName"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.ListView"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var listView = await listview.GetEntityListViewAsync( entityListFullName,  viewName,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.ListView> GetEntityListViewAsync(string entityListFullName, string viewName, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.ListView> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetEntityListViewClient( entityListFullName,  viewName,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.ListViewCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var listViewCollection = await listview.GetEntityListViewsAsync( entityListFullName,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.ListViewCollection> GetEntityListViewsAsync(string entityListFullName, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.ListViewCollection> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetEntityListViewsClient( entityListFullName,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="listView"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.ListView"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var listView = await listview.CreateEntityListViewAsync( listView,  entityListFullName,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.ListView> CreateEntityListViewAsync(Mozu.Api.Contracts.MZDB.ListView listView, string entityListFullName, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.ListView> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.CreateEntityListViewClient( listView,  entityListFullName,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="viewName"></param>
		/// <param name="listView"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.MZDB.ListView"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   var listView = await listview.UpdateEntityListViewAsync( listView,  entityListFullName,  viewName,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.MZDB.ListView> UpdateEntityListViewAsync(Mozu.Api.Contracts.MZDB.ListView listView, string entityListFullName, string viewName, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.MZDB.ListView> response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.UpdateEntityListViewClient( listView,  entityListFullName,  viewName,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName"></param>
		/// <param name="viewName"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var listview = new ListView();
		///   await listview.DeleteEntityListViewAsync( entityListFullName,  viewName);
		/// </code>
		/// </example>
		public virtual async Task DeleteEntityListViewAsync(string entityListFullName, string viewName, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.DeleteEntityListViewClient( entityListFullName,  viewName);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



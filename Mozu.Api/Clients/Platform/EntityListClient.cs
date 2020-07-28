
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

namespace Mozu.Api.Clients.Platform
{
	/// <summary>
	/// The Entity Lists resource manages all dynamic entities in your  document store of the  cloud. The content is JSON and can have up to five indexed properties (integer, decimal, string, date, and boolean) with support for additional customized elements as needed. Every document in the entity list has a validated unique ID.
	/// </summary>
	public partial class EntityListClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.MZDB.EntityListCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetEntityLists( pageSize,  startIndex,  filter,  sortBy,  responseFields);
		///   var entityListCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.MZDB.EntityListCollection> GetEntityListsClient(int? pageSize =  null, int? startIndex =  null, string filter =  null, string sortBy =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.EntityListUrl.GetEntityListsUrl(pageSize, startIndex, filter, sortBy, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.MZDB.EntityListCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.MZDB.EntityList"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetEntityList( entityListFullName,  responseFields);
		///   var entityListClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.MZDB.EntityList> GetEntityListClient(string entityListFullName, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.EntityListUrl.GetEntityListUrl(entityListFullName, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.MZDB.EntityList>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="entityList">The definition of an MZDB EntityList which describes the characteristics of the EntityList on a per tenant basis. EntityLists are created at the tenant level, but instances of the EntityLists are implicitly created at the appropriate context level as entities are added or removed from the EntityList.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.MZDB.EntityList"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateEntityList( entityList,  responseFields);
		///   var entityListClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.MZDB.EntityList> CreateEntityListClient(Mozu.Api.Contracts.MZDB.EntityList entityList, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.EntityListUrl.CreateEntityListUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.MZDB.EntityList>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.MZDB.EntityList>(entityList);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="entityList">The definition of an MZDB EntityList which describes the characteristics of the EntityList on a per tenant basis. EntityLists are created at the tenant level, but instances of the EntityLists are implicitly created at the appropriate context level as entities are added or removed from the EntityList.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.MZDB.EntityList"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateEntityList( entityList,  entityListFullName,  responseFields);
		///   var entityListClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.MZDB.EntityList> UpdateEntityListClient(Mozu.Api.Contracts.MZDB.EntityList entityList, string entityListFullName, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.EntityListUrl.UpdateEntityListUrl(entityListFullName, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.MZDB.EntityList>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.MZDB.EntityList>(entityList);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityListFullName">The full name of the EntityList including namespace in name@nameSpace format</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteEntityList( entityListFullName);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteEntityListClient(string entityListFullName)
		{
			var url = Mozu.Api.Urls.Platform.EntityListUrl.DeleteEntityListUrl(entityListFullName);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



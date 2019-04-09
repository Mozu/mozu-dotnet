
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
	/// 
	/// </summary>
	public partial class EntityListClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
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
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
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
		/// <param name="responseFields"></param>
		/// <param name="entityList"></param>
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
		/// <param name="entityListFullName"></param>
		/// <param name="responseFields"></param>
		/// <param name="entityList"></param>
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
		/// <param name="entityListFullName"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteEntityList( entityListFullName);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteEntityListClient(string entityListFullName)
		{
			var url = Mozu.Api.Urls.Platform.EntityListUrl.DeleteEntityListUrl(entityListFullName);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



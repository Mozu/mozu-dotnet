
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

namespace Mozu.Api.Clients.Commerce.Admin
{
	/// <summary>
	/// 
	/// </summary>
	public partial class LocationGroupClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationGroupCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLocationGroups( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var locationGroupCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationGroupCollection> GetLocationGroupsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationGroupUrl.GetLocationGroupsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationGroupCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationGroupCode"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationGroup"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLocationGroup( locationGroupCode,  responseFields);
		///   var locationGroupClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationGroup> GetLocationGroupClient(string locationGroupCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationGroupUrl.GetLocationGroupUrl(locationGroupCode, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationGroup>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="group"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationGroup"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddLocationGroup( group,  responseFields);
		///   var locationGroupClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationGroup> AddLocationGroupClient(Mozu.Api.Contracts.Location.LocationGroup group, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationGroupUrl.AddLocationGroupUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationGroup>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Location.LocationGroup>(group);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationGroupCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="locationGroup"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationGroup"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateLocationGroup( locationGroup,  locationGroupCode,  responseFields);
		///   var locationGroupClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationGroup> UpdateLocationGroupClient(Mozu.Api.Contracts.Location.LocationGroup locationGroup, string locationGroupCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationGroupUrl.UpdateLocationGroupUrl(locationGroupCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationGroup>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Location.LocationGroup>(locationGroup);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationGroupCode"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteLocationGroup( locationGroupCode);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteLocationGroupClient(string locationGroupCode)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationGroupUrl.DeleteLocationGroupUrl(locationGroupCode);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



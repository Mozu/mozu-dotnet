
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

namespace Mozu.Api.Clients.Commerce
{
	/// <summary>
	/// Use the Location resource to retrieve details about a location from a  hosted storefront.
	/// </summary>
	public partial class LocationClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeAttributeDefinition">True if you want to include the custom attribute defintion for the location.</param>
		/// <param name="locationCode">The unique, user-defined code that identifies a location.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.Location"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLocation( locationCode,  includeAttributeDefinition,  responseFields);
		///   var locationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.Location> GetLocationClient(string locationCode, bool? includeAttributeDefinition =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.LocationUrl.GetLocationUrl(locationCode, includeAttributeDefinition, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.Location>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

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
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLocationsInUsageType( locationUsageType,  startIndex,  pageSize,  sortBy,  filter,  includeAttributeDefinition,  responseFields);
		///   var locationCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationCollection> GetLocationsInUsageTypeClient(string locationUsageType, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, bool? includeAttributeDefinition =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.LocationUrl.GetLocationsInUsageTypeUrl(locationUsageType, startIndex, pageSize, sortBy, filter, includeAttributeDefinition, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeAttributeDefinition"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.Location"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetDirectShipLocation( includeAttributeDefinition,  responseFields);
		///   var locationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.Location> GetDirectShipLocationClient(bool? includeAttributeDefinition =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.LocationUrl.GetDirectShipLocationUrl(includeAttributeDefinition, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.Location>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="includeAttributeDefinition">True if you want to include the custom attribute definition for the location.</param>
		/// <param name="locationCode">The unique, user-defined code that identifies a location.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.Location"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetInStorePickupLocation( locationCode,  includeAttributeDefinition,  responseFields);
		///   var locationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.Location> GetInStorePickupLocationClient(string locationCode, bool? includeAttributeDefinition =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.LocationUrl.GetInStorePickupLocationUrl(locationCode, includeAttributeDefinition, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.Location>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

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
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetInStorePickupLocations( startIndex,  pageSize,  sortBy,  filter,  includeAttributeDefinition,  responseFields);
		///   var locationCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationCollection> GetInStorePickupLocationsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, bool? includeAttributeDefinition =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.LocationUrl.GetInStorePickupLocationsUrl(startIndex, pageSize, sortBy, filter, includeAttributeDefinition, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}




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
	/// Use the Location Types resource to manage the types of locations your tenant maintains, such as warehouses, physical storefronts, and kiosks.
	/// </summary>
	public partial class LocationTypeClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.Location.LocationType"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLocationTypes();
		///   var locationTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.Location.LocationType>> GetLocationTypesClient()
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationTypeUrl.GetLocationTypesUrl();
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.Location.LocationType>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationTypeCode">The user-defined code that identifies the location type.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationType"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLocationType( locationTypeCode,  responseFields);
		///   var locationTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationType> GetLocationTypeClient(string locationTypeCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationTypeUrl.GetLocationTypeUrl(locationTypeCode, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationType>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="locationType">Properties of a type of physical location, such as warehouse or kiosk. Location types enable tenants to group similar locations for filtering and location usage type definition.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationType"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddLocationType( locationType,  responseFields);
		///   var locationTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationType> AddLocationTypeClient(Mozu.Api.Contracts.Location.LocationType locationType, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationTypeUrl.AddLocationTypeUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationType>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Location.LocationType>(locationType);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationTypeCode">The user-defined code that identifies the location type.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="locationType">Properties of a type of physical location, such as warehouse or kiosk. Location types enable tenants to group similar locations for filtering and location usage type definition.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.LocationType"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateLocationType( locationType,  locationTypeCode,  responseFields);
		///   var locationTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Location.LocationType> UpdateLocationTypeClient(Mozu.Api.Contracts.Location.LocationType locationType, string locationTypeCode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationTypeUrl.UpdateLocationTypeUrl(locationTypeCode, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Location.LocationType>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Location.LocationType>(locationType);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationTypeCode">The user-defined code that identifies the location type.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteLocationType( locationTypeCode);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteLocationTypeClient(string locationTypeCode)
		{
			var url = Mozu.Api.Urls.Commerce.Admin.LocationTypeUrl.DeleteLocationTypeUrl(locationTypeCode);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}




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

namespace Mozu.Api.Clients.Commerce.Shipping.Admin
{
	/// <summary>
	/// Carrier Configuration for managing credentials and some settings for the various carriers installed with the default mozu application
	/// </summary>
	public partial class CarrierConfigurationClient 	{
		
		/// <summary>
		/// Retrieves a list of Carrier Configurations according to any specified filter criteria and sort options.
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfigurationCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetConfigurations( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var carrierConfigurationCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfigurationCollection> GetConfigurationsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.CarrierConfigurationUrl.GetConfigurationsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfigurationCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Get Carrier Configuration (for this particular site)
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetConfiguration( carrierId,  responseFields);
		///   var carrierConfigurationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> GetConfigurationClient(string carrierId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.CarrierConfigurationUrl.GetConfigurationUrl(carrierId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Create Carrier Configuration
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="carrierConfiguration">Properties of a carrier configured in the shipping admin.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateConfiguration( carrierConfiguration,  carrierId,  responseFields);
		///   var carrierConfigurationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> CreateConfigurationClient(Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration carrierConfiguration, string carrierId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.CarrierConfigurationUrl.CreateConfigurationUrl(carrierId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration>(carrierConfiguration);
			return mozuClient;

		}

		/// <summary>
		/// Update an existing Carrier Configuration
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="carrierConfiguration">Properties of a carrier configured in the shipping admin.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateConfiguration( carrierConfiguration,  carrierId,  responseFields);
		///   var carrierConfigurationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration> UpdateConfigurationClient(Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration carrierConfiguration, string carrierId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.CarrierConfigurationUrl.UpdateConfigurationUrl(carrierId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ShippingAdmin.CarrierConfiguration>(carrierConfiguration);
			return mozuClient;

		}

		/// <summary>
		/// Delete an existing Carrier Configuration
		/// </summary>
		/// <param name="carrierId">The unique identifier of the carrier configuration.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteConfiguration( carrierId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteConfigurationClient(string carrierId)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.CarrierConfigurationUrl.DeleteConfigurationUrl(carrierId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



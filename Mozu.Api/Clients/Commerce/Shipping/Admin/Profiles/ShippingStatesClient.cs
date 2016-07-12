
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

namespace Mozu.Api.Clients.Commerce.Shipping.Admin.Profiles
{
	/// <summary>
	/// Use the ShippingStates sub-resource to manage the states your shipping profile supports. For example, you can specify one of your shipping profiles to only support Texas, Oklahoma, Arkansas, Louisiana, and New Mexico.Each shipping state is composed of a user-definied code and name.
	/// </summary>
	public partial class ShippingStatesClient 	{
		
		/// <summary>
		/// Retrieves a list of shipping states and their details.
		/// </summary>
		/// <param name="profileCode">The unique, user-defined code of the profile with which the shipping state is associated.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetStates( profileCode);
		///   var shippingStatesClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates>> GetStatesClient(string profileCode)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.ShippingStatesUrl.GetStatesUrl(profileCode);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates>>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Updates the details of the shipping states.
		/// </summary>
		/// <param name="profilecode">The unique, user-defined code of the profile with which the shipping state is associated.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="states">Mozu.ShippingAdmin.Contracts.Profile.ShippingStates ApiType DOCUMENT_HERE </param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{List{<see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates"/>}}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateStates( states,  profilecode);
		///   var shippingStatesClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<List<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates>> UpdateStatesClient(List<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates> states, string profilecode)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.ShippingStatesUrl.UpdateStatesUrl(profilecode);
			const string verb = "PUT";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates>>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<List<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingStates>>(states);
			return mozuClient;

		}


	}

}


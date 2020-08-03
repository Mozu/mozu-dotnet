
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

namespace Mozu.Api.Clients.Commerce.Settings.Checkout
{
	/// <summary>
	/// Use the Customer Checkout Settings resource to define login settings that apply when shoppers proceed to checkout.
	/// </summary>
	public partial class CustomerCheckoutSettingsClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCustomerCheckoutSettings( responseFields);
		///   var customerCheckoutSettingsClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings> GetCustomerCheckoutSettingsClient(string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Settings.Checkout.CustomerCheckoutSettingsUrl.GetCustomerCheckoutSettingsUrl(responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="customerCheckoutSettings">The properties of the customer checkout settings such as whether shoppers must be logged in.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateCustomerCheckoutSettings( customerCheckoutSettings,  responseFields);
		///   var customerCheckoutSettingsClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings> UpdateCustomerCheckoutSettingsClient(Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings customerCheckoutSettings, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Settings.Checkout.CustomerCheckoutSettingsUrl.UpdateCustomerCheckoutSettingsUrl(responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.SiteSettings.Order.CustomerCheckoutSettings>(customerCheckoutSettings);
			return mozuClient;

		}


	}

}




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

namespace Mozu.Api.Clients.Commerce.Shipping.Admin.Profiles
{
	/// <summary>
	/// Use the OrderHandlingFeeRules sub-resource to manage your order handling fee rules that are associated with a specific shipping profile.
	/// </summary>
	public partial class OrderHandlingFeeRulesClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetOrderHandlingFeeRule( profilecode,  id,  responseFields);
		///   var handlingFeeRuleClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule> GetOrderHandlingFeeRuleClient(string profilecode, string id, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.OrderHandlingFeeRulesUrl.GetOrderHandlingFeeRuleUrl(profilecode, id, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRuleCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetOrderHandlingFeeRules( profilecode,  responseFields);
		///   var handlingFeeRuleCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRuleCollection> GetOrderHandlingFeeRulesClient(string profilecode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.OrderHandlingFeeRulesUrl.GetOrderHandlingFeeRulesUrl(profilecode, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRuleCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="rule">The details of the order handling fee rule.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateOrderHandlingFeeRule( rule,  profilecode,  responseFields);
		///   var handlingFeeRuleClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule> CreateOrderHandlingFeeRuleClient(Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule rule, string profilecode, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.OrderHandlingFeeRulesUrl.CreateOrderHandlingFeeRuleUrl(profilecode, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule>(rule);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="rule">The updated details of the order handling fee rule.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateOrderHandlingFeeRule( rule,  profilecode,  id,  responseFields);
		///   var handlingFeeRuleClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule> UpdateOrderHandlingFeeRuleClient(Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule rule, string profilecode, string id, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.OrderHandlingFeeRulesUrl.UpdateOrderHandlingFeeRuleUrl(profilecode, id, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.ShippingAdmin.Profile.HandlingFeeRule>(rule);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <param name="profilecode">The unique, user-defined code of the profile with which the order handling fee rule is associated.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteOrderHandlingFeeRule( profilecode,  id);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteOrderHandlingFeeRuleClient(string profilecode, string id)
		{
			var url = Mozu.Api.Urls.Commerce.Shipping.Admin.Profiles.OrderHandlingFeeRulesUrl.DeleteOrderHandlingFeeRuleUrl(profilecode, id);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



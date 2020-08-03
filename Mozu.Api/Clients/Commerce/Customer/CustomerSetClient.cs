
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

namespace Mozu.Api.Clients.Commerce.Customer
{
	/// <summary>
	/// Use the Customer Sets resource to manage your customer sets. You can use customer sets to control the specific sites your customers can access using the same login credentials, as well as what customer My Account information is shared between sites.Refer to [Customer Sets](../../../guides/settings/customer-sets.htm) in the Guides section for more information.
	/// </summary>
	public partial class CustomerSetClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerSetCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCustomerSets( startIndex,  pageSize,  sortBy,  responseFields);
		///   var customerSetCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerSetCollection> GetCustomerSetsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerSetUrl.GetCustomerSetsUrl(startIndex, pageSize, sortBy, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerSetCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code that uniqely identifies the channel group.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerSet"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCustomerSet( code,  responseFields);
		///   var customerSetClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerSet> GetCustomerSetClient(string code, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerSetUrl.GetCustomerSetUrl(code, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerSet>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



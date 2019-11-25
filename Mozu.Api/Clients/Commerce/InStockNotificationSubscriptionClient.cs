
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
	/// Use the Customer In-Stock Notification Subscription resource to manage the subscriptions customer accounts use to send product notifications. This resource can send a notification when a product in a catalog returns to a site's active inventory after it is out of stock, or when a new product becomes available for the first time.
	/// </summary>
	public partial class InStockNotificationSubscriptionClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetInStockNotificationSubscriptions( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var inStockNotificationSubscriptionCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection> GetInStockNotificationSubscriptionsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.InStockNotificationSubscriptionUrl.GetInStockNotificationSubscriptionsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.InStockNotificationSubscription"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetInStockNotificationSubscription( id,  responseFields);
		///   var inStockNotificationSubscriptionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> GetInStockNotificationSubscriptionClient(int id, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.InStockNotificationSubscriptionUrl.GetInStockNotificationSubscriptionUrl(id, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="inStockNotificationSubscription">Properties of a push notification to which the shopper subscribes. This notification sends the shopper an alert when a new product or a product previously out of stock becomes available in the specified location's active product inventory.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.InStockNotificationSubscription"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddInStockNotificationSubscription( inStockNotificationSubscription,  responseFields);
		///   var inStockNotificationSubscriptionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> AddInStockNotificationSubscriptionClient(Mozu.Api.Contracts.Customer.InStockNotificationSubscription inStockNotificationSubscription, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.InStockNotificationSubscriptionUrl.AddInStockNotificationSubscriptionUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.InStockNotificationSubscription>(inStockNotificationSubscription);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">Unique identifier of the customer segment to retrieve.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteInStockNotificationSubscription( id);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteInStockNotificationSubscriptionClient(int id)
		{
			var url = Mozu.Api.Urls.Commerce.InStockNotificationSubscriptionUrl.DeleteInStockNotificationSubscriptionUrl(id);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



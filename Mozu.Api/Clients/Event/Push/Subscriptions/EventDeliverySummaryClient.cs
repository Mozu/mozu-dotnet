
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

namespace Mozu.Api.Clients.Event.Push.Subscriptions
{
	/// <summary>
	/// Provides details for each attempted delivery of the event to the endpoint.
	/// </summary>
	public partial class EventDeliverySummaryClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="processId"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="subscriptionId">Unique identifier for a subscription, such as subscribing tenants for an event or to receive a notification.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Event.EventDeliverySummary"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetDeliveryAttemptSummary( subscriptionId,  processId,  responseFields);
		///   var eventDeliverySummaryClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Event.EventDeliverySummary> GetDeliveryAttemptSummaryClient(string subscriptionId, int? processId =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Event.Push.Subscriptions.EventDeliverySummaryUrl.GetDeliveryAttemptSummaryUrl(subscriptionId, processId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Event.EventDeliverySummary>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <param name="subscriptionId">Unique identifier for a subscription, such as subscribing tenants for an event or to receive a notification.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Event.EventDeliverySummaryCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetDeliveryAttemptSummaries( subscriptionId,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var eventDeliverySummaryCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Event.EventDeliverySummaryCollection> GetDeliveryAttemptSummariesClient(string subscriptionId, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Event.Push.Subscriptions.EventDeliverySummaryUrl.GetDeliveryAttemptSummariesUrl(subscriptionId, startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Event.EventDeliverySummaryCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



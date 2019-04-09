
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

namespace Mozu.Api.Resources.Event.Push.Subscriptions
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EventDeliverySummaryResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public EventDeliverySummaryResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public EventDeliverySummaryResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new EventDeliverySummaryResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="processId"></param>
		/// <param name="responseFields"></param>
		/// <param name="subscriptionId">This operation paramenter is the unique identifer for a subscription.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Event.EventDeliverySummary"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var eventdeliverysummary = new EventDeliverySummary();
		///   var eventDeliverySummary = await eventdeliverysummary.GetDeliveryAttemptSummaryAsync( subscriptionId,  processId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Event.EventDeliverySummary> GetDeliveryAttemptSummaryAsync(string subscriptionId, int? processId =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Event.EventDeliverySummary> response;
			var client = Mozu.Api.Clients.Event.Push.Subscriptions.EventDeliverySummaryClient.GetDeliveryAttemptSummaryClient( subscriptionId,  processId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <param name="subscriptionId"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Event.EventDeliverySummaryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var eventdeliverysummary = new EventDeliverySummary();
		///   var eventDeliverySummaryCollection = await eventdeliverysummary.GetDeliveryAttemptSummariesAsync( subscriptionId,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Event.EventDeliverySummaryCollection> GetDeliveryAttemptSummariesAsync(string subscriptionId, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Event.EventDeliverySummaryCollection> response;
			var client = Mozu.Api.Clients.Event.Push.Subscriptions.EventDeliverySummaryClient.GetDeliveryAttemptSummariesClient( subscriptionId,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



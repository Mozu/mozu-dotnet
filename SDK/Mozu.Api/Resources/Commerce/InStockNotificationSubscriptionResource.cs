
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

namespace Mozu.Api.Resources.Commerce
{
	/// <summary>
	/// Use the Customer In-Stock Notification Subscription resource to manage the subscriptions customer accounts use to send product notifications. This resource can send a notification when a product in a catalog returns to a site's active inventory after it is out of stock, or when a new product becomes available for the first time.
	/// </summary>
	public partial class InStockNotificationSubscriptionResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public InStockNotificationSubscriptionResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public InStockNotificationSubscriptionResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new InStockNotificationSubscriptionResource(_apiContext.CloneWith(contextModification));
		}

				
		/// <summary>
		/// Retrieves a list of in-stock notification subscriptions.
		/// </summary>
		/// <param name="filter">A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=IsDisplayed+eq+true"</param>
		/// <param name="pageSize">The number of results to display on each page when creating paged results from a query. The maximum value is 200.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="sortBy">The property by which to sort results and whether the results appear in ascending (a-z) order, represented by ASC or in descending (z-a) order, represented by DESC. The sortBy parameter follows an available property. For example: "sortBy=productCode+asc"</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with a PageSize of 25, to get the 51st through the 75th items, use startIndex=3.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var instocknotificationsubscription = new InStockNotificationSubscription();
		///   var inStockNotificationSubscriptionCollection = instocknotificationsubscription.GetInStockNotificationSubscriptions( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection GetInStockNotificationSubscriptions(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection> response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.GetInStockNotificationSubscriptionsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		public virtual async Task<Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection> GetInStockNotificationSubscriptionsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscriptionCollection> response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.GetInStockNotificationSubscriptionsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves the details of a subscription that sends a push notification when a product is available in a site's active stock.
		/// </summary>
		/// <param name="id">Unique identifier of the in-stock notification subscription to retrieve.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.InStockNotificationSubscription"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var instocknotificationsubscription = new InStockNotificationSubscription();
		///   var inStockNotificationSubscription = instocknotificationsubscription.GetInStockNotificationSubscription( id,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.Customer.InStockNotificationSubscription GetInStockNotificationSubscription(int id, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.GetInStockNotificationSubscriptionClient( id,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		public virtual async Task<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> GetInStockNotificationSubscriptionAsync(int id, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.GetInStockNotificationSubscriptionClient( id,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Creates a new subscription that notifies the customer when the product specified in the request is available in the active inventory of the defined location.
		/// </summary>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="inStockNotificationSubscription">Properties of a subscription that sends the customer a notification when a product is available in a site's active stock.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.InStockNotificationSubscription"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var instocknotificationsubscription = new InStockNotificationSubscription();
		///   var inStockNotificationSubscription = instocknotificationsubscription.AddInStockNotificationSubscription( inStockNotificationSubscription,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.Customer.InStockNotificationSubscription AddInStockNotificationSubscription(Mozu.Api.Contracts.Customer.InStockNotificationSubscription inStockNotificationSubscription, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.AddInStockNotificationSubscriptionClient( inStockNotificationSubscription,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		public virtual async Task<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> AddInStockNotificationSubscriptionAsync(Mozu.Api.Contracts.Customer.InStockNotificationSubscription inStockNotificationSubscription, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.InStockNotificationSubscription> response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.AddInStockNotificationSubscriptionClient( inStockNotificationSubscription,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Deletes a subscription for a customer in-stock notification.
		/// </summary>
		/// <param name="id">Unique identifier of the customer in-stock notification subscription to delete.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var instocknotificationsubscription = new InStockNotificationSubscription();
		///   instocknotificationsubscription.DeleteInStockNotificationSubscription( id);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void DeleteInStockNotificationSubscription(int id)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.DeleteInStockNotificationSubscriptionClient( id);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		public virtual async Task DeleteInStockNotificationSubscriptionAsync(int id)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.InStockNotificationSubscriptionClient.DeleteInStockNotificationSubscriptionClient( id);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}


	}

}



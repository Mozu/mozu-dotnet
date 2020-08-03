
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

namespace Mozu.Api.Resources.Commerce.Customer
{
	/// <summary>
	/// Use the Visits resource to manage all visits a customer makes to a tenant's sites and measure the level of transactions a customer performs during a unique visit for customer account analytics. Clients can track customer visits by site (including online and in-person interactions), the transactions a customer performs during the visit, and the device type associated with the visit, if any.
	/// </summary>
	public partial class VisitResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public VisitResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public VisitResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new VisitResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.VisitCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var visit = new Visit();
		///   var visitCollection = await visit.GetVisitsAsync( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.VisitCollection> GetVisitsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.VisitCollection> response;
			var client = Mozu.Api.Clients.Commerce.Customer.VisitClient.GetVisitsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="visitId">Unique identifier of the customer visit to update.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.Visit"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var visit = new Visit();
		///   var visit = await visit.GetVisitAsync( visitId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.Visit> GetVisitAsync(string visitId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.Visit> response;
			var client = Mozu.Api.Clients.Commerce.Customer.VisitClient.GetVisitClient( visitId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="visit">Properties of a customer visit to one of a company's sites.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.Visit"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var visit = new Visit();
		///   var visit = await visit.AddVisitAsync( visit,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.Visit> AddVisitAsync(Mozu.Api.Contracts.Customer.Visit visit, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.Visit> response;
			var client = Mozu.Api.Clients.Commerce.Customer.VisitClient.AddVisitClient( visit,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="visitId">Unique identifier of the customer visit to update.</param>
		/// <param name="visit">Properties of a customer visit to one of a company's sites.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.Visit"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var visit = new Visit();
		///   var visit = await visit.UpdateVisitAsync( visit,  visitId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.Visit> UpdateVisitAsync(Mozu.Api.Contracts.Customer.Visit visit, string visitId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.Visit> response;
			var client = Mozu.Api.Clients.Commerce.Customer.VisitClient.UpdateVisitClient( visit,  visitId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



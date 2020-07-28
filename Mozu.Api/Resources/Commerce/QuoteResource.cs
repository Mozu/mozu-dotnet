
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

namespace Mozu.Api.Resources.Commerce
{
	/// <summary>
	/// Quotes support the eCommerce B2B feature by providing functionality similar to that of standard wishlists. However, comments can be added to quotes to provide clearer information to other users accessing the quote through the shared B2B account. These basic APIs provide the ability to create new quotes, update them, and retrieve their information.These APIs are currently a work-in-progress and will be enhanced in the future as more functionality such as setting fixed prices, setting expiration, etc. is released. The current models may change and break backwards compatibility, so use caution if interacting with these APIs for now.
	/// </summary>
	public partial class QuoteResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public QuoteResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public QuoteResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new QuoteResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="q">A list of order search terms (not phrases) to use in the query when searching across order number and the name or email of the billing contact. When entering, separate multiple search terms with a space character.</param>
		/// <param name="qLimit">The maximum number of search results to return in the response. You can limit any range between 1-100.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Quotes.QuoteCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var quote = new Quote();
		///   var quoteCollection = await quote.GetQuotesAsync( startIndex,  pageSize,  sortBy,  filter,  q,  qLimit,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Quotes.QuoteCollection> GetQuotesAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string q =  null, int? qLimit =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Quotes.QuoteCollection> response;
			var client = Mozu.Api.Clients.Commerce.QuoteClient.GetQuotesClient( startIndex,  pageSize,  sortBy,  filter,  q,  qLimit,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="quoteId">A unique identifier for the quote.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var quote = new Quote();
		///   var quote = await quote.GetQuoteAsync( quoteId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> GetQuoteAsync(string quoteId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> response;
			var client = Mozu.Api.Clients.Commerce.QuoteClient.GetQuoteClient( quoteId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="customerAccountId">The unique identifier of the customer account for which to retrieve wish lists.</param>
		/// <param name="quoteName">A unique name for the quote.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var quote = new Quote();
		///   var quote = await quote.GetQuoteByNameAsync( customerAccountId,  quoteName,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> GetQuoteByNameAsync(int customerAccountId, string quoteName, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> response;
			var client = Mozu.Api.Clients.Commerce.QuoteClient.GetQuoteByNameClient( customerAccountId,  quoteName,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="quote">The quote being created.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var quote = new Quote();
		///   var quote = await quote.CreateQuoteAsync( quote,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> CreateQuoteAsync(Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote quote, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> response;
			var client = Mozu.Api.Clients.Commerce.QuoteClient.CreateQuoteClient( quote,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="quoteId">A unique identifier for the quote being updated.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="quote">The quote that is being updated.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var quote = new Quote();
		///   var quote = await quote.UpdateQuoteAsync( quote,  quoteId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> UpdateQuoteAsync(Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote quote, string quoteId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Quotes.Quote> response;
			var client = Mozu.Api.Clients.Commerce.QuoteClient.UpdateQuoteClient( quote,  quoteId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="quoteId">A unique identifier for the quote.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var quote = new Quote();
		///   var stream = await quote.DeleteQuoteAsync( quoteId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteQuoteAsync(string quoteId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.QuoteClient.DeleteQuoteClient( quoteId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



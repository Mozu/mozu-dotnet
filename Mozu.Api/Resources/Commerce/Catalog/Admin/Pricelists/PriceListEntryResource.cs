
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin.Pricelists
{
	/// <summary>
	/// 
	/// </summary>
	public partial class PriceListEntryResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public PriceListEntryResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public PriceListEntryResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new PriceListEntryResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="priceListCode"></param>
		/// <param name="productCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="startDate"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.PriceListEntry"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var pricelistentry = new PriceListEntry();
		///   var priceListEntry = await pricelistentry.GetPriceListEntryAsync( priceListCode,  productCode,  currencyCode,  startDate,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.PriceListEntry> GetPriceListEntryAsync(string priceListCode, string productCode, string currencyCode, DateTime? startDate =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceListEntry> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Pricelists.PriceListEntryClient.GetPriceListEntryClient( priceListCode,  productCode,  currencyCode,  startDate,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="priceListCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.PriceListEntryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var pricelistentry = new PriceListEntry();
		///   var priceListEntryCollection = await pricelistentry.GetPriceListEntriesAsync( priceListCode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.PriceListEntryCollection> GetPriceListEntriesAsync(string priceListCode, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceListEntryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Pricelists.PriceListEntryClient.GetPriceListEntriesClient( priceListCode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="priceListCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="priceListEntryIn"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.PriceListEntry"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var pricelistentry = new PriceListEntry();
		///   var priceListEntry = await pricelistentry.AddPriceListEntryAsync( priceListEntryIn,  priceListCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.PriceListEntry> AddPriceListEntryAsync(Mozu.Api.Contracts.ProductAdmin.PriceListEntry priceListEntryIn, string priceListCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceListEntry> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Pricelists.PriceListEntryClient.AddPriceListEntryClient( priceListEntryIn,  priceListCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="priceListCode"></param>
		/// <param name="productCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="startDate"></param>
		/// <param name="priceListEntryIn"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.PriceListEntry"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var pricelistentry = new PriceListEntry();
		///   var priceListEntry = await pricelistentry.UpdatePriceListEntryAsync( priceListEntryIn,  priceListCode,  productCode,  currencyCode,  startDate,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.PriceListEntry> UpdatePriceListEntryAsync(Mozu.Api.Contracts.ProductAdmin.PriceListEntry priceListEntryIn, string priceListCode, string productCode, string currencyCode, DateTime? startDate =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.PriceListEntry> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Pricelists.PriceListEntryClient.UpdatePriceListEntryClient( priceListEntryIn,  priceListCode,  productCode,  currencyCode,  startDate,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="priceListCode"></param>
		/// <param name="productCode"></param>
		/// <param name="startDate"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var pricelistentry = new PriceListEntry();
		///   await pricelistentry.DeletePriceListEntryAsync( priceListCode,  productCode,  currencyCode,  startDate);
		/// </code>
		/// </example>
		public virtual async Task DeletePriceListEntryAsync(string priceListCode, string productCode, string currencyCode, DateTime? startDate =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.Pricelists.PriceListEntryClient.DeletePriceListEntryClient( priceListCode,  productCode,  currencyCode,  startDate);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



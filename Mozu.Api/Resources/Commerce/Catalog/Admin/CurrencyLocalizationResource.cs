
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CurrencyLocalizationResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CurrencyLocalizationResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CurrencyLocalizationResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CurrencyLocalizationResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CurrencyLocalizationCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   var currencyLocalizationCollection = await currencylocalization.GetCurrencyLocalizationsAsync( responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalizationCollection> GetCurrencyLocalizationsAsync(string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalizationCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.GetCurrencyLocalizationsClient( responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="toCurrencyCode"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRate"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   var currencyExchangeRate = await currencylocalization.GetCurrencyExchangeRateAsync( currencyCode,  toCurrencyCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRate> GetCurrencyExchangeRateAsync(string currencyCode, string toCurrencyCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRate> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.GetCurrencyExchangeRateClient( currencyCode,  toCurrencyCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRateCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   var currencyExchangeRateCollection = await currencylocalization.GetCurrencyExchangeRatesAsync( currencyCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRateCollection> GetCurrencyExchangeRatesAsync(string currencyCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRateCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.GetCurrencyExchangeRatesClient( currencyCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="responseFields"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   var currencyLocalization = await currencylocalization.GetCurrencyLocalizationAsync( currencyCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization> GetCurrencyLocalizationAsync(string currencyCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.GetCurrencyLocalizationClient( currencyCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="currencyLocalization"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   var currencyLocalization = await currencylocalization.AddCurrencyLocalizationAsync( currencyLocalization,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization> AddCurrencyLocalizationAsync(Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization currencyLocalization, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.AddCurrencyLocalizationClient( currencyLocalization,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="currencyExchangeRates"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   await currencylocalization.AddCurrencyExchangeRatesAsync( currencyExchangeRates,  currencyCode);
		/// </code>
		/// </example>
		public virtual async Task AddCurrencyExchangeRatesAsync(List<Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRate> currencyExchangeRates, string currencyCode, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.AddCurrencyExchangeRatesClient( currencyExchangeRates,  currencyCode);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="currencyExchangeRates"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   await currencylocalization.UpdateCurrencyExchangeRatesAsync( currencyExchangeRates,  currencyCode);
		/// </code>
		/// </example>
		public virtual async Task UpdateCurrencyExchangeRatesAsync(List<Mozu.Api.Contracts.ProductAdmin.CurrencyExchangeRate> currencyExchangeRates, string currencyCode, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.UpdateCurrencyExchangeRatesClient( currencyExchangeRates,  currencyCode);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="responseFields"></param>
		/// <param name="currencyLocalization"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   var currencyLocalization = await currencylocalization.UpdateCurrencyLocalizationAsync( currencyLocalization,  currencyCode,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization> UpdateCurrencyLocalizationAsync(Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization currencyLocalization, string currencyCode, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CurrencyLocalization> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.UpdateCurrencyLocalizationClient( currencyLocalization,  currencyCode,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   await currencylocalization.DeleteCurrencyLocalizationAsync( currencyCode);
		/// </code>
		/// </example>
		public virtual async Task DeleteCurrencyLocalizationAsync(string currencyCode, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.DeleteCurrencyLocalizationClient( currencyCode);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currencyCode"></param>
		/// <param name="toCurrencyCode"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var currencylocalization = new CurrencyLocalization();
		///   await currencylocalization.DeleteCurrencyExchangeRateAsync( currencyCode,  toCurrencyCode);
		/// </code>
		/// </example>
		public virtual async Task DeleteCurrencyExchangeRateAsync(string currencyCode, string toCurrencyCode, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CurrencyLocalizationClient.DeleteCurrencyExchangeRateClient( currencyCode,  toCurrencyCode);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



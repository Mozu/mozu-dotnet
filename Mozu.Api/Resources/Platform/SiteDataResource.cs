
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

namespace Mozu.Api.Resources.Platform
{
	/// <summary>
	/// Use the site data resource to store site-level information required for a third-party application in the  database.
	/// </summary>
	public partial class SiteDataResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public SiteDataResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public SiteDataResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new SiteDataResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// string
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   var string = await sitedata.GetDBValueAsync( dbEntryQuery,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<string> GetDBValueAsync(string dbEntryQuery, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<string> response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.GetDBValueClient( dbEntryQuery,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   var stream = await sitedata.CreateDBValueAsync( value,  dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> CreateDBValueAsync(string value, string dbEntryQuery, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.CreateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   var stream = await sitedata.UpdateDBValueAsync( value,  dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> UpdateDBValueAsync(string value, string dbEntryQuery, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.UpdateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   var stream = await sitedata.DeleteDBValueAsync( dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteDBValueAsync(string dbEntryQuery, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.DeleteDBValueClient( dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



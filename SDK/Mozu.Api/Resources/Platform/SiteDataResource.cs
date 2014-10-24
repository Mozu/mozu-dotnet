
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

namespace Mozu.Api.Resources.Platform
{
	/// <summary>
	/// Use the site data resource to store site-level information required for a third-party application in the Mozu database.
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
		/// Retrieves the value of a record in the Mozu database.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry query string used to retrieve the record information.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// string
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   var string = sitedata.GetDBValue( dbEntryQuery,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual string GetDBValue(string dbEntryQuery, string responseFields =  null)
		{
			MozuClient<string> response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.GetDBValueClient( dbEntryQuery,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves the value of a record in the Mozu database.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry query string used to retrieve the record information.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// string
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   var string = await sitedata.GetDBValueAsync( dbEntryQuery,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<string> GetDBValueAsync(string dbEntryQuery, string responseFields =  null)
		{
			MozuClient<string> response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.GetDBValueClient( dbEntryQuery,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Creates a new record in the Mozu database based on the information supplied in the request.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   sitedata.CreateDBValue( value,  dbEntryQuery);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void CreateDBValue(string value, string dbEntryQuery)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.CreateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		/// <summary>
		/// Creates a new record in the Mozu database based on the information supplied in the request.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   await sitedata.CreateDBValueAsync( value,  dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task CreateDBValueAsync(string value, string dbEntryQuery)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.CreateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}

		/// <summary>
		/// Updates a record in the Mozu database based on the information supplied in the request.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry query string used to update the record information.</param>
		/// <param name="value">The database value to update.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   sitedata.UpdateDBValue( value,  dbEntryQuery);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void UpdateDBValue(string value, string dbEntryQuery)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.UpdateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		/// <summary>
		/// Updates a record in the Mozu database based on the information supplied in the request.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry query string used to update the record information.</param>
		/// <param name="value">The database value to update.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   await sitedata.UpdateDBValueAsync( value,  dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task UpdateDBValueAsync(string value, string dbEntryQuery)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.UpdateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}

		/// <summary>
		/// Removes a previously defined record in the Mozu database.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to delete.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   sitedata.DeleteDBValue( dbEntryQuery);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void DeleteDBValue(string dbEntryQuery)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.DeleteDBValueClient( dbEntryQuery);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		/// <summary>
		/// Removes a previously defined record in the Mozu database.
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to delete.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var sitedata = new SiteData();
		///   await sitedata.DeleteDBValueAsync( dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task DeleteDBValueAsync(string dbEntryQuery)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.SiteDataClient.DeleteDBValueClient( dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}


	}

}



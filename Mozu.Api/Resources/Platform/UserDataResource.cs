
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
	/// Use the user data subresource to store user-level data required for a third-party application in the  database.
	/// </summary>
	public partial class UserDataResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public UserDataResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public UserDataResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new UserDataResource(_apiContext.CloneWith(contextModification));
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
		///   var userdata = new UserData();
		///   var string = await userdata.GetDBValueAsync( dbEntryQuery,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<string> GetDBValueAsync(string dbEntryQuery, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<string> response;
			var client = Mozu.Api.Clients.Platform.UserDataClient.GetDBValueClient( dbEntryQuery,  responseFields);
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
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var userdata = new UserData();
		///   await userdata.CreateDBValueAsync( value,  dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task CreateDBValueAsync(string value, string dbEntryQuery, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.UserDataClient.CreateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var userdata = new UserData();
		///   await userdata.UpdateDBValueAsync( value,  dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task UpdateDBValueAsync(string value, string dbEntryQuery, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.UserDataClient.UpdateDBValueClient( value,  dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var userdata = new UserData();
		///   await userdata.DeleteDBValueAsync( dbEntryQuery);
		/// </code>
		/// </example>
		public virtual async Task DeleteDBValueAsync(string dbEntryQuery, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.UserDataClient.DeleteDBValueClient( dbEntryQuery);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



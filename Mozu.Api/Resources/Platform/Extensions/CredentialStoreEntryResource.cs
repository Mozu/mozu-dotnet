
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

namespace Mozu.Api.Resources.Platform.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public partial class CredentialStoreEntryResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CredentialStoreEntryResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CredentialStoreEntryResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CredentialStoreEntryResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="credentials"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var credentialstoreentry = new CredentialStoreEntry();
		///   await credentialstoreentry.StoreCredentialsAsync( credentials);
		/// </code>
		/// </example>
		public virtual async Task StoreCredentialsAsync(Mozu.Api.Contracts.InstalledApplications.CredentialStoreEntry credentials, CancellationToken ct = default(CancellationToken))
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Platform.Extensions.CredentialStoreEntryClient.StoreCredentialsClient( credentials);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);

		}


	}

}



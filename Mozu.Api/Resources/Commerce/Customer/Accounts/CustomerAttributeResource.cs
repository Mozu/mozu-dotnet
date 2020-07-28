
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

namespace Mozu.Api.Resources.Commerce.Customer.Accounts
{
	/// <summary>
	/// Use the Attributes subresource to manage the attributes used to uniquely identify shopper accounts, such as gender or age.
	/// </summary>
	public partial class CustomerAttributeResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CustomerAttributeResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CustomerAttributeResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CustomerAttributeResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAttribute"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerattribute = new CustomerAttribute();
		///   var customerAttribute = await customerattribute.GetAccountAttributeAsync( accountId,  attributeFQN,  userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAttribute> GetAccountAttributeAsync(int accountId, string attributeFQN, string userId =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAttribute> response;
			var client = Mozu.Api.Clients.Commerce.Customer.Accounts.CustomerAttributeClient.GetAccountAttributeClient( accountId,  attributeFQN,  userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="sortBy">The element to sort the results by and the channel in which the results appear. Either ascending (a-z) or descending (z-a) channel. Optional. Refer to [Sorting and Filtering](../../../../Developer/api-guides/sorting-filtering.htm) for more information.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAttributeCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerattribute = new CustomerAttribute();
		///   var customerAttributeCollection = await customerattribute.GetAccountAttributesAsync( accountId,  startIndex,  pageSize,  sortBy,  filter,  userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAttributeCollection> GetAccountAttributesAsync(int accountId, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string userId =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAttributeCollection> response;
			var client = Mozu.Api.Clients.Commerce.Customer.Accounts.CustomerAttributeClient.GetAccountAttributesClient( accountId,  startIndex,  pageSize,  sortBy,  filter,  userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <param name="attribute">Properties of an attribute associated with a customer account.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAttribute"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerattribute = new CustomerAttribute();
		///   var customerAttribute = await customerattribute.AddAccountAttributeAsync( attribute,  accountId,  userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAttribute> AddAccountAttributeAsync(Mozu.Api.Contracts.Customer.CustomerAttribute attribute, int accountId, string userId =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAttribute> response;
			var client = Mozu.Api.Clients.Commerce.Customer.Accounts.CustomerAttributeClient.AddAccountAttributeClient( attribute,  accountId,  userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <param name="attribute">Properties of an attribute associated with a customer account.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAttribute"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerattribute = new CustomerAttribute();
		///   var customerAttribute = await customerattribute.UpdateAccountAttributeAsync( attribute,  accountId,  attributeFQN,  userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAttribute> UpdateAccountAttributeAsync(Mozu.Api.Contracts.Customer.CustomerAttribute attribute, int accountId, string attributeFQN, string userId =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAttribute> response;
			var client = Mozu.Api.Clients.Commerce.Customer.Accounts.CustomerAttributeClient.UpdateAccountAttributeClient( attribute,  accountId,  attributeFQN,  userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="attributeFQN">Fully qualified name for an attribute.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerattribute = new CustomerAttribute();
		///   var stream = await customerattribute.DeleteAccountAttributeAsync( accountId,  attributeFQN,  userId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteAccountAttributeAsync(int accountId, string attributeFQN, string userId =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Customer.Accounts.CustomerAttributeClient.DeleteAccountAttributeClient( accountId,  attributeFQN,  userId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



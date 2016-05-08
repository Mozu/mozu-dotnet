
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

namespace Mozu.Api.Resources.Commerce.Customer
{
	/// <summary>
	/// Use the Customer Authentication Tickets resource to generate and refresh authentication tickets for customer accounts.
	/// </summary>
	public partial class CustomerAuthTicketResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CustomerAuthTicketResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CustomerAuthTicketResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CustomerAuthTicketResource(_apiContext.CloneWith(contextModification));
		}

				
		/// <summary>
		/// Creates an authentication ticket for an anonymous shopper user.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. For example, ) returns only the  and  items inside the  array of the specified product.This paramter should only be used to retrieve data. Attempting to update data using this parmater may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerauthticket = new CustomerAuthTicket();
		///   var customerAuthTicket = customerauthticket.CreateAnonymousShopperAuthTicket( responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.Customer.CustomerAuthTicket CreateAnonymousShopperAuthTicket(string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> response;
			var client = Mozu.Api.Clients.Commerce.Customer.CustomerAuthTicketClient.CreateAnonymousShopperAuthTicketClient( responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Creates an authentication ticket for an anonymous shopper user.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. For example, ) returns only the  and  items inside the  array of the specified product.This paramter should only be used to retrieve data. Attempting to update data using this parmater may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerauthticket = new CustomerAuthTicket();
		///   var customerAuthTicket = await customerauthticket.CreateAnonymousShopperAuthTicketAsync( responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAuthTicket> CreateAnonymousShopperAuthTicketAsync(string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> response;
			var client = Mozu.Api.Clients.Commerce.Customer.CustomerAuthTicketClient.CreateAnonymousShopperAuthTicketClient( responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Generates a new authentication ticket for a customer account.
		/// </summary>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="userAuthInfo">The authentication information required to generate an authentication ticket for a customer account.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerauthticket = new CustomerAuthTicket();
		///   var customerAuthTicket = customerauthticket.CreateUserAuthTicket( userAuthInfo,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.Customer.CustomerAuthTicket CreateUserAuthTicket(Mozu.Api.Contracts.Customer.CustomerUserAuthInfo userAuthInfo, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> response;
			var client = Mozu.Api.Clients.Commerce.Customer.CustomerAuthTicketClient.CreateUserAuthTicketClient( userAuthInfo,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Generates a new authentication ticket for a customer account.
		/// </summary>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="userAuthInfo">The authentication information required to generate an authentication ticket for a customer account.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerauthticket = new CustomerAuthTicket();
		///   var customerAuthTicket = await customerauthticket.CreateUserAuthTicketAsync( userAuthInfo,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAuthTicket> CreateUserAuthTicketAsync(Mozu.Api.Contracts.Customer.CustomerUserAuthInfo userAuthInfo, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> response;
			var client = Mozu.Api.Clients.Commerce.Customer.CustomerAuthTicketClient.CreateUserAuthTicketClient( userAuthInfo,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Refreshes an existing authentication ticket for a customer account by providing the refresh token string.
		/// </summary>
		/// <param name="refreshToken">Alphanumeric string used for access tokens. This token refreshes access for accounts by generating a new developer or application account authentication ticket after an access token expires.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerauthticket = new CustomerAuthTicket();
		///   var customerAuthTicket = customerauthticket.RefreshUserAuthTicket( refreshToken,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.Customer.CustomerAuthTicket RefreshUserAuthTicket(string refreshToken, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> response;
			var client = Mozu.Api.Clients.Commerce.Customer.CustomerAuthTicketClient.RefreshUserAuthTicketClient( refreshToken,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Refreshes an existing authentication ticket for a customer account by providing the refresh token string.
		/// </summary>
		/// <param name="refreshToken">Alphanumeric string used for access tokens. This token refreshes access for accounts by generating a new developer or application account authentication ticket after an access token expires.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customerauthticket = new CustomerAuthTicket();
		///   var customerAuthTicket = await customerauthticket.RefreshUserAuthTicketAsync( refreshToken,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Customer.CustomerAuthTicket> RefreshUserAuthTicketAsync(string refreshToken, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> response;
			var client = Mozu.Api.Clients.Commerce.Customer.CustomerAuthTicketClient.RefreshUserAuthTicketClient( refreshToken,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}


	}

}



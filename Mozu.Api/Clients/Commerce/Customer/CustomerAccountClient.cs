
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

namespace Mozu.Api.Clients.Commerce.Customer
{
	/// <summary>
	/// Use the Customer Accounts resource to manage the components of shopper accounts, including attributes, contact information, company notes, and groups associated with the customer account.
	/// </summary>
	public partial class CustomerAccountClient 	{
		
		/// <summary>
		/// Retrieves a list of customer accounts.
		/// </summary>
		/// <param name="fields">The fields to include in the response.</param>
		/// <param name="filter">A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=IsDisplayed+eq+true"</param>
		/// <param name="isAnonymous">If true, retrieve anonymous shopper accounts in the response.</param>
		/// <param name="pageSize"></param>
		/// <param name="q">A list of order search terms (not phrases) to use in the query when searching across order number and the name or email of the billing contact. When entering, separate multiple search terms with a space character.</param>
		/// <param name="qLimit">The maximum number of search results to return in the response. You can limit any range between 1-100.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAccountCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAccounts( startIndex,  pageSize,  sortBy,  filter,  fields,  q,  qLimit,  isAnonymous,  responseFields);
		///   var customerAccountCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAccountCollection> GetAccountsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string fields =  null, string q =  null, int? qLimit =  null, bool? isAnonymous =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.GetAccountsUrl(startIndex, pageSize, sortBy, filter, fields, q, qLimit, isAnonymous, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAccountCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Retrieves the current login state of the customer account specified in the request.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.LoginState"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLoginState( accountId,  responseFields);
		///   var loginStateClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.LoginState> GetLoginStateClient(int accountId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.GetLoginStateUrl(accountId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.LoginState>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Retrieve details of a customer account.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAccount"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetAccount( accountId,  responseFields);
		///   var customerAccountClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAccount> GetAccountClient(int accountId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.GetAccountUrl(accountId, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAccount>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Creates a new customer account based on the information specified in the request.
		/// </summary>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="account">Properties of the customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAccount"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddAccount( account,  responseFields);
		///   var customerAccountClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAccount> AddAccountClient(Mozu.Api.Contracts.Customer.CustomerAccount account, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.AddAccountUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAccount>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.CustomerAccount>(account);
			return mozuClient;

		}

		/// <summary>
		/// Modify the password associated with a customer account.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="unlockAccount"></param>
		/// <param name="passwordInfo">The information required to modify a shopper account password.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ChangePassword( passwordInfo,  accountId,  unlockAccount);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient ChangePasswordClient(Mozu.Api.Contracts.Customer.PasswordInfo passwordInfo, int accountId, bool? unlockAccount =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.ChangePasswordUrl(accountId, unlockAccount);
			const string verb = "POST";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.PasswordInfo>(passwordInfo);
			return mozuClient;

		}

		/// <summary>
		/// Adds a new user login to a defined customer account.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="customerAuthInfo">The login information for a customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddLoginToExistingCustomer( customerAuthInfo,  accountId,  responseFields);
		///   var customerAuthTicketClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> AddLoginToExistingCustomerClient(Mozu.Api.Contracts.Customer.CustomerLoginInfo customerAuthInfo, int accountId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.AddLoginToExistingCustomerUrl(accountId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.CustomerLoginInfo>(customerAuthInfo);
			return mozuClient;

		}

		/// <summary>
		/// Updates the customer lifetime value of the specified customer account in the event of an order import or a lifetime value calculation error.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RecomputeCustomerLifetimeValue( accountId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient RecomputeCustomerLifetimeValueClient(int accountId)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.RecomputeCustomerLifetimeValueUrl(accountId);
			const string verb = "POST";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Lock or unlock a customer account.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="isLocked">If true, the customer account is locked from logging in.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=SetLoginLocked( isLocked,  accountId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient SetLoginLockedClient(bool isLocked, int accountId)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.SetLoginLockedUrl(accountId);
			const string verb = "POST";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(isLocked);
			return mozuClient;

		}

		/// <summary>
		/// Requires the password for the customer account to be changed.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="isPasswordChangeRequired">If true, the password for the customer account must be changed.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=SetPasswordChangeRequired( isPasswordChangeRequired,  accountId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient SetPasswordChangeRequiredClient(bool isPasswordChangeRequired, int accountId)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.SetPasswordChangeRequiredUrl(accountId);
			const string verb = "POST";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(isPasswordChangeRequired);
			return mozuClient;

		}

		/// <summary>
		/// Creates a new customer account and logs the user associated with the customer account into the site.
		/// </summary>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="accountAndAuthInfo">The authentication information associated with a customer account. The data includes the account properties such as the name, username, authorization access, and email address, the required password to match, and indicates if the account was imported from a third party resource. </param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAuthTicket"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddAccountAndLogin( accountAndAuthInfo,  responseFields);
		///   var customerAuthTicketClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket> AddAccountAndLoginClient(Mozu.Api.Contracts.Customer.CustomerAccountAndAuthInfo accountAndAuthInfo, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.AddAccountAndLoginUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAuthTicket>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.CustomerAccountAndAuthInfo>(accountAndAuthInfo);
			return mozuClient;

		}

		/// <summary>
		/// Creates multiple customer accounts based on the information specified in the request.
		/// </summary>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="customers">The authentication information associated with a customer account. The data includes the account properties such as the name, username, authorization access, and email address, the required password to match, and indicates if the account was imported from a third party resource. </param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAccountCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddAccounts( customers,  responseFields);
		///   var customerAccountCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAccountCollection> AddAccountsClient(List<Mozu.Api.Contracts.Customer.CustomerAccountAndAuthInfo> customers, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.AddAccountsUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAccountCollection>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<List<Mozu.Api.Contracts.Customer.CustomerAccountAndAuthInfo>>(customers);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="accountPasswordInfos"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.ChangePasswordResultCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ChangePasswords( accountPasswordInfos,  responseFields);
		///   var changePasswordResultCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.ChangePasswordResultCollection> ChangePasswordsClient(Mozu.Api.Contracts.Customer.AccountPasswordInfoCollection accountPasswordInfos, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.ChangePasswordsUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.ChangePasswordResultCollection>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.AccountPasswordInfoCollection>(accountPasswordInfos);
			return mozuClient;

		}

		/// <summary>
		/// Retrieves the current login state of a customer account by providing the customer's email address.
		/// </summary>
		/// <param name="customerSetCode"></param>
		/// <param name="emailAddress">The email address associated with the customer account.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.LoginState"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLoginStateByEmailAddress( emailAddress,  customerSetCode,  responseFields);
		///   var loginStateClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.LoginState> GetLoginStateByEmailAddressClient(string emailAddress, string customerSetCode =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.GetLoginStateByEmailAddressUrl(emailAddress, customerSetCode, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.LoginState>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Retrieves the current login state of a customer account by providing the user name associated with the customer account.
		/// </summary>
		/// <param name="customerSetCode"></param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="userName">The user name associated with the customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.LoginState"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetLoginStateByUserName( userName,  customerSetCode,  responseFields);
		///   var loginStateClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.LoginState> GetLoginStateByUserNameClient(string userName, string customerSetCode =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.GetLoginStateByUserNameUrl(userName, customerSetCode, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.LoginState>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerPurchaseOrderAccountCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCustomersPurchaseOrderAccounts( startIndex,  pageSize,  sortBy,  responseFields);
		///   var customerPurchaseOrderAccountCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerPurchaseOrderAccountCollection> GetCustomersPurchaseOrderAccountsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.GetCustomersPurchaseOrderAccountsUrl(startIndex, pageSize, sortBy, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerPurchaseOrderAccountCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Resets the password for a customer account.
		/// </summary>
		/// <param name="resetPasswordInfo">Information required to reset the password for a customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ResetPassword( resetPasswordInfo);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient ResetPasswordClient(Mozu.Api.Contracts.Customer.ResetPasswordInfo resetPasswordInfo)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.ResetPasswordUrl();
			const string verb = "POST";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.ResetPasswordInfo>(resetPasswordInfo);
			return mozuClient;

		}

		/// <summary>
		/// Updates a customer account.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="account">Properties of the customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.CustomerAccount"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateAccount( account,  accountId,  responseFields);
		///   var customerAccountClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.CustomerAccount> UpdateAccountClient(Mozu.Api.Contracts.Customer.CustomerAccount account, int accountId, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.UpdateAccountUrl(accountId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.CustomerAccount>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.CustomerAccount>(account);
			return mozuClient;

		}

		/// <summary>
		/// Deletes a customer account. A customer account cannot be deleted if any orders exist, past or present.
		/// </summary>
		/// <param name="accountId">Unique identifier of the customer account.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteAccount( accountId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteAccountClient(int accountId)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CustomerAccountUrl.DeleteAccountUrl(accountId);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}



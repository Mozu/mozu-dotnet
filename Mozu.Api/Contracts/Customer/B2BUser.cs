
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

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.Customer
{
		///
		///	A user login that can access a shared B2B account.
		///
		public class B2BUser
		{
			///
			///Indicates if the customer account is opted to receive marketing materials. If true, the customer account is opted in for receiving the content.
			///
			public bool AcceptsMarketing { get; set; }

			///
			///The email address for the customer account and contact. This email may be used for login to the storefront and for subscription mailing lists.
			///
			public string EmailAddress { get; set; }

			///
			///The full first name of a customer or contact name.
			///
			public string FirstName { get; set; }

			///
			///Indicates if an external password is set on this account.
			///
			public bool HasExternalPassword { get; set; }

			///
			///Indicates if the object or feature is active.
			///
			public bool IsActive { get; set; }

			///
			///Indicates if a customer account and associated data is locked. If true, the user account is locked due to multiple failed authentication attempts. The user cannot login until the account is unlocked.
			///
			public bool IsLocked { get; set; }

			///
			///Indicates whether the customer has been removed or not from the available users list.
			///
			public bool IsRemoved { get; set; }

			///
			///The full last name of a customer or contact name.
			///
			public string LastName { get; set; }

			///
			///The two character locale code, per the country code provided. This code determines the localized content to use and display.
			///
			public string LocaleCode { get; set; }

			///
			///roles ApiType DOCUMENT_HERE 
			///
			public List<UserRole> Roles { get; set; }

			///
			///Unique identifier of the customer account (shopper or system user). System-supplied and read-only. If the shopper user is anonymous, the user ID represents a system-generated user ID string.
			///
			public string UserId { get; set; }

			///
			///The user name associated with the user profile. The customer uses the user name to access the account.
			///
			public string UserName { get; set; }

		}

}

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
		///	Properties of the customer account.
		///
		public class CustomerAccount
		{
			public bool AcceptsMarketing { get; set; }

			///
			///The type of the customer account.
			///
			public string AccountType { get; set; }

			public List<CustomerAttribute> Attributes { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public CommerceSummary CommerceSummary { get; set; }

			public string CompanyOrOrganization { get; set; }

			public List<CustomerContact> Contacts { get; set; }

			///
			///customerSet ApiType DOCUMENT_HERE 
			///
			public string CustomerSet { get; set; }

			///
			///This property tracks the customer account creation date. This date can be set manually via the APIÂ for customer accounts that are imported into . 
			///
			public DateTime? CustomerSinceDate { get; set; }

			///
			///The email address for the customer account and contact. This email may be used for login to the storefront and for subscription mailing lists.
			///
			public string EmailAddress { get; set; }

			///
			///Unique identifier used by an external program to identify a  order, customer account, or wish list.
			///
			public string ExternalId { get; set; }

			///
			///The full first name of a customer or contact name.
			///
			public string FirstName { get; set; }

			///
			///Indicates if an external password is set on this account.
			///
			public bool HasExternalPassword { get; set; }

			public int Id { get; set; }

			///
			///Indicates if the object or feature is active.
			///
			public bool IsActive { get; set; }

			///
			///If true, this customer account represents an anonymous shopper.
			///
			public bool IsAnonymous { get; set; }

			///
			///Indicates if a customer account and associated data is locked. If true, the user account is locked due to multiple failed authentication attempts. The user cannot login until the account is unlocked.
			///
			public bool IsLocked { get; set; }

			///
			///The full last name of a customer or contact name.
			///
			public string LastName { get; set; }

			///
			///Language used for the entity. Currently, only "en-US" is supported.
			///
			public string LocaleCode { get; set; }

			public List<CustomerNote> Notes { get; set; }

			///
			///List of customer segments associated with the customer account. Customer accounts can be members of any number of segments.
			///
			public List<CustomerSegment> Segments { get; set; }

			public bool TaxExempt { get; set; }

			public string TaxId { get; set; }

			public string UserId { get; set; }

			///
			///The user name associated with the user profile. The customer uses the user name to access the account.
			///
			public string UserName { get; set; }

		}

}
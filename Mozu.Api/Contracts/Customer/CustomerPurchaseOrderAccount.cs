
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
		public class CustomerPurchaseOrderAccount
		{
			public int AccountId { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public decimal AvailableBalance { get; set; }

			public decimal CreditLimit { get; set; }

			public List<CustomerPurchaseOrderPaymentTerm> CustomerPurchaseOrderPaymentTerms { get; set; }

			public int Id { get; set; }

			public bool IsEnabled { get; set; }

			public decimal? OverdraftAllowance { get; set; }

			public string OverdraftAllowanceType { get; set; }

			public decimal TotalAvailableBalance { get; set; }

		}

}
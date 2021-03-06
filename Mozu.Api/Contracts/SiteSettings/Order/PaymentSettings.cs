
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

namespace Mozu.Api.Contracts.SiteSettings.Order
{
		///
		///	Properties of the payment settings used at order checkout time for the site.
		///
		public class PaymentSettings
		{
			public AuditInfo AuditInfo { get; set; }

			public List<ExternalPaymentWorkflowDefinition> ExternalPaymentWorkflowDefinitions { get; set; }

			public List<Gateway> Gateways { get; set; }

			public JobSettings JobSettings { get; set; }

			public bool PayByMail { get; set; }

			public string PaymentRanking { get; set; }

			///
			///The purchase order payment type settings associated with a site.Refer to [Enable the Purchase Order Payment Type](https://www.mozu.com/docs/guides/orders/purchase-order.htm#enable_the_purchase_order_payment_type) in the Purchase Orders guides topic for more information.
			///
			public PurchaseOrderPaymentDefinition PurchaseOrder { get; set; }

		}

}
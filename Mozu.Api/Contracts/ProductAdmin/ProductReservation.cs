
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.ProductAdmin
{
		///
		///	A hold placed on product inventory for a particular product so that the quantity specified is set aside and available for purchase during the ordering process.
		///
		public class ProductReservation
		{
			public AuditInfo AuditInfo { get; set; }

			public int? Id { get; set; }

			public string LocationCode { get; set; }

			public string OrderId { get; set; }

			public string OrderItemId { get; set; }

			public string ProductCode { get; set; }

			public int Quantity { get; set; }

		}

}
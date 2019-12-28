
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

namespace Mozu.Api.Contracts.ProductAdmin
{
		public class PriceListEntry
		{
			public AuditInfo AuditInfo { get; set; }

			public decimal? Cost { get; set; }

			public string CostMode { get; set; }

			public string CurrencyCode { get; set; }

			public bool? DiscountsRestricted { get; set; }

			public DateTime? DiscountsRestrictedEndDate { get; set; }

			public string DiscountsRestrictedMode { get; set; }

			public DateTime? DiscountsRestrictedStartDate { get; set; }

			public DateTime? EndDate { get; set; }

			public List<PriceListEntryExtra> ExtraEntries { get; set; }

			public bool IsVariation { get; set; }

			public decimal? Map { get; set; }

			public DateTime? MapEndDate { get; set; }

			public string MapMode { get; set; }

			public DateTime? MapStartDate { get; set; }

			public decimal? Msrp { get; set; }

			public string MsrpMode { get; set; }

			public List<ProductOption> Options { get; set; }

			public List<PriceListEntryPrice> PriceEntries { get; set; }

			public string PriceListCode { get; set; }

			public string PriceListEntryMode { get; set; }

			public int PriceListEntrySequence { get; set; }

			public string PriceListEntryTypeCode { get; set; }

			public string ProductCode { get; set; }

			public string ProductName { get; set; }

			public DateTime? StartDate { get; set; }

		}

}
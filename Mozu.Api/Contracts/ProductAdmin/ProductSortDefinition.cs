
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
		public class ProductSortDefinition
		{
			public AuditInfo AuditInfo { get; set; }

			public List<ProductSortOverride> Boosted { get; set; }

			public List<ProductSortOverride> Buried { get; set; }

			public int? CategoryId { get; set; }

			public DateTime? EndDate { get; set; }

			public string Name { get; set; }

			public int? ProductSortDefinitionId { get; set; }

			public List<ProductSortExpression> SortExpressions { get; set; }

			public DateTime? StartDate { get; set; }

		}

}

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


namespace Mozu.Api.Contracts.Kibo.Fulfillment.Model
{
		public class ResourceOfPickWave
		{
			public Dictionary<String,Object> Attributes { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public List<PickWaveContent> Contents { get; set; }

			public string FulfillmentLocationCode { get; set; }

			public Dictionary<String,Link> Links { get; set; }

			public int? MaxShipments { get; set; }

			public int? ParentPickWaveNumber { get; set; }

			public string PickType { get; set; }

			public string PickWaveId { get; set; }

			public int? PickWaveNumber { get; set; }

			public string PickWaveStatus { get; set; }

			public int? RecoveryPickWaveNumber { get; set; }

			public List<int> ShipmentNumbers { get; set; }

			public string ShipmentType { get; set; }

			public int? SiteId { get; set; }

			public int? TenantId { get; set; }

			public string UserDisplayName { get; set; }

			public string UserId { get; set; }

		}

}
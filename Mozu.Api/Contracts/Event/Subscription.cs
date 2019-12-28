
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


namespace Mozu.Api.Contracts.Event
{
		public class Subscription
		{
			public string ApiVersion { get; set; }

			public string AppId { get; set; }

			public bool? Confirmed { get; set; }

			public string ContentType { get; set; }

			public string CreateBy { get; set; }

			public DateTime? CreateDate { get; set; }

			public string Endpoint { get; set; }

			public string Id { get; set; }

			public bool? IsActive { get; set; }

			public bool? NoCallback { get; set; }

			public string NotificationDeliveryType { get; set; }

			///
			///This is a tenant that is associated with a subscription.
			///
			public List<SubscribingTenant> SubscribingTenants { get; set; }

			public List<string> Topics { get; set; }

			public string UpdateBy { get; set; }

			public DateTime? UpdateDate { get; set; }

		}

}

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


namespace Mozu.Api.Contracts.CommerceRuntime.Fulfillment
{
		public class FulfillmentTask
		{
			public bool? Active { get; set; }

			public Dictionary<String,Object> Attributes { get; set; }

			public bool? Completed { get; set; }

			public DateTime? CompletedDate { get; set; }

			public string Description { get; set; }

			public List<TaskInput> Inputs { get; set; }

			public Dictionary<String,Link> Links { get; set; }

			public string Name { get; set; }

			public bool? Skippable { get; set; }

			public string Subject { get; set; }

			public string TaskId { get; set; }

		}

}
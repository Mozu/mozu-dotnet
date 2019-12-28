
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Commerce
{
		///
		///	Properties of a system message displayed when a change, such as a change in product price, occurs for a cart or order.
		///
		public class ChangeMessage
		{
			///
			///The order or item amount changed, if applicable.
			///
			public decimal? Amount { get; set; }

			public string AppId { get; set; }

			public string AppKey { get; set; }

			public string AppName { get; set; }

			public string CorrelationId { get; set; }

			public DateTime? CreateDate { get; set; }

			public string Id { get; set; }

			public string Identifier { get; set; }

			public string Message { get; set; }

			public object Metadata { get; set; }

			public string NewValue { get; set; }

			public string OldValue { get; set; }

			public string Subject { get; set; }

			public string SubjectType { get; set; }

			///
			///If true, the change associated with the message executed successfully.
			///
			public bool? Success { get; set; }

			public string UserFirstName { get; set; }

			///
			///The unique identifier of the user who initiated the change.
			///
			public string UserId { get; set; }

			public string UserLastName { get; set; }

			public string UserScopeType { get; set; }

			public string Verb { get; set; }

		}

}

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
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.Content
{
		///
		///	A view can select which fields are returned from a document query.
		///
		public class View
		{
			///
			///The list of fields to display for a view or an associated schema. For example, the address schema would display fields for postal addresses.
			///
			public List<ViewField> Fields { get; set; }

			///
			///A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=IsDisplayed+eq+true"
			///
			public string Filter { get; set; }

			public string IncludeInactiveMode { get; set; }

			public bool? IsAdminDefault { get; set; }

			///
			///The isVisibleInStorefront field indicates whether documents in the view can be accessed from the Mozu storefront application. If true, the storefront application and storefront client application (javascript tier) can GET documents from the view.
			///
			public bool? IsVisibleInStorefront { get; set; }

			///
			///Metadata content for entities, used by document lists, document type lists, document type, views, entity lists, and list views.
			///
			public JObject Metadata { get; set; }

			///
			///The display name of the source product property. For a product field it will be the display name of the field. For a product attribute it will be the Attribute Name.
			///
			public string Name { get; set; }

			///
			///List description of usages for content within a view and scope.
			///
			public List<string> Usages { get; set; }

		}

}
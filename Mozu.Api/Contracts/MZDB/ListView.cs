
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

namespace Mozu.Api.Contracts.MZDB
{
		///
		///	Properties for the list view that specifies what fields and content display per page load. All associated fields in the list view correspond with object data.
		///
		public class ListView
		{
			///
			///Sets the default sorting for content. Sort does not use AND in determining the order.
			///
			public string DefaultSort { get; set; }

			///
			///The list of fields to display for a view or an associated schema. For example, the address schema would display fields for postal addresses.
			///
			public List<ListViewField> Fields { get; set; }

			///
			///A set of expressions that consist of a field, operator, and value and represent search parameter syntax when filtering results of a query. Valid operators include equals (eq), does not equal (ne), greater than (gt), less than (lt), greater than or equal to (ge), less than or equal to (le), starts with (sw), or contains (cont). For example - "filter=IsDisplayed+eq+true"
			///
			public string Filter { get; set; }

			///
			///Metadata content for entities, used by document lists, document type lists, document type, views, entity lists, and list views.
			///
			public JObject MetaData { get; set; }

			///
			///The user supplied name that appears in . You can use this field for identification purposes.
			///
			public string Name { get; set; }

			///
			///Indicates the security level for the document content as public, administrator, or owner.
			///
			public string Security { get; set; }

			///
			///A string array that determines where the document or entity list displays. The options are , for displaying content in the Custom Schema page in  , and , for displaying content in the site tree in Site Builder (applies only to document lists). The following example demonstrates how to display content across both options:
			///
			public List<string> Usages { get; set; }

		}

}
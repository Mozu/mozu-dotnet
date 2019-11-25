
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.Content
{
		///
		///	The document properties that define the content used by the content management system (CMS).
		///
		public class Document
		{
			///
			///Mozu.Content.Contracts.Document activeDateRange ApiTypeMember DOCUMENT_HERE 
			///
			public ActiveDateRange ActiveDateRange { get; set; }

			public long ContentLength { get; set; }

			public string ContentMimeType { get; set; }

			public DateTime? ContentUpdateDate { get; set; }

			///
			///Fully qualified name of the document type. 
			///
			public string DocumentTypeFQN { get; set; }

			public string Extension { get; set; }

			public string Id { get; set; }

			public DateTime? InsertDate { get; set; }

			///
			///The fully qualified name of the document list.
			///
			public string ListFQN { get; set; }

			public string Name { get; set; }

			public JObject Properties { get; set; }

			///
			///The name of the publish set that this document belongs to, if any.
			///
			public string PublishSetCode { get; set; }

			public string PublishState { get; set; }

			public DateTime? UpdateDate { get; set; }

		}

}
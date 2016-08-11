
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
		///	Properties for the document list type. Document lists contain documents with an associated document type, such as web pages.
		///
		public class DocumentListType
		{
			///
			///Definition of any documents to create with a document list is created. 
			///
			public List<DocumentInstallation> DefaultDocuments { get; set; }

			///
			///The fully qualified name for the document list type for content. 
			///
			public string DocumentListTypeFQN { get; set; }

			///
			///List of fully qualified names for the document type.
			///
			public List<string> DocumentTypeFQNs { get; set; }

			public bool? EnableActiveDateRanges { get; set; }

			///
			///Indicates if the document list and document list type are enabled to publish. If true, publishing of draft documents in this document list/document list type is enabled for the site. If false, all document changes are immediately published in live mode.
			///
			public bool? EnablePublishing { get; set; }

			///
			///The package of document lists and content documents to be installed.
			///
			public string InstallationPackage { get; set; }

			///
			///Metadata content for entities, used by document lists, document type lists, document type, views, entity lists, and list views.
			///
			public JObject Metadata { get; set; }

			///
			///The display name of the source product property. For a product field it will be the display name of the field. For a product attribute it will be the Attribute Name.
			///
			public string Name { get; set; }

			///
			///If applicable, the registered namespace associated with objects, used to generate the fully qualified name. If no namespace is defined, the namespace associated with the tenant is automatically assigned.
			///
			public string Namespace { get; set; }

			///
			///The scope at which the object exists, such as "Tenant", "MasterCatalog", or "Site". Scope delineates the level and area of Mozu the object exists within or affects.
			///
			public string ScopeType { get; set; }

			public bool SupportsActiveDateRanges { get; set; }

			///
			///Indicates if modified documents are published automatically or saved to publish at a later time. If true, changed documents in this list can be saved as drafts until they are published to the site. If false, all document changes are immediately published in live mode. System-supplied and read only.
			///
			public bool SupportsPublishing { get; set; }

			///
			///List description of usages for content within a view and scope.
			///
			public List<string> Usages { get; set; }

			///
			///The current version number of the order, wish list, document list, or document type list.
			///
			public string Version { get; set; }

			///
			///The view in the site used by associated entities or document lists/list types.
			///
			public List<View> Views { get; set; }

		}

}
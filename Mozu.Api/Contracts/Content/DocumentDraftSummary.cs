
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.Content
{
		///
		///	Summary properties of an unpublished document draft.
		///
		public class DocumentDraftSummary
		{
			public DateTime? ActiveUpdateDate { get; set; }

			///
			///The unique identifier of the user that last updated the content or document draft.
			///
			public string ActiveUpdatedBy { get; set; }

			///
			///The unique identifier for the product catalog. Catalogs are part of a master catalog.
			///
			public int? CatalogId { get; set; }

			///
			///Fully qualified name of the document type. 
			///
			public string DocumentTypeFQN { get; set; }

			public DateTime DraftUpdateDate { get; set; }

			public string Id { get; set; }

			///
			///The fully qualified name of the document list.
			///
			public string ListFQN { get; set; }

			///
			///Unique identifier for the master catalog. 
			///
			public int? MasterCatalogId { get; set; }

			public string Name { get; set; }

			///
			///The unique identifier of the publish set.
			///
			public string PublishSetCode { get; set; }

			public string PublishType { get; set; }

			///
			///Unique identifier for the site. This IDÂ is used at all levels of a store, catalog, and tenant to associate objects to a site.
			///
			public int? SiteId { get; set; }

			public string UpdatedBy { get; set; }

		}

}
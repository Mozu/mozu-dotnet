
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


namespace Mozu.Api.Contracts.SiteSettings.General.General.Routing
{
		///
		///	Mozu.SiteSettings.General.Contracts.General.Routing.Mapping ApiType DOCUMENT_HERE 
		///
		public class Mapping
		{
			///
			///beforeRouting ApiType DOCUMENT_HERE 
			///
			public bool? BeforeRouting { get; set; }

			///
			///docId ApiType DOCUMENT_HERE 
			///
			public string DocId { get; set; }

			///
			///facetId ApiType DOCUMENT_HERE 
			///
			public string FacetId { get; set; }

			///
			///The fully qualified name of the document list.
			///
			public string ListFqn { get; set; }

			///
			///mappings ApiType DOCUMENT_HERE 
			///
			public Dictionary<String,Object> Mappings { get; set; }

			///
			///mapTo ApiType DOCUMENT_HERE 
			///
			public string MapTo { get; set; }

			///
			///pattern ApiType DOCUMENT_HERE 
			///
			public string Pattern { get; set; }

			///
			///replacement ApiType DOCUMENT_HERE 
			///
			public string Replacement { get; set; }

			///
			///type ApiType DOCUMENT_HERE 
			///
			public string Type { get; set; }

		}

}
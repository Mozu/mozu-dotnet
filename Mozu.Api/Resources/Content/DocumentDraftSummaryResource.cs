
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
using Mozu.Api.Security;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Mozu.Api.Resources.Content
{
	/// <summary>
	/// Use the document publishing subresource to manage and publish document drafts in the Content service.
	/// </summary>
	public partial class DocumentDraftSummaryResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public DocumentDraftSummaryResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public DocumentDraftSummaryResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new DocumentDraftSummaryResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentLists">List of document lists that contain documents to delete.</param>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Content.DocumentDraftSummaryPagedCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var documentdraftsummary = new DocumentDraftSummary();
		///   var documentDraftSummaryPagedCollection = await documentdraftsummary.ListDocumentDraftSummariesAsync( pageSize,  startIndex,  documentLists,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Content.DocumentDraftSummaryPagedCollection> ListDocumentDraftSummariesAsync(int? pageSize =  null, int? startIndex =  null, string documentLists =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Content.DocumentDraftSummaryPagedCollection> response;
			var client = Mozu.Api.Clients.Content.DocumentDraftSummaryClient.ListDocumentDraftSummariesClient( pageSize,  startIndex,  documentLists,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentLists">List of document lists that contain documents to delete.</param>
		/// <param name="documentIds">Unique identifiers of the documents to delete.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var documentdraftsummary = new DocumentDraftSummary();
		///   var stream = await documentdraftsummary.DeleteDocumentDraftsAsync( documentIds,  documentLists);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteDocumentDraftsAsync(List<string> documentIds, string documentLists =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Content.DocumentDraftSummaryClient.DeleteDocumentDraftsClient( documentIds,  documentLists);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentLists">List of document lists that contain documents to delete.</param>
		/// <param name="documentIds">Unique identifiers of the documents to delete.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var documentdraftsummary = new DocumentDraftSummary();
		///   var stream = await documentdraftsummary.PublishDocumentsAsync( documentIds,  documentLists);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> PublishDocumentsAsync(List<string> documentIds, string documentLists =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Content.DocumentDraftSummaryClient.PublishDocumentsClient( documentIds,  documentLists);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}



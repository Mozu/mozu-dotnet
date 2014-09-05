using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Content;
using Mozu.Api.Resources.Content.Documentlists;

namespace Mozu.Api.ToolKit.Readers
{
    public class DocumentReader : BaseReader
    {
        private DocumentCollection _results = null; 
        public string DocumentListName { get; set; }
        public DataViewMode? DataViewMode { get; set; }

        protected override async Task<bool> GetDataAsync()
        {
            var resource = new DocumentResource(Context,DataViewMode.HasValue ? DataViewMode.Value : Api.DataViewMode.Live);
            _results = await resource.GetDocumentsAsync(DocumentListName, startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Document> Items
        {
            get { return _results.Items; }
        }
    }
}

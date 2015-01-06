using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.CommerceRuntime.Returns;
using Mozu.Api.Resources.Commerce;

namespace Mozu.Api.ToolKit.Readers
{
    public class OrderReturnReader : BaseReader
    {
        private ReturnCollection _results = null;
        protected override async Task<bool> GetDataAsync()
        {
            var resource = new ReturnResource(Context);
            _results = await resource.GetReturnsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Return> Items
        {
            get { return _results.Items; }
        }
    }
}

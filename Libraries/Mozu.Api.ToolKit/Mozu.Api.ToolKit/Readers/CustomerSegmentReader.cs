using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Commerce.Customer;


namespace Mozu.Api.ToolKit.Readers
{
    public class CustomerSegmentReader : BaseReader
    {
        private CustomerSegmentCollection _results;
        protected override async Task<bool> GetDataAsync()
        {
            var resource = new CustomerSegmentResource(Context);
            _results = await resource.GetSegmentsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);
            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }
        public List<CustomerSegment> Items
        {
            get { return _results.Items; }
        }
    }
}

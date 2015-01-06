using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Commerce.Customer.Accounts;

namespace Mozu.Api.ToolKit.Readers
{
    public class CustomerAccountSegmentReader : BaseReader
    {
        private CustomerSegmentCollection _results;
        public int AccountId { get; set; }

        protected async override Task<bool> GetDataAsync()
        {
            var resource = new CustomerSegmentResource(Context);
            _results = await resource.GetAccountSegmentsAsync(AccountId, startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);

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

using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Commerce.Customer;

namespace Mozu.Api.ToolKit.Readers
{
    public class CustomerAccountReader : BaseReader
    {
        private CustomerAccountCollection _results = null;

        protected override async Task<bool> GetDataAsync()
        {
            var resource = new CustomerAccountResource(Context);
            _results = await resource.GetAccountsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, q: Q, qLimit: QLimit, responseFields:ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<CustomerAccount> Items
        {
            get { return _results.Items; }
        }
    }
}

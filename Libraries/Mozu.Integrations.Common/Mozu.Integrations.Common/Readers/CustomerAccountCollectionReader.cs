using System.Collections.Generic;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Commerce.Customer;

namespace Mozu.Integrations.Common.Readers
{
    public class CustomerAccountCollectionReader : BasePagedCollectionReader
    {
        private CustomerAccountCollection _results = null;

        protected override bool GetData()
        {
            var resource = new CustomerAccountResource(Context);
            _results = resource.GetAccounts(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, q: Q, qLimit: QLimit);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;

            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<CustomerAccount> Items
        {
            get { return _results.Items; }
        }
    }
}

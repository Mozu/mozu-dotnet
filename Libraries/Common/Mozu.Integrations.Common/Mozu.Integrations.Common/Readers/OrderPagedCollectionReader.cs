using System.Collections.Generic;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Resources.Commerce;

namespace Mozu.Integrations.Common.Readers
{
    public class OrderPagedCollectionReader : BasePagedCollectionReader
    {
        private OrderCollection _results = null;

        protected override bool GetData()
        {
            var resource = new OrderResource(Context);
            _results = resource.GetOrders(startIndex: StartIndex, pageSize:PageSize, sortBy:SortBy, filter:Filter, q:Q, qLimit:QLimit);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;

            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Order> Items
        {
            get { return _results.Items; }
        }

    }
}

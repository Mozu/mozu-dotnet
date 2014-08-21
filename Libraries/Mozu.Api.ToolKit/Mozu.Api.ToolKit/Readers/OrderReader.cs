using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Resources.Commerce;

namespace Mozu.Api.ToolKit.Readers
{
    public class OrderReader : BaseReader
    {
        private OrderCollection _results = null;

        protected override async Task<bool> GetDataAsync()
        {
            var resource = new OrderResource(Context);
            _results = await resource.GetOrdersAsync(startIndex: StartIndex, pageSize:PageSize, sortBy:SortBy, filter:Filter, q:Q, qLimit:QLimit, responseFields:ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Order> Items
        {
            get { return _results.Items; }
        }

    }
}

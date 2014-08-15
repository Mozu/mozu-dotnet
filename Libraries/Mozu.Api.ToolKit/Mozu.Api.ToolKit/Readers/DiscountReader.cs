using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class DiscountReader : BaseReader
    {
        private DiscountCollection _results = null;
        public DataViewMode DataViewMode { get; set; }

        protected override async Task<bool> GetDataAsync()
        {
            var resource = new DiscountResource(Context);
            _results = await resource.GetDiscountsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields:ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;

            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Discount> Items
        {
            get { return _results.Items; }
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class DiscountReader : BaseReader
    {
        private DiscountCollection _results;
        public DataViewMode? DataViewMode { get; set; }

        protected override async Task<bool> GetDataAsync()
        {
            var resource = new DiscountResource(Context, DataViewMode.HasValue ? DataViewMode.Value : Api.DataViewMode.Live);
            _results = await resource.GetDiscountsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields:ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Discount> Items
        {
            get { return _results.Items; }
        }
    }
}

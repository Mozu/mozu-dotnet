using System.Collections.Generic;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class DiscountCollectionReader : BasePagedCollectionReader
    {
        private DiscountCollection _results = null;
        public DataViewMode DataViewMode { get; set; }

        protected override bool GetData()
        {
            var resource = new DiscountResource(Context);
            _results = resource.GetDiscounts(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, dataViewMode:DataViewMode);

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

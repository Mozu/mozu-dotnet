using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class ProductAdminCollectionReader : BasePagedCollectionReader
    {
        private ProductCollection _results = null;

        public DataViewMode DataViewMode { get; set; }

        protected override async Task<bool> GetDataAsync()
        {
         
            var resource = new ProductResource(Context, DataViewMode);
            _results = await resource.GetProductsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, q: Q, qLimit: QLimit,responseFields:ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;

            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Product> Items
        {
            get { return _results.Items; }
        }
    }
}

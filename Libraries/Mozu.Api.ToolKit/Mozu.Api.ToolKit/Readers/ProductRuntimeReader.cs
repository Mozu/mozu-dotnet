using System.Collections.Generic;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductRuntime;
using Mozu.Api.Resources.Commerce.Catalog.Storefront;

namespace Mozu.Api.ToolKit.Readers
{
    public class ProductRuntimeReader : BaseReader
    {
        private ProductCollection _results = null;

        protected override async Task<bool> GetDataAsync()
        {

            var resource = new ProductResource(Context);
            _results = await resource.GetProductsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields:ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Product> Items
        {
            get { return _results.Items; }
        }
    }
}

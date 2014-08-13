using System.Collections.Generic;
using Mozu.Api.Contracts.ProductRuntime;
using Mozu.Api.Resources.Commerce.Catalog.Storefront;

namespace Mozu.Api.ToolKit.Readers
{
    public class ProductRuntimeCollectionReader : BasePagedCollectionReader
    {
        private ProductCollection _results = null;

        protected override bool GetData()
        {

            var resource = new ProductResource(Context);
            _results = resource.GetProducts(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter);

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

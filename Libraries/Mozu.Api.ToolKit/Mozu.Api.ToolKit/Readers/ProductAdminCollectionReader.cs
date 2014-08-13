using System.Collections.Generic;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class ProductAdminCollectionReader : BasePagedCollectionReader
    {
        private ProductCollection _results = null;

        public DataViewMode DataViewMode { get; set; }

        protected override bool GetData()
        {
         
            var resource = new ProductResource(Context);
            _results = resource.GetProducts(dataViewMode:DataViewMode, startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, q: Q, qLimit: QLimit);

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

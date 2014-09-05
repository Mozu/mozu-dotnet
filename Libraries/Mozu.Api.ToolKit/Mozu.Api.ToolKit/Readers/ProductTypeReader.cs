using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin.Attributedefinition;

namespace Mozu.Api.ToolKit.Readers
{
    public class ProductTypeReader : BaseReader
    {
        private ProductTypeCollection _results = null;

        protected override async Task<bool> GetDataAsync()
        {
            var resource = new ProductTypeResource(Context);
            _results = await resource.GetProductTypesAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<ProductType> Items
        {
            get { return _results.Items; }
        }
    }
}

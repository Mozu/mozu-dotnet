using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin.Products;
using Attribute = System.Attribute;

namespace Mozu.Api.ToolKit.Readers
{
    public class ProductVariationReader : BaseReader
    {
        private ProductVariationPagedCollection _results;
        public string ProductCode { get; set; }
        public DataViewMode DataViewMode { get; set; }
        protected async override Task<bool> GetDataAsync()
        {
            var resource = new ProductVariationResource(Context, DataViewMode);
            _results = await resource.GetProductVariationsAsync(ProductCode, startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }


        public List<ProductVariation> Items
        {
            get { return _results.Items; }
        } 
    }
}

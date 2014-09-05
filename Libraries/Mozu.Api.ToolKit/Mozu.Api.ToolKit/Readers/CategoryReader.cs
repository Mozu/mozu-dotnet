using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class CategoryReader : BaseReader
    {
        private CategoryPagedCollection _results;
        protected async override Task<bool> GetDataAsync()
        {
            var categoryResource = new CategoryResource(Context);

            _results = await categoryResource.GetCategoriesAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Category> Items
        {
            get { return _results.Items; }
        } 
    }
}

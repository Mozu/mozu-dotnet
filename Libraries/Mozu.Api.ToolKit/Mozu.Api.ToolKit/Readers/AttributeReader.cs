using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin.Attributedefinition;
using Attribute = Mozu.Api.Contracts.ProductAdmin.Attribute;

namespace Mozu.Api.ToolKit.Readers
{
    public class AttributeReader : BaseReader
    {
        private AttributeCollection _results;

        protected async override Task<bool> GetDataAsync()
        {
            var resource = new AttributeResource(Context);
            _results = await resource.GetAttributesAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter,  responseFields: ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }


        public List<Attribute> Items
        {
            get { return _results.Items; }
        } 
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Resources.Commerce.Catalog.Admin;
using Attribute = System.Attribute;

namespace Mozu.Api.ToolKit.Readers
{
    public class LocationInventoryReader : BaseReader
    {
        private LocationInventoryCollection _results;

        public string LocationCode { get; set; }
        protected async override Task<bool> GetDataAsync()
        {
            var resource = new LocationInventoryResource(Context);
            _results = await resource.GetLocationInventoriesAsync(LocationCode, startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, responseFields: ResponseFields);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }


        public List<LocationInventory> Items
        {
            get { return _results.Items; }
        } 
    }
}

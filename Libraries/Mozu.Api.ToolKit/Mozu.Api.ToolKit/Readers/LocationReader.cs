using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Location;
using Mozu.Api.Resources.Commerce.Admin;

namespace Mozu.Api.ToolKit.Readers
{
    public class LocationReader : BaseReader
    {
        private LocationCollection _results;

        public string LocationCode { get; set; }
        protected async override Task<bool> GetDataAsync()
        {
            var resource = new LocationResource(Context);
            _results = await resource.GetLocationsAsync(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }


        public List<Location> Items
        {
            get { return _results.Items; }
        } 
    }
}

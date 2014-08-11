using System.Collections.Generic;
using Mozu.Api.Contracts.CommerceRuntime.Wishlists;
using Mozu.Api.Resources.Commerce;

namespace Mozu.Api.ToolKit.Readers
{
    public class WishlistCollectionReader : BasePagedCollectionReader
    {
        private WishlistCollection _results = null;

        protected override bool GetData()
        {
            var resource = new WishlistResource(Context);
            _results = resource.GetWishlists(startIndex: StartIndex, pageSize: PageSize, sortBy: SortBy, filter: Filter, q: Q, qLimit: QLimit);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;

            return _results.Items != null && _results.Items.Count > 0;
        }

        public List<Wishlist> Items
        {
            get { return _results.Items; }
        }
    }
}

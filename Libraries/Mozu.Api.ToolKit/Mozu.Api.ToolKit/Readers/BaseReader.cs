using System.Threading.Tasks;

namespace Mozu.Api.ToolKit.Readers
{
    public abstract class BaseReader
    {
        public IApiContext Context { get; set; }
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public string ResponseFields { get; set; }

        public int? PageSize { get; set; }
        public int? StartIndex { get; set; }
        public int? PageCount { get; set; }
        public string Q { get; set; }
        public int? QLimit { get; set; }
        public int? TotalCount { get; protected set; }

        public async Task<bool> ReadAsync()
        {
            if (!PageSize.HasValue) PageSize = 20;

            if (TotalCount.HasValue && StartIndex.HasValue && PageSize.HasValue)
            {
                if (TotalCount <= StartIndex)
                    return false;
            }

            var hasData = await GetDataAsync();

            StartIndex = StartIndex.GetValueOrDefault(0) + PageSize;
            return hasData;

        }

        protected abstract Task<bool> GetDataAsync();
    }
}

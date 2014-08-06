using Mozu.Api;

namespace Mozu.Integrations.Common.Readers
{
    public abstract class BasePagedCollectionReader
    {
        public IApiContext Context { get; set; }
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public int? PageSize { get; set; }
        public int? StartIndex { get; set; }
        public int? PageCount { get; set; }
        public string Q { get; set; }
        public int? QLimit { get; set; }
        public int? TotalCount { get; protected set; }

        public bool Read()
        {
            if (TotalCount.HasValue && StartIndex.HasValue && PageSize.HasValue)
            {
                if (TotalCount <= StartIndex)
                    return false;
            }


            var hasData = GetData();

            StartIndex = StartIndex.GetValueOrDefault(0) + PageSize;
            return hasData;

        }

        protected abstract bool GetData();
    }
}

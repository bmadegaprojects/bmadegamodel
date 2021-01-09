namespace Human.Resources.Domain.Core.Pagination
{
    public class PagingParams : IPagingParams
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}

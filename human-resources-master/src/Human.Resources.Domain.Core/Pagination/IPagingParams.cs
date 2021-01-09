namespace Human.Resources.Domain.Core.Pagination
{
    public interface IPagingParams
    {
        int? PageSize { get; set; }
        int? PageNumber { get; set; }
    }
}

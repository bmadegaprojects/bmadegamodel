using System.Linq;
using System.Threading.Tasks;

namespace Human.Resources.Domain.Core.Pagination
{
    public static class QueryableExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> items, IPagingParams pagingParams)
        {
            return PagedList<T>.GetPagedList(items, pagingParams);
        }
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> items, IPagingParams pagingParams)
        {
            return await PagedList<T>.GetPagedListAsync(items, pagingParams);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> items, IPagingParams pagingParams)
        {
            if (pagingParams?.PageSize != null && pagingParams.PageNumber.HasValue)
            {
                return items.Skip(pagingParams.PageSize.Value * (pagingParams.PageNumber.Value - 1))
                            .Take(pagingParams.PageSize.Value);
            }

            return items;
        }
    }
}

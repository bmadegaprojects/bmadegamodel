using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Human.Resources.Domain.Core.Pagination
{
    public class PagedList<T>
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public int NextPageNumber => HasNextPage ? PageNumber + 1 : TotalPages;
        public int PreviousPageNumber => HasPreviousPage ? PageNumber - 1 : 1;

        public List<T> PageItems { get; set; }

        private PagedList() { }

        private PagedList(IQueryable<T> source, IPagingParams page)
        {
            TotalItems = source.Count();
            if (page != null)
            {
                PageNumber = page.PageNumber.GetValueOrDefault();
                PageSize = page.PageSize.GetValueOrDefault();
            }
            PageItems = source
                        .ApplyPaging(page)
                        .ToList();
        }

        public PagedList(List<T> pageItems, int totalItems, IPagingParams page)
        {
            TotalItems = totalItems;
            PageItems = pageItems;

            if (page == null) return;
            PageNumber = page.PageNumber.GetValueOrDefault();
            PageSize = page.PageSize.GetValueOrDefault();
        }

        public static PagedList<T> GetPagedList(IQueryable<T> source, IPagingParams page)
        {
            return new PagedList<T>(source, page);
        }

        public static async Task<PagedList<T>> GetPagedListAsync(IQueryable<T> source, IPagingParams page)
        {
            var paged = new PagedList<T>
            {
                TotalItems = source.Count(),
                PageNumber = page.PageNumber.GetValueOrDefault(),
                PageSize = page.PageSize.GetValueOrDefault(),
                PageItems = await source
                                    .ApplyPaging(page)
                                    .ToListAsync()
            };

            return paged;
        }
    }
}

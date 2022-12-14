using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public List<T> Result { get; set; } = new List<T>();

        public PaginatedList(List<T> items, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            Result.AddRange(items);
        }

        public PaginatedList()
        {

        }
    }
    public static class PaginatedListHelper
    {

        public const int DefaultPageSize = 15;
        public const int DefaultCurrentPage = 1;

        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int currentPage, int pageSize)
        {
            currentPage = currentPage > 0 ? currentPage : DefaultCurrentPage;
            pageSize = pageSize > 0 ? pageSize : DefaultPageSize;
            var count = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, currentPage, pageSize);
        }


        public static PaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> source, int currentPage, int pageSize)
        {
            var data = source.AsEnumerable();
            currentPage = currentPage > 0 ? currentPage : DefaultCurrentPage;
            pageSize = pageSize > 0 ? pageSize : DefaultPageSize;
            var count = data.Count();
            var items = data.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, currentPage, pageSize);
        }
    }

}

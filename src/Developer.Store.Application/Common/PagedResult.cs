using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public PagedResult(IEnumerable<T> data, int totalItems, int currentPage, int pageSize)
        {
            Data = data;
            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        }
    }
}

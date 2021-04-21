using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.API.Utils
{
    public class PaginatedList<T>
    {
        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public int TotalRecord { get; private set; }

        public int TotalPage { get; private set; }

        public List<T> data { get; private set; }

        public PaginatedList(int page, int pageSize, int totalRecord, List<T> data)
        {
            Page = page;
            TotalPage = (int)Math.Ceiling(totalRecord / (double)pageSize);
            TotalRecord = totalRecord;
            PageSize = pageSize;
            this.data = data;
        }

        public static PaginatedList<T> CreateAsync(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(pageIndex, pageSize, count, items);
        }

        public bool HasPreviousPage {
            get {
                return (Page > 1);
            }
        }

        public bool HasNextPage {
            get {
                return (Page < TotalPage);
            }
        }

        public int TotalPageNo {
            get {
                return TotalPage;
            }
        }
    }
}
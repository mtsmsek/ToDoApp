using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.Pages
{
    public class Page
    {
        public Page() : this(0)
        {

        }
        public Page(int totalRowCount) : this(1, 10, totalRowCount)
        {
            //TODO make current page and page size values constant
        }
        public Page(int pageSize, int totalRowCount) : this(1, pageSize, totalRowCount)
        {

        }
        public Page(int currentPage, int pageSize, int totalRowCount)
        {
            //TODO Create Exception 
            //TODO Create message in constants
            if (currentPage < 1)
                throw new ArgumentNullException("Invalid page number!");

            if (pageSize < 1)
                throw new ArgumentNullException("Invalid page number!");


            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalRowCount = totalRowCount;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRowCount { get; set; }
        public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);
        public int Skip => (CurrentPage - 1) * PageSize;
    }
}

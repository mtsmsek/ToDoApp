using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.Pages
{
    public class BasedPageQuery
    {
        protected BasedPageQuery(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
    }
}

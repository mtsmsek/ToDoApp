using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.Pages
{
    public class PagedViewModel<T> where T : class
    {
        public PagedViewModel() : this(new List<T>(), new Page())
        {

        }
        public PagedViewModel(IList<T> results, Page page)
        {
            Results = results;
            Page = page;
        }
        public IList<T> Results { get; set; }
        public Page Page { get; set; }
    }
}

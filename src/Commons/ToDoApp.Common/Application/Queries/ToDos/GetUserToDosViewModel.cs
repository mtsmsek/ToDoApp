using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.Domains.ToDos;

namespace ToDoApp.Common.Application.Queries.ToDos
{
    public class GetUserToDosViewModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ToDoColor? Color { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool IsPinned { get; set; }
    }
}

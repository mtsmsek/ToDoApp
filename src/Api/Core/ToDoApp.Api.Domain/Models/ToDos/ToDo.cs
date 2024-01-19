using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Commons;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Common.Domains.ToDos;

namespace ToDoApp.Api.Domain.Models.ToDos
{
    public class ToDo : BaseEntity
    {
        public Guid CreatedById { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ToDoColor? Color { get; set; } 
        public DateTime? DeadLine { get; set; }
        public bool IsPinned { get; set; }

        public User CreatedBy{ get; set; }

    }
}

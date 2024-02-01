using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.Domains.ToDos;

namespace ToDoApp.Common.Application.RequestModels.ToDos
{
    public class CreateToDoCommand : IRequest<Guid>
    {
        public Guid CreatedById { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ToDoColor? Color { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool IsPinned { get; set; }
    }
}

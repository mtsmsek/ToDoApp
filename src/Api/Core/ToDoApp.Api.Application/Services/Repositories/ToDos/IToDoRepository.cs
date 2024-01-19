using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.Commons;
using ToDoApp.Api.Domain.Models.ToDos;

namespace ToDoApp.Api.Application.Services.Repositories.ToDos
{
    public interface IToDoRepository : IAsyncRepository<ToDo>
    {
    }
}

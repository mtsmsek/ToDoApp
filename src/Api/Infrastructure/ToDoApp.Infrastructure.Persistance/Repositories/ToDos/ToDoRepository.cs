using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.ToDos;
using ToDoApp.Api.Domain.Models.ToDos;
using ToDoApp.Infrastructure.Persistance.Context;
using ToDoApp.Infrastructure.Persistance.Repositories.Commons;

namespace ToDoApp.Infrastructure.Persistance.Repositories.ToDos
{
    public class ToDoRepository : AsyncRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

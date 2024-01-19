using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.Commons;
using ToDoApp.Api.Domain.Models.Users;

namespace ToDoApp.Api.Application.Services.Repositories.Users
{
    public interface IUserRepository : IAsyncRepository<User>
    {

    }
}

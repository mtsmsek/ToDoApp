using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.Users;
using ToDoApp.Api.Domain.Models.Users;
using ToDoApp.Infrastructure.Persistance.Context;
using ToDoApp.Infrastructure.Persistance.Repositories.Commons;

namespace ToDoApp.Infrastructure.Persistance.Repositories.Users
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        public UserRepository(ToDoAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

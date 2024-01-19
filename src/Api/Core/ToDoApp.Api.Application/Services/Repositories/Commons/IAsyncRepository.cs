using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Commons;

namespace ToDoApp.Api.Application.Services.Repositories.Commons
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> Add(TEntity entity);
    }
}

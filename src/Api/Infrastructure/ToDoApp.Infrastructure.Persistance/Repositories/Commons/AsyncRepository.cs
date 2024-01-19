using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.Commons;
using ToDoApp.Api.Domain.Models.Commons;

namespace ToDoApp.Infrastructure.Persistance.Repositories.Commons
{
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;
        protected DbSet<TEntity> _entity => _dbContext.Set<TEntity>();

        public AsyncRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Insert Methods
        public async Task<int> Add(TEntity entity)
        {
            await _entity.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}

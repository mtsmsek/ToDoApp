using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.Commons;
using ToDoApp.Api.Domain.Models.Commons;
using ToDoApp.Common.Extensions.Paging;
using ToDoApp.Common.Pages;

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
        public async Task<int> AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        #endregion
        public async Task<PagedViewModel<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int currentPage = 0, int pageSize = 10, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entity;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            //TODO- includes.count can be controlled
            if (includes is not null)
            {

                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (noTracking)
                query = query.AsNoTracking();

            return await query.GetPagedAsync(currentPage, pageSize);
        }
    }
}

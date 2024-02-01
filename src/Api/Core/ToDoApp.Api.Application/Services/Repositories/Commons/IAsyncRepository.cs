using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Domain.Models.Commons;
using ToDoApp.Common.Pages;

namespace ToDoApp.Api.Application.Services.Repositories.Commons
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task<PagedViewModel<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                   bool enableTracking = true,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                   int currentPage = 0,
                                                   int pageSize = 10,
                                                   CancellationToken cancellationToken = default,
                                                   params Expression<Func<TEntity, object>>[] includes);

    }
}

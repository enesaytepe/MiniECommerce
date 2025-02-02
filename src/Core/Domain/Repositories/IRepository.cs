using Domain.Entities;
using Domain.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    IQueryable<TEntity> Query();

    TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true);

    IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10, bool enableTracking = true);

    bool Any(Expression<Func<TEntity, bool>> predicate = null, bool enableTracking = true);
    TEntity Add(TEntity entity);
    IList<TEntity> AddRange(IList<TEntity> entities);
    TEntity Update(TEntity entity);
    IList<TEntity> UpdateRange(IList<TEntity> entities);
    TEntity Delete(TEntity entity);
    IList<TEntity> DeleteRange(IList<TEntity> entity);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true, CancellationToken cancellationToken = default);

    Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, bool enableTracking = true, CancellationToken cancellationToken = default);

    Task<TEntity> AddAsync(TEntity entity);

    Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entity);

    Task<TEntity> DeleteAsync(TEntity entity);

    Task<IList<TEntity>> DeleteRangeAsync(IList<TEntity> entity);
}

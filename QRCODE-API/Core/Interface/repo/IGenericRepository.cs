using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QRCODE_API.Interface.repo
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> DbSet { get; }
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> criteria);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> FirstAsync();
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> LastAsync();
        Task<TEntity> LastAsync(Expression<Func<TEntity, bool>> criteria);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> criteria);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task Delete(TEntity entity);
        Task Delete(Expression<Func<TEntity, bool>> criteria);
        Task DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(Expression<Func<TEntity, bool>> criteria);
        Task<int> SaveChangesAsync();
    }
}

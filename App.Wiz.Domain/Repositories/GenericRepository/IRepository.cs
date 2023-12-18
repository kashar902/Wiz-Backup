using App.Wiz.Infrastructure.Entities;
using System.Linq.Expressions;

namespace App.Wiz.Domain.Repositories.GenericRepository;

public interface IRepository<TEntity> where TEntity : class, new()
{
    Task<TEntity> AddAsync(TEntity entity);
    Task AddAsync(List<TEntity> entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(List<TEntity> entities);
    Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, bool>>[] wheres);
    Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(params Expression<Func<TEntity, bool>>[] wheres);
    Task<TEntity?> GetAsync(params Expression<Func<TEntity, object>>[] Includes);
    Task UpdateAsync(TEntity entity);
}
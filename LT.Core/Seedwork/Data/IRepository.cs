using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.Data
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, IHasId
    {
        TEntity Add(TEntity entity, bool shouldSaveChanges = true);
        IQueryable<TEntity> AddAll(IEnumerable<TEntity> entities, bool shouldSaveChanges = true);
        Task<TEntity> AddAsync(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Delete(TEntity entity, bool shouldSaveChanges = true);
        bool Delete(object id, bool shouldSaveChanges = true);
        Task<TEntity> DeleteAsync(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(object id, bool shouldSaveChanges = true);
        Task<bool> DeleteAsync(object id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        TEntity Update(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> UpdateAsync(TEntity entity, bool shouldSaveChanges = true);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity GetById(object Id);
        Task<TEntity> GetByIdAsync(object Id);
    }
}

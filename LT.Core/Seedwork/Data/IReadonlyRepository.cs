using System;
using System.Linq;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.Data
{
    public interface IReadonlyRepository<TEntity> : IDisposable
        where TEntity : class, IHasId
    {
        IQueryable<TEntity> CustomQuery(string query);
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
    }
}

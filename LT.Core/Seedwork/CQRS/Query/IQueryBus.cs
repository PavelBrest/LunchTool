using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.CQRS.Query
{
    public interface IQueryBus
    {
        Task<Tout> Send<TQuery, Tout>(TQuery query, CancellationToken token = default)
            where TQuery : class, IQuery<Tout>;
    }
}

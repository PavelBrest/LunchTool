using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.Seedwork.CQRS.Query
{
    internal abstract class QueryHandlerDecorator<TQuery, Tout>
        : IPipelineBehavior<TQuery, Tout>
        where TQuery : class, IQuery<Tout>
        where Tout : class
    {
        public abstract Task<Tout> Handle(TQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<Tout> next);
    }
}

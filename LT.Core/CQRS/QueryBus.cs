using LT.Core.Seedwork.CQRS.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LT.Core.CQRS
{
    internal sealed class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Tout> Send<TQuery, Tout>(TQuery query, CancellationToken token = default)
            where TQuery : class, IQuery<Tout>
        {
            return _mediator.Send(query, token);
        }
    }
}

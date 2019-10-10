using MediatR;

namespace LT.Core.Seedwork.CQRS.Query
{
    public interface IQueryHandler<in TQuery, Tout>
        : IRequestHandler<TQuery, Tout>
        where TQuery : class, IQuery<Tout>
    { }
}

using MediatR;

namespace LT.Core.Seedwork.CQRS.Query
{
    public interface IQuery<out TOut> : IRequest<TOut>
    { }
}

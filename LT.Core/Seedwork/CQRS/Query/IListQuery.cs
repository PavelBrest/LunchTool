using System.Collections.Generic;
using MediatR;

namespace LT.Core.Seedwork.CQRS.Query
{
    public interface IListQuery<out TOut> : IQuery<IReadOnlyList<TOut>>, IRequest<IReadOnlyList<TOut>>
    { }
}

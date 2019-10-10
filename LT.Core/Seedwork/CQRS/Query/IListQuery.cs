using System.Collections.Generic;

namespace LT.Core.Seedwork.CQRS.Query
{
    public interface IListQuery<out TOut> : IQuery<IReadOnlyList<TOut>>, IReadOnlyList<IReadOnlyList<TOut>>
    { }
}

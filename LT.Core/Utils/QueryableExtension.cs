using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LT.Core.Utils
{
    static class QueryableExtension
    {
        public static Task<IReadOnlyList<T>> AsReadOnlyAsync<T>(this IQueryable<T> queryable) =>
            queryable.ToListAsync()
                     .ContinueWith(p => (IReadOnlyList<T>)p.Result);
    }
}

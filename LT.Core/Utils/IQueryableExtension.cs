using LT.Core.Contracts.Places.Views;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LT.Core.Utils
{
    static class IQueryableExtension
    {
        public static Task<IReadOnlyList<PlaceView>> AsReadOnlyAsync(this IQueryable<PlaceView> queryable) =>
            queryable.ToListAsync()
                     .ContinueWith(p => (IReadOnlyList<PlaceView>)p.Result);
    }
}

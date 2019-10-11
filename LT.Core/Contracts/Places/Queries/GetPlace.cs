using System;
using LT.Core.Contracts.Places.Views;
using LT.Core.Seedwork.CQRS.Query;

namespace LT.Core.Contracts.Places.Queries
{
    public class GetPlace : IQuery<PlaceView>
    {
        public GetPlace(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.Orders
{
    public class Order : IHasId<Guid>
    {
        public Guid Id => throw new NotImplementedException();

        object IHasId.Id => throw new NotImplementedException();
    }
}

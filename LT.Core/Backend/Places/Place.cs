using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.Places
{
    public class Place : IHasId<Guid>
    {
        public Guid Id => throw new NotImplementedException();

        object IHasId.Id => throw new NotImplementedException();
    }
}

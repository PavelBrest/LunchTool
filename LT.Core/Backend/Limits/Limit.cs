using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.Limits
{
    public class Limit : IHasId<Guid>
    {
        object IHasId.Id => Id;

        public Guid Id { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Value { get; set; }
    }
}

using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.DishTypes
{
    public class DishType : IHasId<Guid>
    {
        public Guid Id { get; set; }

        object IHasId.Id => Id;

        public string Title { get; set; }
    }
}

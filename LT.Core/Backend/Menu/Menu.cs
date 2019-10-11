using LT.Core.Backend.Dishes;
using LT.Core.Backend.Places;
using LT.Core.Seedwork.Data;
using System;
using System.Collections.Generic;

namespace LT.Core.Backend.Menu
{
    public class Menu : IHasId<Guid>
    {
        public Guid Id { get; set; }

        object IHasId.Id => Id;

        public Guid PlaceId { get; set; }
        public Place Place { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}

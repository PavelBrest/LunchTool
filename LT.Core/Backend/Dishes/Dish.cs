using LT.Core.Backend.DishTypes;
using LT.Core.Seedwork.Data;
using System;

namespace LT.Core.Backend.Dishes
{
    public class Dish : IHasId<Guid>
    {
        public Guid Id { get; set; }

        object IHasId.Id => Id;

        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid DishTypeId { get; set; }
        public DishType DishType { get; set; }

        public Guid MenuId { get; set; }
        public Menu.Menu Menu { get; set; }
    }
}

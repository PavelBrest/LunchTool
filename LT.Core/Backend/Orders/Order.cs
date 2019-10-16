using LT.Core.Seedwork.Data;
using System;
using System.Collections.Generic;

namespace LT.Core.Backend.Orders
{
    public class Order : IHasId<Guid>
    {
        object IHasId.Id => Id;

        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Users.User User { get; set; }

        public Guid PlaceId { get; set; }
        public Places.Place Place { get; set; }

        public ICollection<Dishes.Dish> Dishes { get; set; }

        public DateTime Date { get; set; }
        public decimal OrderCost { get; set; }
        public decimal ResultCost { get; set; }
    }
}

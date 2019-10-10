using System;
using System.Collections.Generic;

namespace LT.Core.Contracts.Menu.Views
{
    public class GetMenuView
    {
        public class DishInfo
        {
            public Guid DishId { get; set; }
            public Guid TypeId { get; set; }

            public string Type { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        public Guid Id { get; set; }

        public ICollection<DishInfo> Dishes { get; set; }
    }
}

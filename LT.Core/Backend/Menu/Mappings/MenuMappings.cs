using AutoMapper;
using LT.Core.Backend.Dishes;
using LT.Core.Contracts.Menu.Commands;
using System.Linq;

namespace LT.Core.Backend.Menu.Mappings
{
    internal class MenuMappings : Profile
    {
        public MenuMappings()
        {
            CreateMap<CreateMenu, Menu>()
                .ForMember(p => p.PlaceId, cfg => cfg.MapFrom(p => p.PlaceId))
                .ForMember(p => p.Dishes, cfg => cfg.MapFrom(p => p.Dishes.Select(SelectDish)));
        }

        private static Dish SelectDish(CreateMenu.DishInfo info)
        {
            return new Dish
            {
                Description = info.Description,
                DishTypeId = info.TypeId,
                Price = info.Price,
                MenuId = info.MenuId,
                Id = info.DishId
            };
        }
    }
}

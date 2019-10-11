using AutoMapper;
using LT.Core.Backend.Dishes;
using LT.Core.Contracts.Menu.Commands;
using LT.Core.Contracts.Menu.Views;
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

            CreateMap<Menu, GetMenuView>()
                .ForMember(p => p.Dishes, 
                           cfg => cfg.MapFrom(p => p.Dishes == null ?
                                  Enumerable.Empty<GetMenuView.DishInfo>() :
                                  p.Dishes.Select(SelectDishInfo)));

        }

        private static GetMenuView.DishInfo SelectDishInfo(Dish dish)
        {
            return new GetMenuView.DishInfo
            {
                DishId = dish.Id,
                TypeId = dish.DishTypeId,
                Type = dish.DishType.Title,
                Description = dish.Description,
                Price = dish.Price
            };
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

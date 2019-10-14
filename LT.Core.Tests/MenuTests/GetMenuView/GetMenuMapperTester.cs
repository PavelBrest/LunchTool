using AutoMapper;
using LT.Core.Backend.Dishes;
using LT.Core.Backend.Menu;
using LT.Core.Backend.Menu.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LT.Core.Tests.MenuTests.GetMenuView
{
    using DishType = Backend.DishTypes.DishType;
    using GetMenuViewDto = Contracts.Menu.Views.GetMenuView;
    using Place = Backend.Places.Place;

    public class GetMenuMapperTester
    {
        private readonly IMapper _mapper;

        public GetMenuMapperTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MenuMappings()));
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_Menu_to_GetMapperView()
        {
            var menuGuid = Guid.NewGuid();
            var menu = new Menu
            {
                Id = menuGuid,
                PlaceId = Guid.NewGuid(),
                Place = new Place()
            };

            var list = new List<Dish>
            {
                new Dish { Id = Guid.NewGuid(), DishTypeId = Guid.NewGuid(), DishType = new DishType { Title = "DTest1" }, Description = "Test1", Price = 0.5M, MenuId = menuGuid, Menu = menu },
                new Dish { Id = Guid.NewGuid(), DishTypeId = Guid.NewGuid(), DishType = new DishType { Title = "DTest1" }, Description = "Test2", Price = 0.4M, MenuId = menuGuid, Menu = menu },
                new Dish { Id = Guid.NewGuid(), DishTypeId = Guid.NewGuid(), DishType = new DishType { Title = "DTest3" }, Description = "Test3", Price = 0.9M, MenuId = menuGuid, Menu = menu },
                new Dish { Id = Guid.NewGuid(), DishTypeId = Guid.NewGuid(), DishType = new DishType { Title = "DTest3" }, Description = "Test4", Price = 0.8M, MenuId = menuGuid, Menu = menu },
                new Dish { Id = Guid.NewGuid(), DishTypeId = Guid.NewGuid(), DishType = new DishType { Title = "DTest3" }, Description = "Test5", Price = 0.7M, MenuId = menuGuid, Menu = menu },
                new Dish { Id = Guid.NewGuid(), DishTypeId = Guid.NewGuid(), DishType = new DishType { Title = "DTest2" }, Description = "Test6", Price = 0.6M, MenuId = menuGuid, Menu = menu }
            };
            menu.Dishes = list.AsReadOnly();

            var dto = _mapper.Map<GetMenuViewDto>(menu);

            Assert.Equal(menu.Id, dto.Id);

            for (int i = 0; i < list.Count; i++)
            {
                var item = dto.Dishes.ElementAt(i);

                Assert.Equal(item.DishId,       list[i].Id);
                Assert.Equal(item.TypeId,       list[i].DishTypeId);
                Assert.Equal(item.Type,         list[i].DishType.Title);
                Assert.Equal(item.Description,  list[i].Description);
                Assert.Equal(item.Price,        list[i].Price);
            }
        }
    }
}

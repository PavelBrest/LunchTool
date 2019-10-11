using AutoMapper;
using LT.Core.Backend.Dishes;
using LT.Core.Backend.DishTypes;
using LT.Core.Backend.Menu;
using LT.Core.Backend.Menu.Handlers;
using LT.Core.Backend.Menu.Mappings;
using LT.Core.Backend.Places;
using LT.Core.Seedwork.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LT.Core.Tests.MenuTests.GetMenu
{
    public class GetMenuHandlerTester
    {
        private readonly Mock<IReadonlyRepository<Menu>> _mockRep;
        private readonly MapperConfiguration _mockMapper;

        public GetMenuHandlerTester()
        {
            _mockRep = new Mock<IReadonlyRepository<Menu>>();
            _mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MenuMappings()));
        }

        //[Fact]
        public void Should_not_have_error_GetMenu_query()
        {
            var guid = Guid.NewGuid();
            _mockRep.Setup(p => p.GetAll()).Returns(GetAllMenu(guid));

            var handler = new MenuQueryHandler(_mockRep.Object, _mockMapper.CreateMapper());
            var query = new Contracts.Menu.Queries.GetMenu { Id = guid };

            var result = handler.Handle(query, default).GetAwaiter().GetResult();


            var dto = GetAllMenu(guid).First();
            var list = dto.Dishes.ToList();

            Assert.Equal(guid, result.Id);

            for (int i = 0; i < list.Count; i++)
            {
                var item = dto.Dishes.ElementAt(i);

                Assert.Equal(item.Id, list[i].Id);
                Assert.Equal(item.DishTypeId, list[i].DishTypeId);
                Assert.Equal(item.DishType.Title, list[i].DishType.Title);
                Assert.Equal(item.MenuId, list[i].MenuId);
                Assert.Equal(item.Menu, list[i].Menu);
                Assert.Equal(item.Description, list[i].Description);
                Assert.Equal(item.Price, list[i].Price);
            }
        }

        private IQueryable<Menu> GetAllMenu(Guid menuGuid)
        {
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

            return new List<Menu> { menu }.AsQueryable();
        }
    }
}

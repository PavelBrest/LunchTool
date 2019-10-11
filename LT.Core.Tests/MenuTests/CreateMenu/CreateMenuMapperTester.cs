using AutoMapper;
using LT.Core.Backend.Menu;
using LT.Core.Backend.Menu.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LT.Core.Tests.MenuTests.CreateMenu
{
    using CreateMenuCommand = Contracts.Menu.Commands.CreateMenu;

    public class CreateMenuMapperTester
    {
        private readonly IMapper _mapper;

        public CreateMenuMapperTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MenuMappings()));
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_CreateMenu_to_Menu()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test2", Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            var entity = _mapper.Map<Menu>(command);

            Assert.Equal(command.Id, entity.Id);
            Assert.Equal(command.PlaceId, entity.PlaceId);
            Assert.NotNull(entity.Dishes);
            Assert.NotEmpty(entity.Dishes);
            Assert.Equal(5, entity.Dishes.Count);

            var actualList = entity.Dishes.ToList();
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(list[i].DishId, actualList[i].Id);
                Assert.Equal(list[i].MenuId, actualList[i].MenuId);
                Assert.Equal(list[i].TypeId, actualList[i].DishTypeId);
                Assert.Equal(list[i].Description, actualList[i].Description);
                Assert.Equal(list[i].Price, actualList[i].Price);
            }
        }
    }
}

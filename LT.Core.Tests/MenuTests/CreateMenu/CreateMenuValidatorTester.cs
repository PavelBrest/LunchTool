using FluentValidation.TestHelper;
using LT.Core.Contracts.Menu.Commands;
using System;
using System.Collections.Generic;
using Xunit;

namespace LT.Core.Tests.MenuTests.CreateMenu
{
    using CreateMenuCommand = Contracts.Menu.Commands.CreateMenu;

    public class CreateMenuValidatorTester
    {
        private CreateMenuValidator _validator;

        public CreateMenuValidatorTester()
        {
            _validator = new CreateMenuValidator();
        }

        [Fact]
        public void Should_not_have_error_Id()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Id, Guid.NewGuid());
        }

        [Fact]
        public void Should_have_error_Id_default()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Id, new Guid());
        }

        [Fact]
        public void Should_not_have_error_PlaceId()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.PlaceId, Guid.NewGuid());
        }

        [Fact]
        public void Should_have_error_PlaceId_default()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.PlaceId, new Guid());
        }

        [Fact]
        public void Should_not_have_error_Dishes()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test2", Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            }.AsReadOnly());
        }

        [Fact]
        public void Should_have_error_Dishes_null()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, default(IReadOnlyCollection<CreateMenuCommand.DishInfo>));
        }

        [Fact]
        public void Should_have_error_Dishes_empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>().AsReadOnly());
        }

        [Fact]
        public void Should_have_error_Dishes_MenuId_default()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = new Guid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test2", Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            }.AsReadOnly());
        }

        [Fact]
        public void Should_have_error_Dishes_DishId_default()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = new Guid(), TypeId = Guid.NewGuid(), Description = "Test2", Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            }.AsReadOnly());
        }

        [Fact]
        public void Should_have_error_Dishes_TypeId_default()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = new Guid(), Description = "Test2", Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            }.AsReadOnly());
        }

        [Fact]
        public void Should_have_error_Dishes_Description_empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = string.Empty, Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            }.AsReadOnly());
        }

        [Fact]
        public void Should_have_error_Dishes_Description_null()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Dishes, new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = null, Price = 0.85M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test3", Price = 0.14M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test4", Price = 0.0M },
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test5", Price = 0.15M }
            }.AsReadOnly());
        }
    }
}

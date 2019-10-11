using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Menu;
using LT.Core.Backend.Menu.Handlers;
using LT.Core.Backend.Menu.Mappings;
using LT.Core.Contracts.Menu.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace LT.Core.Tests.MenuTests.CreateMenu
{
    using CreateMenuCommand = Contracts.Menu.Commands.CreateMenu;

    public class CreateMenuHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Menu>> _mockRepository;

        public CreateMenuHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MenuMappings()));

            _mapper = mockMapper.CreateMapper();
            _mockRepository = new Mock<IRepository<Menu>>();
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorCreateMenu()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await validateDecor.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Id_default()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = new Guid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_PlaceId_default()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = default,
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_Null()
        {
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = null
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_empty()
        {
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = new List<CreateMenuCommand.DishInfo>().AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_DishId_default()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = default, TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_MenuId_default()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = default, DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_TypeId_default()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = default, Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_Description_null()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = null, Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_Description_empty()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = string.Empty, Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_Dishes_Description_whiteSpace()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = " ", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).ReturnsAsync(new Menu());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));


            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }


        [Fact]
        public async void Should_not_have_error_HandleCreateMenu()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>()));

            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);

            await handler.Handle(command, default);
        }

        [Fact]
        public async void Should_have_error_HandleCreateMenu_ORM_Exception()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };

            
            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).Throws(new Exception());

            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorCreateMenu_ORM_Exception()
        {
            var list = new List<CreateMenuCommand.DishInfo>
            {
                new CreateMenuCommand.DishInfo { MenuId = Guid.NewGuid(), DishId = Guid.NewGuid(), TypeId = Guid.NewGuid(), Description = "Test1", Price = 0.15M }
            };
            var command = new CreateMenuCommand
            {
                Id = Guid.NewGuid(),
                PlaceId = Guid.NewGuid(),
                Dishes = list.AsReadOnly()
            };


            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Menu>())).Throws(new Exception());

            var validateDecor = new ValidateRequestDecorator<CreateMenuCommand, Unit>(new CreateMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(command, default, @delegate));
        }
    }
}

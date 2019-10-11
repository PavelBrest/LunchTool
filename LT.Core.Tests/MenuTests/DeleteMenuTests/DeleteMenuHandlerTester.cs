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
using Xunit;

namespace LT.Core.Tests.MenuTests.DeleteMenuTests
{
    public class DeleteMenuHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Menu>> _mockRepository;

        public DeleteMenuHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MenuMappings()));

            _mapper = mockMapper.CreateMapper();
            _mockRepository = new Mock<IRepository<Menu>>();
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorDeleteMenu()
        {
            var command = new DeleteMenu
            {
                Id = Guid.NewGuid()
            };

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var validateDecor = new ValidateRequestDecorator<DeleteMenu, Unit>(new DeleteMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await validateDecor.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorDeleteMenu_Id_default()
        {
            var command = new DeleteMenu
            {
                Id = default
            };

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var validateDecor = new ValidateRequestDecorator<DeleteMenu, Unit>(new DeleteMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_not_have_error_DeleteMenuHandler()
        {
            var command = new DeleteMenu
            {
                Id = Guid.NewGuid()
            };

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);

            await handler.Handle(command, default);
        }

        [Fact]
        public async void Should_have_error_DeleteMenuHandler_ORM_exception()
        {
            var command = new DeleteMenu
            {
                Id = Guid.NewGuid()
            };

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Guid>())).Throws(new Exception());

            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorDeleteMenu_ORM_exception()
        {
            var command = new DeleteMenu
            {
                Id = Guid.NewGuid()
            };

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Guid>())).Throws(new Exception());

            var validateDecor = new ValidateRequestDecorator<DeleteMenu, Unit>(new DeleteMenuValidator());
            var handler = new MenuCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(command, default, @delegate));
        }
    }
}

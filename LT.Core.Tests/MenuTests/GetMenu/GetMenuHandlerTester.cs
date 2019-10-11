using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Menu;
using LT.Core.Backend.Menu.Handlers;
using LT.Core.Backend.Menu.Mappings;
using LT.Core.Contracts.Menu.Queries;
using LT.Core.Seedwork.Data;
using MediatR;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LT.Core.Tests.MenuTests.GetMenuTests
{
    using GetMenuView = Contracts.Menu.Views.GetMenuView;

    public class GetMenuHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReadonlyRepository<Menu>> _mockRepository;

        public GetMenuHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MenuMappings()));

            _mapper = mockMapper.CreateMapper();
            _mockRepository = new Mock<IReadonlyRepository<Menu>>();
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorGetMenu()
        {
            var command = new GetMenu { Id = Guid.NewGuid() };
            var list = new List<Menu> { new Menu { Id = command.Id } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<GetMenu, GetMenuView>(new GetMenuValidator());
            var handler = new MenuQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetMenuView>(() => handler.Handle(command, default));

            await validateDecor.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorGetMenu_Id_default()
        {
            var command = new GetMenu { Id = default };
            var list = new List<Menu> { new Menu { Id = command.Id } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<GetMenu, GetMenuView>(new GetMenuValidator());
            var handler = new MenuQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetMenuView>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_not_have_error_GetMenuHandler()
        {
            var command = new GetMenu { Id = Guid.NewGuid() };
            var list = new List<Menu> { new Menu { Id = command.Id } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Returns(mock.Object);

            var handler = new MenuQueryHandler(_mockRepository.Object, _mapper);

            await handler.Handle(command, default);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorGetMenu_ORM_Exception()
        {
            var command = new GetMenu { Id = Guid.NewGuid() };
            var list = new List<Menu> { new Menu { Id = command.Id } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Throws<Exception>();

            var validateDecor = new ValidateRequestDecorator<GetMenu, GetMenuView>(new GetMenuValidator());
            var handler = new MenuQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetMenuView>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_GetMenuHandler_ORM_Exception()
        {
            var command = new GetMenu { Id = Guid.NewGuid() };
            var list = new List<Menu> { new Menu { Id = command.Id } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Throws<Exception>();

            var handler = new MenuQueryHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }
    }
}
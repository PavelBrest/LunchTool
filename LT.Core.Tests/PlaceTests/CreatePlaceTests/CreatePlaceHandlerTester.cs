using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Places;
using LT.Core.Backend.Places.Handlers;
using LT.Core.Backend.Places.Mappings;
using LT.Core.Contracts.Places.Commands;
using LT.Core.Seedwork.CQRS.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using Moq;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.CreatePlaceTests
{
    public class CreatePlaceHandlerTester
    {
        private readonly IMapper _mapper;

        private readonly Mock<IRepository<Place>> _mockRepository;

        private readonly IPipelineBehavior<CreatePlace, Unit> _validateDecorator;

        private readonly ICommandHandler<CreatePlace> _handler;


        public CreatePlaceHandlerTester()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlaceMappings())).CreateMapper();

            _mockRepository = new Mock<IRepository<Place>>();
            _mockRepository.Setup(p => p.AddAsync(It.IsAny<Place>()));

            _validateDecorator = new ValidateRequestDecorator<CreatePlace, Unit>(new CreatePlaceValidator());

            _handler = new PlaceCommandsHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecoratorCreatePlace()
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+375331111111",
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await _validateDecorator.Handle(request, default, @delegate);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecoratorCreatePlace_Comment()
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+375331111111",
                comment: default,
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await _validateDecorator.Handle(request, default, @delegate);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecoratorCreatePlace_PhoneNumber()
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: default,
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await _validateDecorator.Handle(request, default, @delegate);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecoratorCreatePlace_ServeTime()
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+375331111111",
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: default,
                endServeTime: default);

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await _validateDecorator.Handle(request, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecoratorCreatePlace_Id()
        {
            var request = new CreatePlace(
                id: default,
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+375331111111",
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(request, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ValidateDecoratorCreatePlace_OrderDeadline()
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+375331111111",
                comment: "Test comment",
                orderDeadline: default,
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(request, default, @delegate));
        }

        [Theory]
        [InlineData(default)]
        [InlineData("")]
        [InlineData(" ")]
        public async void Should_have_error_ValidateDecoratorCreatePlace_Name(string name)
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: name,
                address: "Test address",
                phoneNumber: "+375331111111",
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(request, default, @delegate));
        }

        [Theory]
        [InlineData(default)]
        [InlineData("")]
        [InlineData(" ")]
        public async void Should_have_error_ValidateDecoratorCreatePlace_Address(string address)
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: address,
                phoneNumber: "+375331111111",
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(request, default, @delegate));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123456789012")]
        [InlineData("+123456789012")]
        [InlineData("+375456789012")]
        [InlineData("+37533123456")]
        [InlineData("+3752912345678")]
        public async void Should_have_error_ValidateDecoratorCreatePlace_PhoneNumber(string phoneNumber)
        {
            var request = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: phoneNumber,
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(request, default, @delegate));
        }
    }
}

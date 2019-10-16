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

namespace LT.Core.Tests.PlaceTests.DeletePlaceTests
{
    public class DeletePlaceHandlerTester
    {
        private readonly IMapper _mapper;

        private readonly Mock<IRepository<Place>> _mockRepository;

        private readonly IPipelineBehavior<DeletePlace, Unit> _validateDecorator;

        private readonly ICommandHandler<DeletePlace> _handler;

        public DeletePlaceHandlerTester()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlaceMappings())).CreateMapper();

            _mockRepository = new Mock<IRepository<Place>>();
            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Place>()));

            _validateDecorator = new ValidateRequestDecorator<DeletePlace, Unit>(new DeletePlaceValidator());

            _handler = new PlaceCommandsHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecoratorDeletePlace()
        {
            var request = new DeletePlace(
                id: Guid.NewGuid());

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await _validateDecorator.Handle(request, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecoratorDeletePlace_Id_default()
        {
            var request = new DeletePlace(
                id: new Guid());

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(request, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_DeletePlaceHandler_ORM_Exception()
        {
            var request = new DeletePlace(
                id: Guid.NewGuid());

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Place>())).Throws<Exception>();

            var handler = new PlaceCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecoratorDeletePlace_ORM_Exception()
        {
            var request = new DeletePlace(
                id: Guid.NewGuid());

            _mockRepository.Setup(p => p.DeleteAsync(It.IsAny<Place>())).Throws<Exception>();

            var handler = new PlaceCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(request, default));

            await Assert.ThrowsAsync<Exception>(() => _validateDecorator.Handle(request, default, @delegate));
        }
    }
}

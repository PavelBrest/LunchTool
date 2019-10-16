using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Places;
using LT.Core.Backend.Places.Handlers;
using LT.Core.Backend.Places.Mappings;
using LT.Core.Contracts.Places.Queries;
using LT.Core.Contracts.Places.Views;
using LT.Core.Seedwork.CQRS.Query;
using LT.Core.Seedwork.Data;
using MediatR;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LT.Core.Tests.PlaceTests.GetPlaceTests
{
    public class GetPlaceHandlerTester
    {
        private readonly IMapper _mapper;

        private readonly Mock<IReadonlyRepository<Place>> _mockRepository;

        private readonly IPipelineBehavior<GetPlace, PlaceView> _validateDecorator;

        private IQueryHandler<GetPlace, PlaceView> _handler;

        public GetPlaceHandlerTester()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlaceMappings())).CreateMapper();

            _mockRepository = new Mock<IReadonlyRepository<Place>>();

            _validateDecorator = new ValidateRequestDecorator<GetPlace, PlaceView>(new GetPlaceValidator());
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecoratorGetPlace()
        {
            var query = new GetPlace { Id = Guid.NewGuid() };

            var repo = new List<Place> { new Place(id: query.Id,
                                                   name: "Test Name",
                                                   address: "Test address",
                                                   phoneNumber: "+375331111111",
                                                   comment: "Test comment",
                                                   orderDeadline: new DateTime(111111),
                                                   startServeTime: new DateTime(222222),
                                                   endServeTime: new DateTime(333333)) };

            _mockRepository.Setup(p => p.GetAll())
                .Returns(repo.AsQueryable().BuildMock().Object);

            _handler = new PlaceQueriesHandler(_mockRepository.Object, _mapper);

            var @delegate = new RequestHandlerDelegate<PlaceView>(() => _handler.Handle(query, default));

            await _validateDecorator.Handle(query, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecoratorGetPlace_Id_default()
        {
            var query = new GetPlace { Id = default };

            var repo = new List<Place> { new Place { Name= "Test Name",
                                                     Address= "Test address",
                                                     PhoneNumber= "+375331111111",
                                                     Comment= "Test comment",
                                                     OrderDeadline= new DateTime(111111),
                                                     StartServeTime= new DateTime(222222),
                                                     EndServeTime= new DateTime(333333) } };

            _mockRepository.Setup(p => p.GetAll())
                .Returns(repo.AsQueryable().BuildMock().Object);

            _handler = new PlaceQueriesHandler(_mockRepository.Object, _mapper);

            var @delegate = new RequestHandlerDelegate<PlaceView>(() => _handler.Handle(query, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(query, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_GetPlaceHandler_ORM_Exception()
        {
            var query = new GetPlace { Id = Guid.NewGuid() };

            var repo = new List<Place> { new Place { Name= "Test Name",
                                                     Address= "Test address",
                                                     PhoneNumber= "+375331111111",
                                                     Comment= "Test comment",
                                                     OrderDeadline= new DateTime(111111),
                                                     StartServeTime= new DateTime(222222),
                                                     EndServeTime= new DateTime(333333) } };

            _mockRepository.Setup(p => p.GetAll())
                .Throws<Exception>();

            var handler = new PlaceQueriesHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, default));
        }

        [Fact]
        public async void Should_have_error_ValidateGetPlace_ORM_Exception()
        {
            var query = new GetPlace { Id = Guid.NewGuid() };

            var repo = new List<Place> { new Place { Name= "Test Name",
                                                     Address= "Test address",
                                                     PhoneNumber= "+375331111111",
                                                     Comment= "Test comment",
                                                     OrderDeadline= new DateTime(111111),
                                                     StartServeTime= new DateTime(222222),
                                                     EndServeTime= new DateTime(333333) } };

            _mockRepository.Setup(p => p.GetAll())
                .Throws<Exception>();

            var handler = new PlaceQueriesHandler(_mockRepository.Object, _mapper);

            var @delegate = new RequestHandlerDelegate<PlaceView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<Exception>(() => _validateDecorator.Handle(query, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_GetPlaceHandler_NotFound_Exception()
        {
            var query = new GetPlace { Id = Guid.NewGuid() };

            var repo = new List<Place> { new Place { Id = Guid.NewGuid(),
                                                     Name= "Test Name",
                                                     Address= "Test address",
                                                     PhoneNumber= "+375331111111",
                                                     Comment= "Test comment",
                                                     OrderDeadline= new DateTime(111111),
                                                     StartServeTime= new DateTime(222222),
                                                     EndServeTime= new DateTime(333333) } };

            _mockRepository.Setup(p => p.GetAll())
                .Returns(repo.AsQueryable().BuildMock().Object);

            var handler = new PlaceQueriesHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, default));
        }

        [Fact]
        public async void Should_have_error_ValidateGetPlace_NotFound_Exception()
        {
            var query = new GetPlace { Id = Guid.NewGuid() };

            var repo = new List<Place> { new Place { Id = Guid.NewGuid(),
                                                     Name= "Test Name",
                                                     Address= "Test address",
                                                     PhoneNumber= "+375331111111",
                                                     Comment= "Test comment",
                                                     OrderDeadline= new DateTime(111111),
                                                     StartServeTime= new DateTime(222222),
                                                     EndServeTime= new DateTime(333333) } };

            _mockRepository.Setup(p => p.GetAll())
                .Returns(repo.AsQueryable().BuildMock().Object);

            var handler = new PlaceQueriesHandler(_mockRepository.Object, _mapper);

            var @delegate = new RequestHandlerDelegate<PlaceView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<Exception>(() => _validateDecorator.Handle(query, default, @delegate));
        }
    }
}

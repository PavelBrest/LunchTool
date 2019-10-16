using AutoMapper;
using LT.Core.Backend.Places;
using LT.Core.Backend.Places.Mappings;
using LT.Core.Contracts.Places.Views;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.GetPlaceTests
{
    public class GetPlaceMapperTester
    {
        private readonly IMapper _mapper;

        public GetPlaceMapperTester()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlaceMappings())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_Place_to_PlaceView()
        {
            var source = new Place(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+123456789",
                comment: "Test comment",
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var destination = _mapper.Map<PlaceView>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Address, destination.Address);
            Assert.Equal(source.PhoneNumber, destination.PhoneNumber);
            Assert.Equal(source.Comment, destination.Comment);
            Assert.Equal(source.OrderDeadline, destination.OrderDeadline);
            Assert.Equal(source.StartServeTime, destination.StartServeTime);
            Assert.Equal(source.EndServeTime, destination.EndServeTime);
        }

        [Fact]
        public void Should_not_have_error_Place_to_PlaceView_NullProperty()
        {
            var source = new Place(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+123456789",
                comment: null,
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var destination = _mapper.Map<PlaceView>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Address, destination.Address);
            Assert.Equal(source.PhoneNumber, destination.PhoneNumber);
            Assert.Equal(source.Comment, destination.Comment);
            Assert.Equal(source.OrderDeadline, destination.OrderDeadline);
            Assert.Equal(source.StartServeTime, destination.StartServeTime);
            Assert.Equal(source.EndServeTime, destination.EndServeTime);
        }
    }
}

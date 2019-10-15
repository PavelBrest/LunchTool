using AutoMapper;
using LT.Core.Backend.Places;
using LT.Core.Backend.Places.Mappings;
using LT.Core.Contracts.Places.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.CreatePlaceTests
{
    public class CreatePlaceMapperTester
    {
        private readonly IMapper _mapper;

        public CreatePlaceMapperTester()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlaceMappings())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_CreatePlace_to_Place()
        {
            var source = new CreatePlace(
                id: Guid.NewGuid(), 
                name: "Test Name", 
                address: "Test address", 
                phoneNumber:"+123456789",
                comment: "Test comment", 
                orderDeadline: new DateTime(111111), 
                startServeTime: new DateTime(222222), 
                endServeTime: new DateTime(333333));

            var destination = _mapper.Map<Place>(source);

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
        public void Should_not_have_error_CreatePlace_to_Place_NullProperty()
        {
            var source = new CreatePlace(
                id: Guid.NewGuid(),
                name: "Test Name",
                address: "Test address",
                phoneNumber: "+123456789",
                comment: null,
                orderDeadline: new DateTime(111111),
                startServeTime: new DateTime(222222),
                endServeTime: new DateTime(333333));

            var destination = _mapper.Map<Place>(source);

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

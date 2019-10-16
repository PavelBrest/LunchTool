using AutoMapper;
using LT.Core.Backend.Places;
using LT.Core.Backend.Places.Mappings;
using LT.Core.Contracts.Places.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.DeletePlaceTests
{
    public class DeletePlaceMapperTester
    {
        private readonly IMapper _mapper;

        public DeletePlaceMapperTester()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PlaceMappings())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_DeletePlace_to_Place()
        {
            var source = new DeletePlace(
                id: Guid.NewGuid());

            var destination = _mapper.Map<Place>(source);

            Assert.Equal(source.Id, destination.Id);
        }

        [Fact]
        public void Should_not_have_error_DeletePlace_to_Place_NullProperty()
        {
            var source = new DeletePlace(
                id: new Guid());

            var destination = _mapper.Map<Place>(source);

            Assert.Equal(source.Id, destination.Id);
        }
    }
}

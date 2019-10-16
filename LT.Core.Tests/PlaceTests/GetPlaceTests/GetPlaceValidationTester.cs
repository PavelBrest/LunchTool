using FluentValidation.TestHelper;
using LT.Core.Contracts.Places.Queries;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.GetPlaceTests
{
    public class GetPlaceValidationTester
    {
        private readonly GetPlaceValidator _validator;

        public GetPlaceValidationTester()
        {
            _validator = new GetPlaceValidator();
        }

        [Fact]
        public void Should_not_have_error_Id()
        {
            Guid id = Guid.NewGuid();
            _validator.ShouldNotHaveValidationErrorFor(p => p.Id, id);
        }

        [Fact]
        public void Should_have_error_Id_default()
        {
            Guid id = default;
            _validator.ShouldHaveValidationErrorFor(p => p.Id, id);
        }
    }
}

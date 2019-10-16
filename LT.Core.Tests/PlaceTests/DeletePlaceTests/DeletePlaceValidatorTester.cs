using FluentValidation.TestHelper;
using LT.Core.Contracts.Places.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.PlaceTests.DeletePlaceTests
{
    public class DeletePlaceValidatorTester
    {
        private readonly DeletePlaceValidator _validator;

        public DeletePlaceValidatorTester()
        {
            _validator = new DeletePlaceValidator();
        }

        [Fact]
        public void Should_not_have_error_Id()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Id, Guid.NewGuid());
        }

        [Fact]
        public void Should_have_error_Id_default()
        {
            Guid id = default;
            _validator.ShouldHaveValidationErrorFor(p => p.Id, id);
        }
    }
}

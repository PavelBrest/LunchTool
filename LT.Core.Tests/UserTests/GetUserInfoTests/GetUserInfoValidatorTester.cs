using FluentValidation.TestHelper;
using LT.Core.Contracts.User.Queries;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.GetUserInfoTests
{
    public class GetUserInfoValidatorTester
    {
        private readonly GetUserInfoValidator _validator;

        public GetUserInfoValidatorTester()
        {
            _validator = new GetUserInfoValidator();
        }

        [Fact]
        public void Should_not_have_error_Id()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Id, Guid.NewGuid());
        }

        [Fact]
        public void Should_have_error_Id_default()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Id, new Guid());
        }
    }
}

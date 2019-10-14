using FluentValidation.TestHelper;
using LT.Core.Contracts.User.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.ChangeUserNameTests
{
    public class ChangeUserNameValidatorTester
    {
        private readonly ChangeUserNameValidator _validator;

        public ChangeUserNameValidatorTester()
        {
            _validator = new ChangeUserNameValidator();
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

        [Fact]
        public void Should_not_have_error_Name()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Name, "testName");
        }

        [Fact]
        public void Should_have_error_Name_null()
        {
            string value = null;
            _validator.ShouldHaveValidationErrorFor(p => p.Name, value);
        }

        [Fact]
        public void Should_have_error_Name_empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Name, string.Empty);
        }

        [Fact]
        public void Should_have_error_Name_whiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Name, " ");
        }
    }
}

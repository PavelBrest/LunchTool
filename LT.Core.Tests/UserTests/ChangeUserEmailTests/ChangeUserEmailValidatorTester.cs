using FluentValidation.TestHelper;
using LT.Core.Contracts.User.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.ChangeUserEmailTests
{
    public class ChangeUserEmailValidatorTester
    {
        private readonly ChangeUserEmailValidator _validator;

        public ChangeUserEmailValidatorTester()
        {
            _validator = new ChangeUserEmailValidator();
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
        public void Should_not_have_error_Email()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.EmailAddress, "1@gmail.com");
        }

        [Fact]
        public void Should_have_error_Email_null()
        {
            string value = null;
            _validator.ShouldHaveValidationErrorFor(p => p.EmailAddress, value);
        }

        [Fact]
        public void Should_have_error_Email_empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.EmailAddress, string.Empty);
        }

        [Fact]
        public void Should_have_error_Email_whiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.EmailAddress, " ");
        }

        [Fact]
        public void Should_have_error_Email_withoutDomain()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.EmailAddress, "123");
        }

        [Fact]
        public void Should_have_error_Email_invalidDomain()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.EmailAddress, "123@");
        }
    }
}

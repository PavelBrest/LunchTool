using FluentValidation.TestHelper;
using LT.Core.Contracts.User.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.ChangeUserSurnameTests
{

    public class ChangeUserSurnameValidatorTester
    {
        private readonly ChangeUserSurnameValidator _validator;

        public ChangeUserSurnameValidatorTester()
        {
            _validator = new ChangeUserSurnameValidator();
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
        public void Should_not_have_error_Surname()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Surname, "testSurname");
        }

        [Fact]
        public void Should_have_error_Surname_null()
        {
            string value = null;
            _validator.ShouldHaveValidationErrorFor(p => p.Surname, value);
        }

        [Fact]
        public void Should_have_error_Surname_empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Surname, string.Empty);
        }

        [Fact]
        public void Should_have_error_Surname_whiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Surname, " ");
        }
    }
}

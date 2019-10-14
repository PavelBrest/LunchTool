using FluentValidation.TestHelper;
using LT.Core.Contracts.User.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.ChangeUserPasswordTests
{

    public class ChangeUserPasswordValidatorTester
    {
        private readonly ChangeUserPasswordValidator _validator;

        public ChangeUserPasswordValidatorTester()
        {
            _validator = new ChangeUserPasswordValidator();
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
        public void Should_not_have_error_OldPassword_Length6()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.OldPassword, "asdDS2");
        }

        [Fact]
        public void Should_not_have_error_OldPassword_Length16()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.OldPassword, "123456D91aDF4567");
        }

        [Fact]
        public void Should_not_have_error_OldPassword_Length25()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.OldPassword, "1234a67SGR234567191234567");
        }

        [Fact]
        public void Should_have_error_OldPassword_passwordsEquals()
        {
            var command = new ChangeUserPassword
            {
                Id = Guid.NewGuid(),
                OldPassword = "123456D91aDF4567",
                NewPassword = "123456D91aDF4567"
            };

            var result = _validator.Validate(command);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Should_have_error_OldPassword_Null()
        {
            string pass = null;
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, pass);
        }

        [Fact]
        public void Should_have_error_NewPassword_Null()
        {
            string pass = null;
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, pass);
        }

        [Fact]
        public void Should_have_error_OldPassword_Empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, string.Empty);
        }

        [Fact]
        public void Should_have_error_NewPassword_Empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, string.Empty);
        }

        [Fact]
        public void Should_have_error_OldPassword_WhiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, " ");
        }

        [Fact]
        public void Should_have_error_NewPassword_WhiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, " ");
        }

        [Fact]
        public void Should_have_error_OldPassword_LengthLessThen6()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, "1ASd5");
        }

        [Fact]
        public void Should_have_error_NewPassword_LengthLessThen6()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, "1ASd5");
        }

        [Fact]
        public void Should_have_error_OldPassword_LengthMoreThen25()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, "123456789123JG67aaa2345674");
        }

        [Fact]
        public void Should_have_error_NewPassword_LengthMoreThen25()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, "123456789123JG67aaa2345674");
        }

        [Fact]
        public void Should_have_error_OldPassword_Invalid_AllLowerCase()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, "123456789123sd67aaa2");
        }

        [Fact]
        public void Should_have_error_NewPassword_Invalid_AllLowerCase()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, "123456789123sd67aaa2");
        }

        [Fact]
        public void Should_have_error_OldPassword_Invalid_AllDigits()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, "123456789123346723");
        }

        [Fact]
        public void Should_have_error_NewPassword_Invalid_AllDigits()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, "123456789123346723");
        }

        [Fact]
        public void Should_have_error_OldPassword_Invalid_AllUpper()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.OldPassword, "12345678JFYR34HG23");
        }

        [Fact]
        public void Should_have_error_NewPassword_Invalid_AllUpper()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.NewPassword, "12345678JFYR34HG23");
        }
    }
}

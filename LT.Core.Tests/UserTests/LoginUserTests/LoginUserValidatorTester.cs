using FluentValidation.TestHelper;
using LT.Core.Contracts.User.Queries;
using Xunit;

namespace LT.Core.Tests.UserTests.LoginUserTests
{
    public class LoginUserValidatorTester
    {
        private readonly LoginUserValidator _validator;

        public LoginUserValidatorTester()
        {
            _validator = new LoginUserValidator();
        }

        [Fact]
        public void Should_not_have_error_Login()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Login, "test");
        }

        [Fact]
        public void Should_have_error_Login_Null()
        {
            string login = null;
            _validator.ShouldHaveValidationErrorFor(p => p.Login, login);
        }

        [Fact]
        public void Should_have_error_Login_Empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Login, string.Empty);
        }

        [Fact]
        public void Should_have_error_Login_WhiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Login, " ");
        }

        [Fact]
        public void Should_have_error_Login_LenghtMoreThen4()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Login, "testt");
        }

        [Fact]
        public void Should_have_error_Login_LenghtLessThen4()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Login, "tes");
        }
       
        [Fact]
        public void Should_not_have_error_Password_Length6()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Password, "123456");
        }

        [Fact]
        public void Should_not_have_error_Password_Length16()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Password, "1234567891234567");
        }

        [Fact]
        public void Should_not_have_error_Password_Length25()
        {
            _validator.ShouldNotHaveValidationErrorFor(p => p.Password, "1234567891234567891234567");
        }

        [Fact]
        public void Should_have_error_Password_Null()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(p => p.Password, name);
        }

        [Fact]
        public void Should_have_error_Password_Empty()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Password, string.Empty);
        }

        [Fact]
        public void Should_have_error_Password_WhiteSpace()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Password, " ");
        }

        [Fact]
        public void Should_have_error_Password_LengthLessThen6()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Password, "12345");
        }

        [Fact]
        public void Should_have_error_Password_LengthMoreThen25()
        {
            _validator.ShouldHaveValidationErrorFor(p => p.Password, "12345678912345678912345674");
        }
    }
}

using FluentValidation.TestHelper;
using LT.Core.Contracts.Places.Commands;
using System;
using System.Collections.Generic;
using Xunit;

namespace LT.Core.Tests.PlaceTests.CreatePlaceTests
{
    public class CreatePlaceValidatorTester
    {
        private readonly CreatePlaceValidator _validator;

        public CreatePlaceValidatorTester()
        {
            _validator = new CreatePlaceValidator();
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
            string name = "Test";
            _validator.ShouldNotHaveValidationErrorFor(p => p.Name, name);
        }

        [Fact]
        public void Should_have_error_Name_default()
        {
            string name = null;
            _validator.ShouldHaveValidationErrorFor(p => p.Name, name);
        }

        [Fact]
        public void Should_have_error_Name_Empty()
        {
            string name = "";
            _validator.ShouldHaveValidationErrorFor(p => p.Name, name);
        }

        [Fact]
        public void Should_have_error_Name_WhiteSpace()
        {
            string name = " ";
            _validator.ShouldHaveValidationErrorFor(p => p.Name, name);
        }

        [Fact]
        public void Should_not_have_error_Address()
        {
            string address = "Test address";
            _validator.ShouldNotHaveValidationErrorFor(p => p.Address, address);
        }

        [Fact]
        public void Should_have_error_Address_default()
        {
            string address = null;
            _validator.ShouldHaveValidationErrorFor(p => p.Address, address);
        }

        [Fact]
        public void Should_have_error_Address_Empty()
        {
            string address = "";
            _validator.ShouldHaveValidationErrorFor(p => p.Address, address);
        }

        [Fact]
        public void Should_have_error_Address_WhiteSpace()
        {
            string address = " ";
            _validator.ShouldHaveValidationErrorFor(p => p.Address, address);
        }

        [Fact]
        public void Should_not_have_error_Comment()
        {
            string comment = "Test address";
            _validator.ShouldNotHaveValidationErrorFor(p => p.Comment, comment);
        }

        [Fact]
        public void Should_not_have_error_Comment_default()
        {
            string comment = null;
            _validator.ShouldNotHaveValidationErrorFor(p => p.Comment, comment);
        }

        [Fact]
        public void Should_not_have_error_PhoneNumber()
        {
            string phoneNumber = "+375251234567";
            _validator.ShouldNotHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_not_have_error_PhoneNumber_default()
        {
            string phoneNumber = null;
            _validator.ShouldNotHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_Empty()
        {
            string phoneNumber = "";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_WhiteSpace()
        {
            string phoneNumber = " ";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_NotInternationalFormat()
        {
            string phoneNumber = "375251234567";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_NotBelarusCountryCode()
        {
            string phoneNumber = "+380251234567";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_WrongBelarusOperatorMobilePrefix()
        {
            string phoneNumber = "+375241234567";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_WrongBelarusOperatorNSNSize8()
        {
            string phoneNumber = "+37525123456";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_have_error_PhoneNumber_WrongBelarusOperatorNSNSize10()
        {
            string phoneNumber = "+3752512345678";
            _validator.ShouldHaveValidationErrorFor(p => p.PhoneNumber, phoneNumber);
        }

        [Fact]
        public void Should_not_have_error_OrderDeadline()
        {
            DateTime orderDeadline = new DateTime(2019, 1, 1, 1, 1, 1);
            _validator.ShouldNotHaveValidationErrorFor(p => p.OrderDeadline, orderDeadline);
        }

        [Fact]
        public void Should_have_error_OrderDeadline_default()
        {
            DateTime orderDeadline = new DateTime();
            _validator.ShouldHaveValidationErrorFor(p => p.OrderDeadline, orderDeadline);
        }

        [Fact]
        public void Should_not_have_error_StartServeTime()
        {
            DateTime startServeTime = new DateTime(2019, 1, 1, 1, 1, 1);
            _validator.ShouldNotHaveValidationErrorFor(p => p.StartServeTime, startServeTime);
        }

        [Fact]
        public void Should_not_have_error_StartServeTime_default()
        {
            DateTime startServeTime = new DateTime();
            _validator.ShouldNotHaveValidationErrorFor(p => p.StartServeTime, startServeTime);
        }

        [Fact]
        public void Should_not_have_error_EndServeTime()
        {
            DateTime endServeTime = new DateTime(2019, 1, 1, 1, 1, 1);
            _validator.ShouldNotHaveValidationErrorFor(p => p.EndServeTime, endServeTime);
        }

        [Fact]
        public void Should_not_have_error_EndServeTime_default()
        {
            DateTime endServeTime = new DateTime();
            _validator.ShouldNotHaveValidationErrorFor(p => p.EndServeTime, endServeTime);
        }
    }
}

using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Handlers;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LT.Core.Tests.UserTests.RegisterUserTests
{
    public class RegisterUserHadlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<User>> _mockRepository;

        public RegisterUserHadlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));

            _mapper = mockMapper.CreateMapper();
            _mockRepository = new Mock<IRepository<User>>();
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorRegisterUser()
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "asdfgAsd46342GG",
                Name = "testname",
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()));

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await validateDecor.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorRegisterUser_Id_default()
        {
            var command = new RegisterUser
            {
                Id = default,
                Login = "test",
                Password = "asdfgAsd46342GG",
                Name = "testname",
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()));

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("tes")]
        [InlineData("testt")]
        public async void Should_have_error_ValidateDecorRegisterUser_Login(string login)
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = "asdfgAsd46342GG",
                Name = "testname",
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()));

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void Should_have_error_ValidateDecorRegisterUser_Name(string name)
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "asdfgAsd46342GG",
                Name = name,
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()));

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("hh")]
        [InlineData("@gmail.com")]
        public async void Should_have_error_ValidateDecorRegisterUser_Email(string email)
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "asdfgAsd46342GG",
                Name = "testname",
                EmailAddress = email
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()));

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("asdr")]
        [InlineData("asdasdasdasdasdasdtretrerterwer")]
        [InlineData("fhydrfhfki2156")]
        [InlineData("fhyD rfhfki2156")]
        public async void Should_have_error_ValidateDecorRegisterUser_Password(string pass)
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = pass,
                Name = "testname",
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()));

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_RegisterUserHandler_ORM_Exception()
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "asdfgAsd46342GG",
                Name = "testname",
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()))
                           .Throws<Exception>();

            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorRegisterUser_ORM_Exception()
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "asdfgAsd46342GG",
                Name = "testname",
                EmailAddress = "1@gmail.com"
            };

            _mockRepository.Setup(p => p.AddAsync(It.IsAny<User>()))
                           .Throws<Exception>();

            var validateDecor = new ValidateRequestDecorator<RegisterUser, Unit>(new RegisterUserValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(command, default, @delegate));
        }
    }
}

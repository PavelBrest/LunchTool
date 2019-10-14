using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Handlers;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Queries;
using LT.Core.Contracts.User.Views;
using LT.Core.Seedwork.Data;
using MediatR;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LT.Core.Tests.UserTests.LoginUserTests
{
    public class LoginUserHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReadonlyRepository<User>> _mockRepository;

        public LoginUserHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));

            _mapper = mockMapper.CreateMapper();
            _mockRepository = new Mock<IReadonlyRepository<User>>();
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorLoginUser()
        {
            var query = new LoginUser
            {
                Login = "test",
                Password = "asdfgAsd46342GG"
            };
            var list = new List<User> { new User {Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<LoginUser, LoginUserView>(new LoginUserValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<LoginUserView>(() => handler.Handle(query, default));

            await validateDecor.Handle(query, default, @delegate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("tes")]
        [InlineData("testt")]
        public async void Should_have_error_ValidateDecorLoginUser_Login(string login)
        {
            var query = new LoginUser
            {
                Login = login,
                Password = "asdfgAsd46342GG"
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<LoginUser, LoginUserView>(new LoginUserValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<LoginUserView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(query, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("asdr")]
        [InlineData("asdasdasdasdasdasdtretrerterwer")]
        [InlineData("fhydrfhfki2156")]
        [InlineData("fhyD rfhfki2156")]
        public async void Should_have_error_ValidateDecorLoginUser_Password(string pass)
        {
            var query = new LoginUser
            {
                Login = "test",
                Password = pass
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<LoginUser, LoginUserView>(new LoginUserValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<LoginUserView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(query, default, @delegate));
        }

        [Fact]
        public async void Should_not_have_error_LoginUserhandler()
        {
            var query = new LoginUser
            {
                Login = "test",
                Password = "asdfgAsd46342GG"
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);

            await handler.Handle(query, default);
        }

        [Fact]
        public async void Should_have_error_LoginUserhandler_ORM_Exception()
        {
            var query = new LoginUser
            {
                Login = "test",
                Password = "asdfgAsd46342GG"
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Throws<Exception>();

            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorLoginUser_ORM_Exception()
        {
            var query = new LoginUser
            {
                Login = "test",
                Password = "fhyDFFrfhfki2156"
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Throws<Exception>();

            var validateDecor = new ValidateRequestDecorator<LoginUser, LoginUserView>(new LoginUserValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<LoginUserView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(query, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_LoginUserhandler_NotFound_Exception()
        {
            var query = new LoginUser
            {
                Login = "tess",
                Password = "asdfgAsd46342GG"
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorLoginUser_NotFound_Exception()
        {
            var query = new LoginUser
            {
                Login = "tess",
                Password = "fhyDFFrfhfki2156"
            };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<LoginUser, LoginUserView>(new LoginUserValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<LoginUserView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(query, default, @delegate));
        }
    }
}

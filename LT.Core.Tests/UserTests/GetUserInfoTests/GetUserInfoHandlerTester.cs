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

namespace LT.Core.Tests.UserTests.GetUserInfoTests
{
    public class GetUserInfoHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReadonlyRepository<User>> _mockRepository;

        public GetUserInfoHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));

            _mapper = mockMapper.CreateMapper();
            _mockRepository = new Mock<IReadonlyRepository<User>>();
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorGetUserInfo()
        {
            var query = new GetUserInfo { Id = Guid.NewGuid() };
            var list = new List<User> { new User { Id = query.Id, Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<GetUserInfo, GetUserInfoView>(new GetUserInfoValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetUserInfoView>(() => handler.Handle(query, default));

            await validateDecor.Handle(query, default, @delegate);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorGetUserInfo_Id_default()
        {
            var query = new GetUserInfo { Id = default };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<GetUserInfo, GetUserInfoView>(new GetUserInfoValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetUserInfoView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<ValidationException>(() => validateDecor.Handle(query, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_GetUserInfoHandler_ORM_Exception()
        {
            var query = new GetUserInfo { Id = Guid.NewGuid() };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Throws<Exception>();

            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorGetUserInfo_ORM_Exception()
        {
            var query = new GetUserInfo { Id = Guid.NewGuid() };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Throws<Exception>();

            var validateDecor = new ValidateRequestDecorator<GetUserInfo, GetUserInfoView>(new GetUserInfoValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetUserInfoView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(query, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_GetUserInfoHandler_NotFound_Exception()
        {
            var query = new GetUserInfo { Id = Guid.NewGuid() };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                          .Returns(mock.Object);

            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorGetUserInfo_NotFound_Exception()
        {
            var query = new GetUserInfo { Id = Guid.NewGuid() };
            var list = new List<User> { new User { Login = "test", Password = "asdfgAsd46342GG" } };
            var mock = list.AsQueryable().BuildMock();

            _mockRepository.Setup(p => p.GetAll())
                           .Returns(mock.Object);

            var validateDecor = new ValidateRequestDecorator<GetUserInfo, GetUserInfoView>(new GetUserInfoValidator());
            var handler = new UserQueryHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<GetUserInfoView>(() => handler.Handle(query, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecor.Handle(query, default, @delegate));
        }
    }
}

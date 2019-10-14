using AutoMapper;
using FluentValidation;
using LT.Core.Backend.Decorators;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Handlers;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Commands;
using LT.Core.Seedwork.CQRS.Commands;
using LT.Core.Seedwork.Data;
using MediatR;
using Moq;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.ChangeUserPasswordTests
{
    public class ChangeUserPasswordHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<User>> _mockRepository;

        private readonly IPipelineBehavior<ChangeUserPassword, Unit> _validateDecorator;
        private readonly ICommandHandler<ChangeUserPassword> _handler;

        public ChangeUserPasswordHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));

            _mapper = mockMapper.CreateMapper();

            _mockRepository = new Mock<IRepository<User>>();

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .ReturnsAsync(It.IsAny<User>());

            _mockRepository.Setup(p => p.UpdateAsync(It.IsAny<User>()))
                           .ReturnsAsync(It.IsAny<User>());

            _validateDecorator = new ValidateRequestDecorator<ChangeUserPassword, Unit>(new ChangeUserPasswordValidator());
            _handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorChangeUserPassword()
        {
            var command = new ChangeUserPassword { Id = Guid.NewGuid(), OldPassword = "hfjjYYd12", NewPassword = "hsLLsit32" };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await _validateDecorator.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_not_have_error_ChangeUserPasswordHandler()
        {
            var command = new ChangeUserPassword { Id = Guid.NewGuid(), OldPassword = "hfjjYYd12", NewPassword = "hsLLsit32" };

            await _handler.Handle(command, default);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorChangeUserPassword_Id_default()
        {
            var command = new ChangeUserPassword { Id = default, OldPassword = "hfjjYYd12", NewPassword = "hsLLsit32" };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null,               "hsLLsit32")]
        [InlineData("",                 "hsLLsit32")]
        [InlineData(" ",                "hsLLsit32")]
        [InlineData("hfjjYYd12",        null)]
        [InlineData("hfjjYYd12",        "")]
        [InlineData("hfjjYYd12",        " ")]
        [InlineData(null,               null)]
        [InlineData("",                 "")]
        [InlineData(" ",                " ")]
        [InlineData("asdr",             "hsLLsit32")]
        [InlineData("fhydrfhfki2156",   "hsLLsit32")]
        [InlineData("fhyD rfhfki2156",  "hsLLsit32")]
        [InlineData("hfjjYYd12",        "asdr")]
        [InlineData("hfjjYYd12",        "asdasdasdasdasdasdtretrerterwer")]
        [InlineData("hfjjYYd12",        "fhydrfhfki2156")]
        [InlineData("hfjjYYd12",        "fhyD rfhfki2156")]
        [InlineData("asdasdasdasdasdasdtretrerterwer", "hsLLsit32")]
        public async void Should_have_error_ValidateDecorChangeUserPassword(string oldPass, string newPass)
        {
            var command = new ChangeUserPassword { Id = Guid.NewGuid(), OldPassword = oldPass, NewPassword = newPass };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ChangeUserPasswordHandler_ORM_Exception()
        {
            var command = new ChangeUserPassword { Id = Guid.NewGuid(), OldPassword = "hfjjYYd12", NewPassword = "hsLLsit32" };

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .Throws<Exception>();

            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorChangeUserPassword_ORM_Exception()
        {
            var command = new ChangeUserPassword { Id = Guid.NewGuid(), OldPassword = "hfjjYYd12", NewPassword = "hsLLsit32" };

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .Throws<Exception>();

            var validateDecorator = new ValidateRequestDecorator<ChangeUserPassword, Unit>(new ChangeUserPasswordValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecorator.Handle(command, default, @delegate));
        }
    }
}

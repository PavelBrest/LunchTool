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

namespace LT.Core.Tests.UserTests.ChangeUserSurnameTests
{
    public class ChangeUserSurnameHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<User>> _mockRepository;

        private readonly IPipelineBehavior<ChangeUserSurname, Unit> _validateDecorator;
        private readonly ICommandHandler<ChangeUserSurname> _handler;

        public ChangeUserSurnameHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));

            _mapper = mockMapper.CreateMapper();

            _mockRepository = new Mock<IRepository<User>>();

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .ReturnsAsync(It.IsAny<User>());

            _mockRepository.Setup(p => p.UpdateAsync(It.IsAny<User>()))
                           .ReturnsAsync(It.IsAny<User>());

            _validateDecorator = new ValidateRequestDecorator<ChangeUserSurname, Unit>(new ChangeUserSurnameValidator());
            _handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorChangeUserSurname()
        {
            var command = new ChangeUserSurname { Id = Guid.NewGuid(), Surname = "testSurname" };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await _validateDecorator.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_not_have_error_ChangeUserSurnameHandler()
        {
            var command = new ChangeUserSurname { Id = Guid.NewGuid(), Surname = "testSurname" };

            await _handler.Handle(command, default);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorChangeUserSurname_Id_default()
        {
            var command = new ChangeUserSurname { Id = default, Surname = "testSurname" };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void Should_have_error_ValidateDecorChangeUserSurname_Surname(string surname)
        {
            var command = new ChangeUserSurname { Id = Guid.NewGuid(), Surname = surname };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ChangeUserSurnameHandler_ORM_Exception()
        {
            var command = new ChangeUserSurname { Id = Guid.NewGuid(), Surname = "testSurname" };

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .Throws<Exception>();

            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorChangeUserSurname_ORM_Exception()
        {
            var command = new ChangeUserSurname { Id = Guid.NewGuid(), Surname = "testSurname" };

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .Throws<Exception>();

            var validateDecorator = new ValidateRequestDecorator<ChangeUserSurname, Unit>(new ChangeUserSurnameValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecorator.Handle(command, default, @delegate));
        }
    }
}

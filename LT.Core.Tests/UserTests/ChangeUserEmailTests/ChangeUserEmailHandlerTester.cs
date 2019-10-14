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

namespace LT.Core.Tests.UserTests.ChangeUserEmailTests
{
    public class ChangeUserEmailHandlerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<User>> _mockRepository;

        private readonly IPipelineBehavior<ChangeUserEmail, Unit> _validateDecorator;
        private readonly ICommandHandler<ChangeUserEmail> _handler;

        public ChangeUserEmailHandlerTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));

            _mapper = mockMapper.CreateMapper();

            _mockRepository = new Mock<IRepository<User>>();

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .ReturnsAsync(It.IsAny<User>());

            _mockRepository.Setup(p => p.UpdateAsync(It.IsAny<User>()))
                           .ReturnsAsync(It.IsAny<User>());

            _validateDecorator = new ValidateRequestDecorator<ChangeUserEmail, Unit>(new ChangeUserEmailValidator());
            _handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async void Should_not_have_error_ValidateDecorChangeUserEmail()
        {
            var command = new ChangeUserEmail { Id = Guid.NewGuid(), EmailAddress = "1@gmail.com" };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await _validateDecorator.Handle(command, default, @delegate);
        }

        [Fact]
        public async void Should_not_have_error_ChangeUserEmailHandler()
        {
            var command = new ChangeUserEmail { Id = Guid.NewGuid(), EmailAddress = "1@gmail.com" };

            await _handler.Handle(command, default);
        }

        [Fact]
        public async void Should_have_error_ValidateDecorChangeUserEmail_Id_default()
        {
            var command = new ChangeUserEmail { Id = default, EmailAddress = "1@gmail.com" };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(command, default, @delegate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("hh")]
        [InlineData("@gmail.com")]
        public async void Should_have_error_ValidateDecorChangeUserEmail_Email(string email)
        {
            var command = new ChangeUserEmail { Id = Guid.NewGuid(), EmailAddress = email };

            var @delegate = new RequestHandlerDelegate<Unit>(() => _handler.Handle(command, default));

            await Assert.ThrowsAsync<ValidationException>(() => _validateDecorator.Handle(command, default, @delegate));
        }

        [Fact]
        public async void Should_have_error_ChangeUserEmailHandler_ORM_Exception()
        {
            var command = new ChangeUserEmail { Id = Guid.NewGuid(), EmailAddress = "1@gmail.com" };

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .Throws<Exception>();

            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));
        }

        [Fact]
        public async void Should_have_error_ValidateDecorChangeUserEmail_ORM_Exception()
        {
            var command = new ChangeUserEmail { Id = Guid.NewGuid(), EmailAddress = "1@gmail.com" };

            _mockRepository.Setup(p => p.GetByIdAsync(It.IsAny<Guid>()))
                           .Throws<Exception>();

            var validateDecorator = new ValidateRequestDecorator<ChangeUserEmail, Unit>(new ChangeUserEmailValidator());
            var handler = new UserCommandsHandler(_mockRepository.Object, _mapper);
            var @delegate = new RequestHandlerDelegate<Unit>(() => handler.Handle(command, default));

            await Assert.ThrowsAsync<Exception>(() => validateDecorator.Handle(command, default, @delegate));
        }
    }
}

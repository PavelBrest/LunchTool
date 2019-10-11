using AutoMapper;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.RegisterUserTests
{
    public class RegisterUserMapperTester
    {
        private readonly IMapper _mapper;

        public RegisterUserMapperTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_RegisterUser_to_User()
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "123456789123456",
                Name = "TestName",
                Surname = "TestSurname",
                EmailAddress = "1@gmail.com"
            };

            var result = _mapper.Map<User>(command);

            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.Login, result.Login);
            Assert.Equal(command.Password, result.Password);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.Surname, result.Surname);
            Assert.Equal(command.EmailAddress, result.EmailAddress);
        }

        [Fact]
        public void Should_not_have_error_RegisterUser_to_User_NullProperty()
        {
            var command = new RegisterUser
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "123456789123456",
                Name = "TestName",
                Surname = null,
                EmailAddress = "1@gmail.com"
            };

            var result = _mapper.Map<User>(command);

            Assert.Equal(command.Id, result.Id);
            Assert.Equal(command.Login, result.Login);
            Assert.Equal(command.Password, result.Password);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.Surname, result.Surname);
            Assert.Equal(command.EmailAddress, result.EmailAddress);
        }
    }
}

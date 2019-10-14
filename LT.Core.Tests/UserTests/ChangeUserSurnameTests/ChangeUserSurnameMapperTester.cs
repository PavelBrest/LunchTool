using AutoMapper;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Commands;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.ChangeUserSurnameTests
{
    public class ChangeUserSurnameMapperTester
    {
        private readonly IMapper _mapper;

        public ChangeUserSurnameMapperTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ChangeUserPassword_to_User()
        {
            var command = new ChangeUserSurname
            {
                Id = Guid.NewGuid(),
                Surname = "newSurname"
            };

            var entity = new User
            {
                Id = command.Id,
                Login = "test",
                Password = "1234567SS123a56",
                Name = "TestName",
                Surname = "TestSurname",
                EmailAddress = "2@gmail.com"
            };

            _mapper.Map(command, entity);

            Assert.Equal(command.Id,        entity.Id);
            Assert.Equal("test",            entity.Login);
            Assert.Equal("1234567SS123a56", entity.Password);
            Assert.Equal("TestName",        entity.Name);
            Assert.Equal("newSurname",      entity.Surname);
            Assert.Equal("2@gmail.com",     entity.EmailAddress);
        }
    }
}

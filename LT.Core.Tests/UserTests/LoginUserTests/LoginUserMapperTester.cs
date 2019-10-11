using AutoMapper;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Views;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.LoginUserTests
{
    public class LoginUserMapperTester
    {
        private readonly IMapper _mapper;

        public LoginUserMapperTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_RegisterUser_to_User()
        {
            var entity = new User
            {
                Id = Guid.NewGuid(),
                Login = "test",
                Password = "123456789123456",
                Name = "TestName",
                Surname = "TestSurname",
                EmailAddress = "1@gmail.com"
            };

            var result = _mapper.Map<LoginUserView>(entity);

            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.Name, result.Name);
        }
    }
}

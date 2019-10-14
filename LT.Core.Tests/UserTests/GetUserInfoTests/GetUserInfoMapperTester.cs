using AutoMapper;
using LT.Core.Backend.Users;
using LT.Core.Backend.Users.Mappings;
using LT.Core.Contracts.User.Views;
using System;
using Xunit;

namespace LT.Core.Tests.UserTests.GetUserInfoTests
{
    public class GetUserInfoMapperTester
    {
        private readonly IMapper _mapper;

        public GetUserInfoMapperTester()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()));
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_User_to_GetUserInfoView()
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

            var result = _mapper.Map<GetUserInfoView>(entity);

            Assert.Equal(entity.Id,           result.Id);
            Assert.Equal(entity.Name,         result.Name);
            Assert.Equal(entity.Login, result.Login);
            Assert.Equal(entity.Surname,      result.Surname);
            Assert.Equal(entity.EmailAddress, result.EmailAddress);
        }
    }
}

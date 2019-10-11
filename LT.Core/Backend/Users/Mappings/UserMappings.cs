using AutoMapper;
using LT.Core.Contracts.User.Commands;
using LT.Core.Contracts.User.Views;

namespace LT.Core.Backend.Users.Mappings
{
    internal class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<RegisterUser, User>();
            CreateMap<User, LoginUserView>();
        }
    }
}

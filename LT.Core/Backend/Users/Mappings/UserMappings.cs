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
            CreateMap<ChangeUserEmail, User>();
            CreateMap<ChangeUserName, User>();
            CreateMap<ChangeUserSurname, User>();

            CreateMap<ChangeUserPassword, User>()
                .ForMember(p => p.Password, cfg => cfg.MapFrom(p => p.NewPassword));
        }
    }
}

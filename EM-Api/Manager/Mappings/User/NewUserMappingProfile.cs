using AutoMapper;
using Core.Domain.Model.User;
using EventManager.Shared.Modelviews;
using Shared.Modelviews.User;

namespace Manager
{
    public class NewUserMappingProfile : Profile
    {
        public NewUserMappingProfile()
        {
            CreateMap<NewUser, User>();
            CreateMap<User, UserView>();
        }
    }
}

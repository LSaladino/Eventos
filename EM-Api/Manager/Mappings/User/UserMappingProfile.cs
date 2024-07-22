using AutoMapper;
using Core.Domain;
using Core.Domain.Model.User;
using EventManager.Shared.Modelviews;
using Shared.Modelviews.Role;
using Shared.Modelviews.User;

namespace Manager.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<User, NewUser>().ReverseMap();
            CreateMap<User, LoggedUser>().ReverseMap();
            CreateMap<Role, RoleView>().ReverseMap();
            CreateMap<Role, RoleReference>().ReverseMap();
        }
    }
}

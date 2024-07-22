using AutoMapper;
using Core.Domain.Model.User;
using EventManager.Shared.Modelviews;

namespace Manager
{
    public class UpdateUserMappingProfile :Profile
    {
        public UpdateUserMappingProfile()
        {
            CreateMap<UpdateUser, User>();
        }
    }
}

using AutoMapper;
using Core.Domain.Model.Event;
using EventManager.Shared.Modelviews;

namespace Manager.Mappings
{
    public class UpdateEventMappingProfile:Profile
    {
        public UpdateEventMappingProfile()
        {
            CreateMap<UpdateEvent, Event>();
        }
    }
}

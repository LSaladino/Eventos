using AutoMapper;
using Core.Domain.Model.Event;
using EventManager.Shared.Modelviews;
using EventManager.Shared.Modelviews.Event;

namespace Manager.Mappings
{
    public class NewEventMappingProfile : Profile
    {
        public NewEventMappingProfile()
        {
            CreateMap<NewEvent, Event>();
            CreateMap<Event, EventView>();
        }
    }
}

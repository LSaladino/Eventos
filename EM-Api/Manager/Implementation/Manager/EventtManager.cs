using AutoMapper;
using EventManager.Interfaces.Managers;
using EventManager.Shared.Modelviews.Event;
using EventManager.Shared.Modelviews;
using Manager.Interfaces.Repositories;
using Core.Domain.Model.Event;

namespace Manager.Implementation.Manager
{
    public class EventtManager : IEventManager
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventtManager(IEventRepository eventRepository, IMapper mapper)  
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventView> DeleteEventAsync(int id)
        {
            var events = await _eventRepository.DeleteEventAsync(id);
            return _mapper.Map<EventView>(events);
        }

        public async Task<IEnumerable<EventView>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return _mapper.Map<IEnumerable<Event>, IEnumerable<EventView>>(events);
        }

        public async Task<EventView> GetEventByIdAsync(int id)
        {
            var events = await _eventRepository.GetEventByIdAsync(id);
            return _mapper.Map<EventView>(events);
        }

        //public async Task<EventView> GetEventsByCustomerIdAsync(int customerId)  
        //{
        //    var events = await _eventRepository.GetEventsByCustomerIdAsync(customerId);
        //    return _mapper.Map<EventView>(events);
        //}

        public async Task<EventView> InsertEventAsync(NewEvent newEvent)
        {
            var events = _mapper.Map<Event>(newEvent);
            events = await _eventRepository.InsertEventAsync(events);
            return _mapper.Map<EventView>(events);
        }

        public async Task<EventView> UpdateEventAsync(UpdateEvent updEvents)
        {
            var events = _mapper.Map<Event>(updEvents);
            events = await _eventRepository.UpdateEventAsync(events);
            return _mapper.Map<EventView>(events);
        }
    }
}

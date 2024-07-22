using EventManager.Shared.Modelviews;
using EventManager.Shared.Modelviews.Event;

namespace EventManager.Interfaces.Managers
{
    public interface IEventManager
    {
        Task<IEnumerable<EventView>> GetAllEventsAsync();
        Task<EventView> GetEventByIdAsync(int id);
        Task<EventView> InsertEventAsync(NewEvent newEvent);
        Task<EventView> UpdateEventAsync(UpdateEvent updateEvent);  
        Task<EventView> DeleteEventAsync(int id);
        //Task<EventView> GetEventsByCustomerIdAsync(int customerId);     
    }
}

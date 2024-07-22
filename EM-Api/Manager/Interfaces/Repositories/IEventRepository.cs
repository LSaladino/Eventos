using Core.Domain.Model.Event;

namespace Manager.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(); 
        Task<Event> GetEventByIdAsync(int id);      
        Task<Event> InsertEventAsync(Event events);
        Task<Event> UpdateEventAsync(Event events);  
        Task<Event> DeleteEventAsync(int id);
        //Task<Event> GetEventsByCustomerIdAsync(int customerId);     
    }
}

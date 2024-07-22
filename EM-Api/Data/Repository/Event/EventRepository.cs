using Core.Domain.Model.Event;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly MyContext _context;

        public EventRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<Event> DeleteEventAsync(int id)  
        {
            var eventFinded = await _context.Events.FindAsync(id);

            if (eventFinded == null) { return null; }

            var eventRemoved = _context.Events.Remove(eventFinded);
            await _context.SaveChangesAsync();
            return eventRemoved.Entity;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.AsNoTracking().ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        //public async Task<Event> GetEventsByCustomerId(int customerId)
        //{
        //    return await _context.Events.FindAsync(customerId);
        //}

        public async Task<Event> InsertEventAsync(Event events)
        {
            await _context.Events.AddAsync(events);
            await _context.SaveChangesAsync();
            return events;
        }

        public async Task<Event> UpdateEventAsync(Event events)
        {
            var eventFind = await _context.Events.FindAsync(events.Id);
            if (eventFind != null)
            {
                _context.Entry(eventFind).CurrentValues.SetValues(events);
                await _context.SaveChangesAsync();
                return eventFind;
            }
            return null;
        }
    }
}

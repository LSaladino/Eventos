using Core.Domain.Model.Event;

namespace Core.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Event>? Events { get; set; }
    }
}

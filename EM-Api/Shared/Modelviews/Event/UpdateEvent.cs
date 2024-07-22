using EventManager.Shared.Modelviews.Event;

namespace EventManager.Shared.Modelviews
{
    public class UpdateEvent : NewEvent
    {
        public int Id { get; set; } 
    }
}

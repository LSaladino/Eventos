namespace EventManager.Shared.Modelviews
{       
    public class EventView : ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string EventHour { get; set; } = string.Empty;

        public EventView TypedClone()
        {
            return (EventView)Clone();
        }

        public object Clone()
        {
            var events = (EventView)MemberwiseClone();
            return events;
        }
    }
}

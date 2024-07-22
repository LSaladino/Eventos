namespace EventManager.Shared.Modelviews
{       
    public class EventView : ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime EventDateHour { get; set; }

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

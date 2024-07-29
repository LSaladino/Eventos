namespace Core.Domain.Model.Event
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;   
        public string Description { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string EventHour { get; set; } = string.Empty;
    }
}

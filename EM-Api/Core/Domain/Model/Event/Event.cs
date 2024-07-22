namespace Core.Domain.Model.Event
{
    public class Event
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;   
        public string Description { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime EventDateHour { get; set; }
    }
}

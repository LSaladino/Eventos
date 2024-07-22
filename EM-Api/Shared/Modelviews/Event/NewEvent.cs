
namespace EventManager.Shared.Modelviews.Event;

/// <summary>
/// Objeto utilizado para inserção de um novo cliente
/// </summary>
public class NewEvent
{
    //public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
    public DateTime EventDateHour { get; set; }
}

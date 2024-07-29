
namespace EventManager.Shared.Modelviews.Event;

/// <summary>
/// Objeto utilizado para inserção de um novo cliente
/// </summary>
public class NewEvent
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string EventHour { get; set; } = string.Empty;
}

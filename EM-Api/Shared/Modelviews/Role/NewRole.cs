using EventManager.Shared.Modelviews;

namespace Shared.Modelviews.Role
{
    public class NewRole
    {
        public string? Description { get; set; }
        public ICollection<UserView>? Users { get; set; }
    }
}
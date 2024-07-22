using Shared.Modelviews.Role;

namespace EventManager.Shared.Modelviews
{
    public class UserView
    {
        public string Email { get; set; } = string.Empty;   
        public ICollection<RoleView>? Roles { get; set; }
    }
}


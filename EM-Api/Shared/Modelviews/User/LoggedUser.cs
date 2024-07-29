using Shared.Modelviews.Role;

namespace Shared.Modelviews.User
{
    public class LoggedUser
    {
        public string Login { get; set; } = string.Empty;
        public ICollection<RoleView>? Roles { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
